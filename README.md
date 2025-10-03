# ShowBuffs PoE2 Plugin for ExileCore2

A powerful and flexible buff and debuff tracking plugin for Path of Exile 2 that displays Headhunter stacks and other effects above your character's head with customizable positioning and multilingual support.

## 🌟 Features

- **Dynamic Buff Management** - Add/remove buffs and debuffs on the fly
- **Flexible Positioning** - Display above head or at fixed screen positions
- **Multilingual Support** - English and Russian interfaces
- **Smart Display Logic** - Hide stack counts for auras, show counts for stackable buffs
- **Customizable Appearance** - Colors, font size, background options
- **Real-time Updates** - Live buff and debuff tracking from DevTree

## 📦 Installation

1. Download the plugin files
2. Extract the `ShowBuffs_PoE2` folder to your ExileCore2 `Plugins/Source/` directory
3. Restart ExileCore2
4. Enable the plugin in the ExileCore2 interface

## 🚀 Quick Start

1. **Open Plugin Settings** - Find "ShowBuffs PoE2" in your ExileCore2 plugin list
2. **Add Your First Buff** - Click "+ Add Buff" to start tracking buffs
3. **Configure Display** - Adjust colors, positioning, and display options
4. **Add More Buffs** - Add as many buffs as you need

## 🎯 Use Cases

### Headhunter Stacks
Track your Headhunter stacks to know how many mods you've stolen:
- **Buff Name:** `stolen_mods_buff`
- **Display Name:** `HH` (custom name)
- **Display:** `HH: 25` (shows count)
- **Perfect for:** Mapping with Headhunter builds

### Aura Bot Detection
Know when an aura bot is nearby and providing buffs:
- **Buff Name:** `player_aura_cold_resist` (Cold Resistance Aura)
- **Display:** `Cold Aura` (no count, since it's a single aura)
- **Perfect for:** Group play, knowing when support is active

### Presence Buffs
Track various buffs that appear in Presence:
- **Buff Name:** `player_aura_cold_resist` (Cold Resistance Aura)
- **Display:** `Cold Aura` (no count, since it's a single aura)
- **Perfect for:** Monitoring any buffs from Presence section

### Cooler/Rarity Bot Detection
Monitor when Cooler or Rarity Bot is providing benefits:
- **Buff Name:** `player_aura_item_rarity` (Item Rarity Aura)
- **Display:** `Rarity Bot` (no count)
- **Perfect for:** MF runs, knowing when rarity bot is active

### Shrine Effects
Track shrine buffs and their effects:
- **Buff Name:** `shrine_magicfind_2` (Magic Find Shrine)
- **Display:** `Magic Find Shrine` (no count)
- **Perfect for:** MF runs, knowing when magic find shrine is active

### Debuff Tracking
Track negative effects on your character:
- **Debuff Name:** `curse_elemental_weakness` (Elemental Weakness Curse)
- **Display:** `Elemental Weakness` (no count)
- **Perfect for:** Knowing when you're cursed, monitoring negative effects
- **Debuff Name:** `abyss_desecrated_ground` (Abyss Desecrated Ground)
- **Display:** `Desecrated Ground` (no count)
- **Perfect for:** Avoiding dangerous ground effects

## ⚙️ Configuration

### Basic Settings
- **Language** - Switch between English and Russian
- **Font Size** - Adjust text size (0.5x to 3.0x)
- **Height Offset** - Distance above character head
- **Show Background** - Semi-transparent background for better visibility
- **Show in Hideout** - Display buffs in hideout (disabled by default)

### Buff Settings
Each buff can be configured with:
- **Buff Name** - Exact name from DevTree (e.g., `stolen_mods_buff`)
- **Display Name** - What shows on screen (e.g., `HH`)
- **Show/Hide** - Enable or disable the buff
- **Text Color** - Custom color for each buff
- **Min Stacks** - Only show if stacks exceed this number
- **Hide Count** - Show only name without count (for auras)
- **Positioning** - Above head or fixed screen position

### Positioning Options
- **Above Head** - Follows character movement
  - **Offset X/Y** - Fine-tune position relative to head
- **Fixed Position** - Static screen position
  - **Position X/Y** - Absolute screen coordinates

## 🔍 Finding Buff Names

### Method 1: DevTree
1. Open DevTree in-game
2. Navigate to `Player` → `Buffs`
3. Look for the buff you want to track
4. Copy the exact name (e.g., `stolen_mods_buff`)

### Method 2: Presence (for Auras)
1. Open DevTree in-game
2. Navigate to `Player` → `Presence`
3. Look for aura effects
4. Copy the exact name (e.g., `player_aura_cold_resist`)

## 📝 Examples

### Example 1: Headhunter + Aura Bot
```
HH: 15          <- Headhunter stacks
Cold Aura       <- Aura bot nearby
```

### Example 2: Multiple Presence Buffs
```
Cold Aura       <- Cold resistance aura
Fire Aura       <- Fire resistance aura
```

### Example 3: MF Setup
```
Rarity Bot      <- Rarity bot active
Quantity Bot    <- Quantity bot active
HH: 8           <- Some Headhunter stacks
```

### Example 4: Debuff Monitoring
```
HH: 15          <- Headhunter stacks
Elemental Weakness <- Curse active
Cold Aura       <- Aura bot nearby
```

## 🎨 Customization Tips

### For Stackable Buffs (like Headhunter)
- **Min Stacks:** 1 (show when you have any)
- **Hide Count:** OFF (show the number)
- **Display:** `HH: 25`

### For Auras (single instance)
- **Min Stacks:** 0 (show when present)
- **Hide Count:** ON (don't show count)
- **Display:** `Cold Aura`

### For Group Buffs
- **Min Stacks:** 1 (show when active)
- **Hide Count:** OFF (show stack count)
- **Display:** `Allies DMG: 3`

## 🐛 Troubleshooting

### Buff Not Showing
1. Check if buff name is correct in DevTree
2. Verify "Show" checkbox is enabled
3. Check if "Min Stacks" setting is appropriate
4. Ensure buff is actually active in-game

### Positioning Issues
1. Try "Above Head" mode first
2. Use small offset values (-50 to +50)
3. For fixed position, use screen coordinates
4. Test with different font sizes

### Performance
- The plugin is optimized for minimal performance impact
- Only active buffs are processed
- Rendering is done efficiently with ImGui

## 🔧 Advanced Usage

### Multiple Characters
The plugin works with any character - just configure the buffs you want to track for your current build.

### Group Play
Perfect for tracking when support players are providing auras or when you're providing support buffs.

### Build-Specific Tracking
Create different buff configurations for different builds and save them as separate settings.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📞 Support

If you encounter any issues or have questions:
1. Check the [Issues](https://github.com/yourusername/headhunter-stacks/issues) page
2. Create a new issue with detailed information
3. Include your ExileCore2 version and game version

## 🎮 Enjoy Your Enhanced Gameplay!

This plugin will help you stay informed about your buffs and make better decisions during gameplay. Whether you're running Headhunter, playing in groups, or using aura bots, you'll always know what's active!

---


---

# Плагин ShowBuffs PoE2 для ExileCore2

Мощный и гибкий плагин для отслеживания баффов и дебаффов в Path of Exile 2, который отображает стаки Headhunter и другие эффекты над головой персонажа с настраиваемым позиционированием и многоязычной поддержкой.

## 🌟 Возможности

- **Динамическое управление баффами** - Добавляйте/удаляйте баффы и дебаффы на лету
- **Гибкое позиционирование** - Отображение над головой или в фиксированных позициях экрана
- **Многоязычная поддержка** - Английский и русский интерфейсы
- **Умная логика отображения** - Скрытие количества стаков для аур, показ количества для стакуемых баффов
- **Настраиваемый внешний вид** - Цвета, размер шрифта, опции фона
- **Обновления в реальном времени** - Живое отслеживание баффов и дебаффов из DevTree

## 📦 Установка

1. Скачайте файлы плагина
2. Извлеките папку `ShowBuffs_PoE2` в директорию `Plugins/Source/` вашего ExileCore2
3. Перезапустите ExileCore2
4. Включите плагин в интерфейсе ExileCore2

## 🚀 Быстрый старт

1. **Откройте настройки плагина** - Найдите "ShowBuffs PoE2" в списке плагинов ExileCore2
2. **Добавьте первый бафф** - Нажмите "+ Add Buff" чтобы начать отслеживание баффов
3. **Настройте отображение** - Настройте цвета, позиционирование и опции отображения
4. **Добавьте больше баффов** - Добавьте столько баффов, сколько нужно

## 🎯 Случаи использования

### Стаки Headhunter
Отслеживайте стаки Headhunter, чтобы знать, сколько модов вы украли:
- **Название баффа:** `stolen_mods_buff`
- **Название отображения:** `HH` (кастомное имя)
- **Отображение:** `HH: 25` (показывает количество)
- **Идеально для:** Маппинга с билдами Headhunter

### Обнаружение аура-бота
Знайте, когда аура-бот находится рядом и предоставляет баффы:
- **Название баффа:** `player_aura_cold_resist` (Аура сопротивления холоду)
- **Отображение:** `Cold Aura` (без количества, так как это одиночная аура)
- **Идеально для:** Групповой игры, знание когда поддержка активна

### Баффы из Presence
Отслеживайте различные баффы, которые появляются в Presence:
- **Название баффа:** `player_aura_cold_resist` (Аура сопротивления холоду)
- **Отображение:** `Cold Aura` (без количества, так как это одиночная аура)
- **Идеально для:** Мониторинга любых баффов из раздела Presence

### Обнаружение Cooler/Rarity Bot
Отслеживайте, когда Cooler или Rarity Bot предоставляет преимущества:
- **Название баффа:** `player_aura_item_rarity` (Аура редкости предметов)
- **Отображение:** `Rarity Bot` (без количества)
- **Идеально для:** MF-забегов, знание когда бот редкости активен

### Эффекты святилищ
Отслеживайте баффы святилищ и их эффекты:
- **Название баффа:** `shrine_magicfind_2` (Святилище магического поиска)
- **Отображение:** `Magic Find Shrine` (без количества)
- **Идеально для:** MF-забегов, знание когда святилище магического поиска активно

### Отслеживание дебаффов
Отслеживайте негативные эффекты на вашем персонаже:
- **Название дебаффа:** `curse_elemental_weakness` (Проклятие слабости к стихиям)
- **Отображение:** `Elemental Weakness` (без количества)
- **Идеально для:** Знания когда вы прокляты, мониторинга негативных эффектов
- **Название дебаффа:** `abyss_desecrated_ground` (Оскверненная земля бездны)
- **Отображение:** `Desecrated Ground` (без количества)
- **Идеально для:** Избегания опасных эффектов земли

## ⚙️ Конфигурация

### Основные настройки
- **Язык** - Переключение между английским и русским
- **Размер шрифта** - Настройка размера текста (0.5x до 3.0x)
- **Смещение по высоте** - Расстояние над головой персонажа
- **Показать фон** - Полупрозрачный фон для лучшей видимости
- **Показывать в хайдауте** - Отображать баффы в хайдауте (по умолчанию отключено)

### Настройки баффов
Каждый бафф можно настроить:
- **Название баффа** - Точное название из DevTree (например, `stolen_mods_buff`)
- **Отображаемое название** - Что показывается на экране (например, `HH`)
- **Показать/Скрыть** - Включить или выключить бафф
- **Цвет текста** - Пользовательский цвет для каждого баффа
- **Мин. стаков** - Показывать только если стаков больше этого числа
- **Скрыть количество** - Показывать только название без количества (для аур)
- **Позиционирование** - Над головой или фиксированная позиция экрана

### Опции позиционирования
- **Над головой** - Следует за движением персонажа
  - **Смещение X/Y** - Точная настройка позиции относительно головы
- **Фиксированная позиция** - Статическая позиция экрана
  - **Позиция X/Y** - Абсолютные координаты экрана

## 🔍 Поиск названий баффов

### Метод 1: DevTree
1. Откройте DevTree в игре
2. Перейдите в `Player` → `Buffs`
3. Найдите бафф, который хотите отслеживать
4. Скопируйте точное название (например, `stolen_mods_buff`)

### Метод 2: Presence (для аур)
1. Откройте DevTree в игре
2. Перейдите в `Player` → `Presence`
3. Найдите эффекты аур
4. Скопируйте точное название (например, `player_aura_cold_resist`)

## 📝 Примеры

### Пример 1: Headhunter + Аура-бот
```
HH: 15          <- Стаки Headhunter
Cold Aura       <- Аура-бот рядом
```

### Пример 2: Несколько баффов из Presence
```
Cold Aura       <- Аура сопротивления холоду
Fire Aura       <- Аура сопротивления огню
```

### Пример 3: MF-настройка
```
Rarity Bot      <- Бот редкости активен
Quantity Bot    <- Бот количества активен
HH: 8           <- Несколько стаков Headhunter
```

### Пример 4: Мониторинг дебаффов
```
HH: 15          <- Стаки Headhunter
Elemental Weakness <- Проклятие активно
Cold Aura       <- Аура-бот рядом
```

## 🎨 Советы по настройке

### Для стакуемых баффов (как Headhunter)
- **Мин. стаков:** 1 (показывать когда есть любые)
- **Скрыть количество:** ВЫКЛ (показывать число)
- **Отображение:** `HH: 25`

### Для аур (одиночный экземпляр)
- **Мин. стаков:** 0 (показывать когда присутствует)
- **Скрыть количество:** ВКЛ (не показывать количество)
- **Отображение:** `Cold Aura`

### Для групповых баффов
- **Мин. стаков:** 1 (показывать когда активен)
- **Скрыть количество:** ВЫКЛ (показывать количество стаков)
- **Отображение:** `Allies DMG: 3`

## 🐛 Устранение неполадок

### Бафф не отображается
1. Проверьте, правильно ли указано название баффа в DevTree
2. Убедитесь, что чекбокс "Показать" включен
3. Проверьте, подходит ли настройка "Мин. стаков"
4. Убедитесь, что бафф действительно активен в игре

### Проблемы с позиционированием
1. Сначала попробуйте режим "Над головой"
2. Используйте небольшие значения смещения (-50 до +50)
3. Для фиксированной позиции используйте координаты экрана
4. Тестируйте с разными размерами шрифта

### Производительность
- Плагин оптимизирован для минимального влияния на производительность
- Обрабатываются только активные баффы
- Рендеринг выполняется эффективно с ImGui

## 🔧 Продвинутое использование

### Несколько персонажей
Плагин работает с любым персонажем - просто настройте баффы, которые хотите отслеживать для вашего текущего билда.

### Групповая игра
Идеально для отслеживания, когда игроки поддержки предоставляют ауры или когда вы предоставляете поддерживающие баффы.

### Отслеживание для конкретных билдов
Создавайте разные конфигурации баффов для разных билдов и сохраняйте их как отдельные настройки.

## 📄 Лицензия

Этот проект лицензирован под лицензией MIT - см. файл [LICENSE](LICENSE) для деталей.

## 🤝 Участие в разработке

Вклад в проект приветствуется! Пожалуйста, не стесняйтесь отправлять Pull Request.

## 📞 Поддержка

Если вы столкнулись с проблемами или у вас есть вопросы:
1. Создайте новый issue с подробной информацией
2. Укажите версию ExileCore2 и версию игры

## 📸 Screenshots

### Screenshot 1 - Headhunter Stacks Display
![Headhunter Stacks](images/screenshot1.png)
*Headhunter stacks displayed above character with custom positioning*

### Screenshot 2 - Multiple Buffs Configuration
![Multiple Buffs](images/screenshot2.png)
*Multiple buffs and debuffs configured with different colors and positions*

---

## 📸 Скриншоты

### Скриншот 1 - Отображение стаков Headhunter
![Стаки Headhunter](images/screenshot1.png)
*Стаки Headhunter отображаются над персонажем с настраиваемым позиционированием*

### Скриншот 2 - Конфигурация нескольких баффов
![Несколько баффов](images/screenshot2.png)
*Несколько баффов и дебаффов настроены с разными цветами и позициями*

## 🎮 Наслаждайтесь улучшенным геймплеем!

Этот плагин поможет вам быть в курсе ваших баффов и принимать лучшие решения во время игры. Независимо от того, используете ли вы Headhunter, играете в группах или используете аура-ботов, вы всегда будете знать, что активно!

