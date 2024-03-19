---
id: event-types
description: "OdinEye Event types"
sidebar_label: Event types
---

# Event types

Events are categorized into two different types:

- General game events
- Recurrent events

### General game events

These types of events signify actions or changes within the game world. They can be triggered by players' actions or by the game instance itself.
Some exemples of these include:
- Player joining a server
- Player going to sleep
- The start of the evening
- The start of a new day


Use cases for consuming game events include storing and browsing events, as well as executing custom logic when a specific event occurs, such as posting information to a Discord channel.

### Recurrent events

Recurrent events are snapshots of game statistics taken at regular intervals (defaulting to one second). These events include data regarding the current online players and various properties of the game world.  
Use cases for consuming recurrent events include user interfaces that continuously update to display current player health and stamina values.

## Diagram

```mermaid
classDiagram

Message <|-- GameEvent
GameEvent *-- EventType
GameEvent *-- Player
Message <|-- GameStatsSnapshot
GameStatsSnapshot *-- PlayerStats
GameStatsSnapshot *-- WorldStats

class Message{
    +createdDate: Date
}

class GameEvent{
    +message: String
    +type: EventType
    +player: Player
    +data: Dictionary~string,object~
}

class Player{
    +id: UUID
    +characterId: String
    +steamId: String
    +name: String
    +health: float
    +maxHealth: float
    +stamina: float
}

class EventType{
    Unknown
    PlayerJoin
    PlayerSpawn
    PlayerDeath
    PlayerDisconnect
    PlayerChat
    PlayersSleepStart
    PlayerSleepStop
    GameAwake
    GameQuit
    WorldLoad
    WorldSave
    ServerShutdown
    GlobalKeyAdd
    GlobalKeyRemove
    RandomEventActivate
    RandomEventDeactivate
    RandomEventSet
    EnvironmentMorningStart
    EnvironmentEveningStart
}

class GameStatsSnapshot{
    +playerStats: PlayerStats[]
    +worldStats: WorldStats
}

class PlayerStats{
    +id: UUID
    +characterId: String
    +health: float
    +maxHealth: float
    +stamina: float
}

class WorldStats{
    +dayNumber: int
    +dayCycle: String
}
```