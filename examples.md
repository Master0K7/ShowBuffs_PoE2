# ShowBuffs PoE2 Plugin - Configuration Examples

This file contains various configuration examples for different use cases.

## Headhunter Build

```json
{
  "BuffSettings": [
    {
      "BuffName": "stolen_mods_buff",
      "DisplayName": "HH",
      "Show": true,
      "TextColor": "Orange",
      "MinStacks": 1,
      "PositionX": 0,
      "PositionY": -30,
      "UseHeadPosition": true,
      "HideStackCount": false
    }
  ]
}
```

## Group Play with Aura Bot

```json
{
  "BuffSettings": [
    {
      "BuffName": "stolen_mods_buff",
      "DisplayName": "HH",
      "Show": true,
      "TextColor": "Orange",
      "MinStacks": 1,
      "PositionX": 0,
      "PositionY": -30,
      "UseHeadPosition": true,
      "HideStackCount": false
    },
    {
      "BuffName": "player_aura_cold_resist",
      "DisplayName": "Cold Aura",
      "Show": true,
      "TextColor": "Cyan",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -60,
      "UseHeadPosition": true,
      "HideStackCount": true
    },
    {
      "BuffName": "player_aura_fire_resist",
      "DisplayName": "Fire Aura",
      "Show": true,
      "TextColor": "Red",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -90,
      "UseHeadPosition": true,
      "HideStackCount": true
    }
  ]
}
```

## Multiple Presence Buffs

```json
{
  "BuffSettings": [
    {
      "BuffName": "player_aura_cold_resist",
      "DisplayName": "Cold Aura",
      "Show": true,
      "TextColor": "Cyan",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -30,
      "UseHeadPosition": true,
      "HideStackCount": true
    },
    {
      "BuffName": "player_aura_fire_resist",
      "DisplayName": "Fire Aura",
      "Show": true,
      "TextColor": "Red",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -60,
      "UseHeadPosition": true,
      "HideStackCount": true
    }
  ]
}
```

## Shrine Effects

```json
{
  "BuffSettings": [
    {
      "BuffName": "shrine_magicfind_2",
      "DisplayName": "Magic Find Shrine",
      "Show": true,
      "TextColor": "Gold",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -30,
      "UseHeadPosition": true,
      "HideStackCount": true
    }
  ]
}
```

## MF Setup with Bots

```json
{
  "BuffSettings": [
    {
      "BuffName": "player_aura_item_rarity",
      "DisplayName": "Rarity Bot",
      "Show": true,
      "TextColor": "Gold",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -30,
      "UseHeadPosition": true,
      "HideStackCount": true
    },
    {
      "BuffName": "player_aura_item_quantity",
      "DisplayName": "Quantity Bot",
      "Show": true,
      "TextColor": "Silver",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -60,
      "UseHeadPosition": true,
      "HideStackCount": true
    },
    {
      "BuffName": "stolen_mods_buff",
      "DisplayName": "HH",
      "Show": true,
      "TextColor": "Orange",
      "MinStacks": 1,
      "PositionX": 0,
      "PositionY": -90,
      "UseHeadPosition": true,
      "HideStackCount": false
    }
  ]
}
```

## Debuff Monitoring

```json
{
  "BuffSettings": [
    {
      "BuffName": "stolen_mods_buff",
      "DisplayName": "HH",
      "Show": true,
      "TextColor": "Orange",
      "MinStacks": 1,
      "PositionX": 0,
      "PositionY": -30,
      "UseHeadPosition": true,
      "HideStackCount": false
    },
    {
      "BuffName": "curse_elemental_weakness",
      "DisplayName": "Elemental Weakness",
      "Show": true,
      "TextColor": "Red",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -60,
      "UseHeadPosition": true,
      "HideStackCount": true
    },
    {
      "BuffName": "abyss_desecrated_ground",
      "DisplayName": "Desecrated Ground",
      "Show": true,
      "TextColor": "Purple",
      "MinStacks": 0,
      "PositionX": 0,
      "PositionY": -90,
      "UseHeadPosition": true,
      "HideStackCount": true
    }
  ]
}
```

## Fixed Position Setup

```json
{
  "BuffSettings": [
    {
      "BuffName": "stolen_mods_buff",
      "DisplayName": "HH",
      "Show": true,
      "TextColor": "Orange",
      "MinStacks": 1,
      "PositionX": 100,
      "PositionY": 100,
      "UseHeadPosition": false,
      "HideStackCount": false
    },
    {
      "BuffName": "player_aura_cold_resist",
      "DisplayName": "Cold Aura",
      "Show": true,
      "TextColor": "Cyan",
      "MinStacks": 0,
      "PositionX": 100,
      "PositionY": 130,
      "UseHeadPosition": false,
      "HideStackCount": true
    }
  ]
}
```

## Color Reference

Available colors for TextColor:
- `Red`, `Green`, `Blue`
- `Yellow`, `Cyan`, `Magenta`
- `Orange`, `Pink`, `Purple`
- `White`, `Black`, `Gray`
- `Gold`, `Silver`, `Bronze`
- `Lime`, `Aqua`, `Navy`
- `Maroon`, `Olive`, `Teal`

## Common Buff Names

### Headhunter
- `stolen_mods_buff`

### Auras (check in Presence)
- `player_aura_cold_resist`
- `player_aura_fire_resist`
- `player_aura_lightning_resist`
- `player_aura_chaos_resist`
- `player_aura_item_rarity`
- `player_aura_item_quantity`

### Presence Buffs
- `player_aura_cold_resist`
- `player_aura_fire_resist`
- `player_aura_lightning_resist`
- `player_aura_chaos_resist`

### Other Common Buffs
- `player_aura_accuracy`
- `player_aura_evasion`
- `player_aura_armour`
- `player_aura_energy_shield`
- `shrine_magicfind_2`

### Common Debuffs
- `curse_elemental_weakness`
- `curse_vulnerability`
- `curse_temporal_chains`
- `curse_enfeeble`
- `curse_assassin_mark`
- `curse_warlord_mark`
- `abyss_desecrated_ground`
