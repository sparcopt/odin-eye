---
id: intro
description: "Learn how to use the OdinEye Events"
sidebar_label: Introduction
sidebar_position: 0
hide_title: true
custom_edit_url: null
---

# Introduction

The OdinEye events capture a variety of in-game actions and activities initiated by players and the game world. These events are then enriched with data and delivered as a continuous stream. For example, the event stream can be used to track players joining the server, when the day changes or when the game is saved.  
The event stream is provided through a WebSocket connection and event payloads are serialized with [protobuf](https://protobuf.dev/).

## Base URL


```
ws://localhost:3000/activity
```

:::info[Important]
The activity path (`/activity`) must be included. 
:::

When establishing a WebSocket connection, the base URL (including the port) should be changed accordingly, matching the <b>domain</b> that is being used for the game server and the <b>port</b> where OdinEye is running.

## Authentication

:::note
Authentication has not been implemented at this time.
:::

Upon implementation, the event stream will utilize [API Keys](https://en.wikipedia.org/wiki/API_key) as the default authentication method. Subsequently, this documentation will be revised to include the necessary instructions.

## Versioning

The OdinEye API is versioned. The API version name is based on the date when the API version was released. For example, the API version 2022-11-28 was released on Mon, 28 Nov 2022.

Any breaking changes will be released in a new API version. Breaking changes are changes that can potentially break an integration
