using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using ExileCore2;
using ExileCore2.PoEMemory.Components;
using ExileCore2.PoEMemory.MemoryObjects;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Enums;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using ImGuiNET;

namespace ShowBuffs_PoE2
{
    public class BuffSetting
    {
        [Menu("Buff Name", "Exact buff name from DevTree")]
        public TextNode BuffName { get; set; } = new TextNode("");

        [Menu("Display Name", "Name to display")]
        public TextNode DisplayName { get; set; } = new TextNode("");

        [Menu("Show", "Show this buff")]
        public ToggleNode Show { get; set; } = new ToggleNode(false);

        [Menu("Text Color")]
        public ColorNode TextColor { get; set; } = new ColorNode(Color.Orange);

        [Menu("Min Stacks", "Show only if stacks are greater than this number")]
        public RangeNode<int> MinStacks { get; set; } = new RangeNode<int>(1, 0, 100);

        [Menu("Position X", "X offset from center (0 = above head)")]
        public RangeNode<int> PositionX { get; set; } = new RangeNode<int>(0, -1500, 1500);

        [Menu("Position Y", "Y offset from center (0 = above head)")]
        public RangeNode<int> PositionY { get; set; } = new RangeNode<int>(-30, -1500, 1500);

        [Menu("Use Head Position", "If disabled - use fixed position")]
        public ToggleNode UseHeadPosition { get; set; } = new ToggleNode(true);

        [Menu("Hide Stack Count", "Show only name without count (for example aura without stacks=0)")]
        public ToggleNode HideStackCount { get; set; } = new ToggleNode(false);
    }

    public class Settings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);
        
        [Menu("General Settings")]
        public EmptyNode GeneralHeader { get; set; } = new EmptyNode();

        [Menu("Language", "Switch between English and Russian interface")]
        public ToggleNode UseEnglish { get; set; } = new ToggleNode(true);

        [Menu("Font Size", "Font size for display")]
        public RangeNode<float> FontSize { get; set; } = new RangeNode<float>(1.0f, 0.5f, 3.0f);

        [Menu("Height Offset", "Text offset up from character head in pixels")]
        public RangeNode<int> HeightOffset { get; set; } = new RangeNode<int>(60, 0, 200);

        [Menu("Show Background", "Show semi-transparent background behind text for better visibility")]
        public ToggleNode ShowBackground { get; set; } = new ToggleNode(true);

        [Menu("Background Color")]
        public ColorNode BackgroundColor { get; set; } = new ColorNode(Color.FromArgb(128, Color.Black));

        [Menu("Show in Hideout", "Show buffs in hideout")]
        public ToggleNode ShowInHideout { get; set; } = new ToggleNode(false);

        [Menu("Buff Settings")]
        public EmptyNode BuffsHeader { get; set; } = new EmptyNode();

        // Динамический список баффов
        public List<BuffSetting> BuffSettings { get; set; } = new List<BuffSetting>();

        public Settings()
        {
            // Инициализируем список если он null
            if (BuffSettings == null)
            {
                BuffSettings = new List<BuffSetting>();
            }
        }

        public void AddBuff()
        {
            BuffSettings.Add(new BuffSetting
            {
                BuffName = new TextNode(""),
                DisplayName = new TextNode($"Buff{BuffSettings.Count + 1}"),
                Show = new ToggleNode(false),
                TextColor = new ColorNode(Color.Orange),
                MinStacks = new RangeNode<int>(1, 0, 100),
                PositionX = new RangeNode<int>(0, -1500, 1500),
                PositionY = new RangeNode<int>(-30, -1500, 1500),
                UseHeadPosition = new ToggleNode(true),
                HideStackCount = new ToggleNode(false)
            });
        }

        public void RemoveBuff(int index)
        {
            if (index >= 0 && index < BuffSettings.Count)
            {
                BuffSettings.RemoveAt(index);
            }
        }
    }

    public class ShowBuffs_PoE2 : BaseSettingsPlugin<Settings>
    {
        private string GetText(string english, string russian)
        {
            return Settings.UseEnglish ? english : russian;
        }

        public override void OnLoad()
        {
            LogMessage("ShowBuffs PoE2 Plugin loaded!", 5);
        }

        public override void DrawSettings()
        {
            // Рисуем стандартные настройки
            base.DrawSettings();

            // Рисуем кастомный UI для баффов
            DrawBuffsSettings();
        }

        private void DrawBuffsSettings()
        {
            ImGui.Separator();
            ImGui.Text(GetText("Buff Settings", "Настройки баффов"));
            
            // Примеры баффов и дебаффов
            ImGui.TextColored(new System.Numerics.Vector4(1, 1, 0, 1), GetText(
                "💡 Examples: sceptre_allies_damage, sceptre_allies_attack_speed, player_aura_cold_resist, shrine_magicfind_2", 
                "💡 Примеры: sceptre_allies_damage, sceptre_allies_attack_speed, player_aura_cold_resist, shrine_magicfind_2"
            ));
            ImGui.TextColored(new System.Numerics.Vector4(1, 0.5f, 0, 1), GetText(
                "💡 Headhunter = stolen_mods_buff", 
                "💡 Headhunter = stolen_mods_buff"
            ));
            ImGui.TextColored(new System.Numerics.Vector4(1, 0.3f, 0.3f, 1), GetText(
                "💡 Debuffs example: curse_elemental_weakness, abyss_desecrated_ground", 
                "💡 Примеры дебаффов: curse_elemental_weakness, abyss_desecrated_ground"
            ));
            ImGui.TextColored(new System.Numerics.Vector4(0.7f, 0.7f, 0.7f, 1), GetText(
                "Find buffs in DevTree -> Player -> Buffs", 
                "Найдите баффы в DevTree -> Player -> Buffs"
            ));
            ImGui.TextColored(new System.Numerics.Vector4(0.5f, 0.8f, 1f, 1), GetText(
                "💡 Auras are displayed in Presence", 
                "💡 Ауры отображаются в Presence"
            ));
            
            for (int i = 0; i < Settings.BuffSettings.Count; i++)
            {
                var buff = Settings.BuffSettings[i];
                
                ImGui.PushID(i);
                
                // Чекбокс для включения/выключения
                bool show = buff.Show.Value;
                if (ImGui.Checkbox($"##Show{i}", ref show))
                {
                    buff.Show.Value = show;
                }
                ImGui.SameLine();
                
                // Поле для названия баффа из DevTree
                string buffName = buff.BuffName.Value;
                ImGui.SetNextItemWidth(150);
                if (ImGui.InputText($"{GetText("Buff Name", "Название баффа")}##{i}", ref buffName, 100))
                {
                    buff.BuffName.Value = buffName;
                }
                ImGui.SameLine();
                
                // Поле для отображаемого названия
                string displayName = buff.DisplayName.Value;
                ImGui.SetNextItemWidth(100);
                if (ImGui.InputText($"{GetText("Display", "Отображение")}##{i}", ref displayName, 50))
                {
                    buff.DisplayName.Value = displayName;
                }
                ImGui.SameLine();
                
                // Кнопка удаления
                if (ImGui.Button($"-##{i}"))
                {
                    Settings.RemoveBuff(i);
                    i--; // Уменьшаем индекс, так как элемент удален
                }
                
                // Дополнительные настройки для активного баффа
                if (show)
                {
                    ImGui.Indent();
                    
                    // Цвет текста
                    var color = buff.TextColor.Value;
                    var colorVec = new System.Numerics.Vector4(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
                    if (ImGui.ColorEdit4($"{GetText("Color", "Цвет")}##{i}", ref colorVec))
                    {
                        buff.TextColor.Value = Color.FromArgb((int)(colorVec.W * 255), (int)(colorVec.X * 255), (int)(colorVec.Y * 255), (int)(colorVec.Z * 255));
                    }
                    
                    // Минимальное количество стаков
                    int minStacks = buff.MinStacks.Value;
                    if (ImGui.SliderInt($"{GetText("Min Stacks", "Мин. стаков")}##{i}", ref minStacks, 0, 100))
                    {
                        buff.MinStacks.Value = minStacks;
                    }
                    
                    // Скрыть количество стаков
                    bool hideStackCount = buff.HideStackCount.Value;
                    if (ImGui.Checkbox($"{GetText("Hide Count (for example aura without stacks=0)", "Скрыть количество (Аура стаков=0)")}##{i}", ref hideStackCount))
                    {
                        buff.HideStackCount.Value = hideStackCount;
                    }
                    
                    // Позиционирование
                    bool useHeadPos = buff.UseHeadPosition.Value;
                    if (ImGui.Checkbox($"{GetText("Above Head", "Над головой")}##{i}", ref useHeadPos))
                    {
                        buff.UseHeadPosition.Value = useHeadPos;
                    }
                    
                    if (!useHeadPos)
                    {
                        ImGui.Indent();
                        int posX = buff.PositionX.Value;
                        int posY = buff.PositionY.Value;
                        
                        // Слайдер с возможностью ручного ввода
                        if (ImGui.SliderInt($"{GetText("Position X", "Позиция X")}##{i}", ref posX, -1500, 1500))
                        {
                            buff.PositionX.Value = posX;
                        }
                        
                        // Поле для ручного ввода X
                        ImGui.SameLine();
                        ImGui.SetNextItemWidth(80);
                        int inputX = posX;
                        if (ImGui.InputInt($"##InputX{i}", ref inputX))
                        {
                            inputX = Math.Clamp(inputX, -1500, 1500);
                            buff.PositionX.Value = inputX;
                        }
                        
                        if (ImGui.SliderInt($"{GetText("Position Y", "Позиция Y")}##{i}", ref posY, -1500, 1500))
                        {
                            buff.PositionY.Value = posY;
                        }
                        
                        // Поле для ручного ввода Y
                        ImGui.SameLine();
                        ImGui.SetNextItemWidth(80);
                        int inputY = posY;
                        if (ImGui.InputInt($"##InputY{i}", ref inputY))
                        {
                            inputY = Math.Clamp(inputY, -1500, 1500);
                            buff.PositionY.Value = inputY;
                        }
                        
                        ImGui.Unindent();
                    }
                    else
                    {
                        int offsetX = buff.PositionX.Value;
                        int offsetY = buff.PositionY.Value;
                        
                        // Слайдер с возможностью ручного ввода
                        if (ImGui.SliderInt($"{GetText("Offset X", "Смещение X")}##{i}", ref offsetX, -1500, 1500))
                        {
                            buff.PositionX.Value = offsetX;
                        }
                        
                        // Поле для ручного ввода X
                        ImGui.SameLine();
                        ImGui.SetNextItemWidth(80);
                        int inputX = offsetX;
                        if (ImGui.InputInt($"##InputOffsetX{i}", ref inputX))
                        {
                            inputX = Math.Clamp(inputX, -1500, 1500);
                            buff.PositionX.Value = inputX;
                        }
                        
                        if (ImGui.SliderInt($"{GetText("Offset Y", "Смещение Y")}##{i}", ref offsetY, -1500, 1500))
                        {
                            buff.PositionY.Value = offsetY;
                        }
                        
                        // Поле для ручного ввода Y
                        ImGui.SameLine();
                        ImGui.SetNextItemWidth(80);
                        int inputY = offsetY;
                        if (ImGui.InputInt($"##InputOffsetY{i}", ref inputY))
                        {
                            inputY = Math.Clamp(inputY, -1500, 1500);
                            buff.PositionY.Value = inputY;
                        }
                    }
                    
                    ImGui.Unindent();
                }
                
                ImGui.PopID();
            }
            
            // Кнопка добавления нового баффа
            if (ImGui.Button($"+ {GetText("Add Buff", "Добавить бафф")}"))
            {
                Settings.AddBuff();
            }
        }

        public override void Render()
        {
            if (!Settings.Enable) return;

            // Проверяем, нужно ли показывать в хайдауте
            if (!Settings.ShowInHideout && GameController.Area.CurrentArea.IsHideout)
                return;

            try
            {
                var player = GameController.Player;
                if (player == null || !player.IsValid)
                    return;

                // Получаем позицию персонажа
                var playerPos = player.Pos;
                if (playerPos == Vector3.Zero)
                    return;

                // Конвертируем мировые координаты в экранные
                var screenPos = GameController.IngameState.Camera.WorldToScreen(playerPos);
                if (screenPos == Vector2.Zero)
                    return;

                // Добавляем смещение вверх от головы персонажа
                screenPos.Y -= Settings.HeightOffset;

                // Получаем все активные баффы для отображения
                var activeBuffs = GetActiveBuffs(player);
                
                // Рендерим все активные баффы в столбик
                RenderBuffs(screenPos, activeBuffs);
            }
            catch (Exception ex)
            {
                LogError($"Ошибка в HeadhunterStacks: {ex.Message}", 5);
            }
        }

        private List<(string displayName, int count, Color color, bool useHeadPos, int posX, int posY, bool hideStackCount)> GetActiveBuffs(Entity player)
        {
            var activeBuffs = new List<(string, int, Color, bool, int, int, bool)>();
            
            try
            {
                // Получаем компонент баффов персонажа
                if (!player.TryGetComponent<Buffs>(out var buffsComponent))
                    return activeBuffs;

                var buffs = buffsComponent.BuffsList;
                if (buffs == null)
                    return activeBuffs;

                // Получаем все настройки баффов из динамического списка
                foreach (var buffSetting in Settings.BuffSettings)
                {
                    if (!buffSetting.Show || string.IsNullOrEmpty(buffSetting.BuffName))
                        continue;

                    int count = CountBuffsByName(buffs, buffSetting.BuffName);
                    
                    if (count > buffSetting.MinStacks)
                    {
                        activeBuffs.Add((
                            buffSetting.DisplayName, 
                            count, 
                            buffSetting.TextColor,
                            buffSetting.UseHeadPosition,
                            buffSetting.PositionX,
                            buffSetting.PositionY,
                            buffSetting.HideStackCount
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Ошибка получения активных баффов: {ex.Message}", 5);
            }

            return activeBuffs;
        }

        private int CountBuffsByName(IEnumerable<ExileCore2.PoEMemory.Components.Buff> buffs, string buffName)
        {
            try
            {
                int count = 0;
                
                foreach (var buff in buffs)
                {
                    if (buff != null)
                    {
                        var currentBuffName = buff.Name?.ToLowerInvariant();
                        if (!string.IsNullOrEmpty(currentBuffName) && 
                            currentBuffName.Contains(buffName.ToLowerInvariant()))
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
            catch (Exception ex)
            {
                LogError($"Ошибка подсчета баффов {buffName}: {ex.Message}", 5);
                return 0;
            }
        }

        private void RenderBuffs(Vector2 headScreenPos, List<(string displayName, int count, Color color, bool useHeadPos, int posX, int posY, bool hideStackCount)> activeBuffs)
        {
            if (activeBuffs.Count == 0)
                return;

            try
            {
                // Устанавливаем размер шрифта
                using (Graphics.SetTextScale(Settings.FontSize))
                {
                    float lineHeight = 20; // Высота строки
                    float currentY = headScreenPos.Y;

                    // Сортируем баффы: сначала те, что над головой, потом фиксированные
                    var sortedBuffs = activeBuffs.OrderBy(b => b.useHeadPos ? 0 : 1).ToList();

                    foreach (var (displayName, count, color, useHeadPos, posX, posY, hideStackCount) in sortedBuffs)
                    {
                        // Формируем текст в зависимости от настроек
                        string text;
                        if (hideStackCount || count == 0)
                        {
                            text = displayName; // Только название без стаков
                        }
                        else
                        {
                            text = $"{displayName}: {count}";
                        }

                        // Определяем позицию для рендеринга
                        Vector2 renderPos;
                        if (useHeadPos)
                        {
                            // Позиция над головой с учетом смещения
                            renderPos = new Vector2(
                                headScreenPos.X + posX,
                                currentY + posY
                            );
                        }
                        else
                        {
                            // Фиксированная позиция на экране
                            renderPos = new Vector2(posX, posY);
                        }
                        
                        // Измеряем размер текста
                        var textSize = Graphics.MeasureText(text);
                        var textPos = new Vector2(
                            renderPos.X - textSize.X / 2,
                            renderPos.Y - textSize.Y / 2
                        );

                        // Рендерим фон текста для лучшей видимости
                        if (Settings.ShowBackground)
                        {
                            var bgPos = new Vector2(textPos.X - 5, textPos.Y - 2);
                            var bgSize = new Vector2(textSize.X + 10, textSize.Y + 4);
                            Graphics.DrawBox(bgPos, bgPos + bgSize, Settings.BackgroundColor);
                        }

                        // Рендерим текст
                        Graphics.DrawText(text, textPos, color);

                        // Переходим к следующей строке только если используем позицию над головой
                        if (useHeadPos)
                        {
                            currentY += lineHeight * Settings.FontSize;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Ошибка рендеринга баффов: {ex.Message}", 5);
            }
        }
    }
}
