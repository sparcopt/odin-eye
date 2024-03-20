<p align="center">
  <img src="docs/odineye.png" height="128">
  <h2 align="center">OdinEye</h2>
  <p align="center">Valheim Server plugin that provides game server data through a REST API and WebSockets.<p>
  <p align="center">
    <img src="https://img.shields.io/github/last-commit/sparcopt/odin-eye">
    <a href="https://www.nuget.org/packages/OdinEye.Models">
      <img src="https://img.shields.io/nuget/vpre/OdinEye.Models?label=NuGet%20beta"></a>
    <a href="https://github.com/sparcopt/odin-eye/actions/workflows/build-main.yaml" >
      <img alt="GitHub Workflow Status (with event)" src="https://img.shields.io/github/actions/workflow/status/sparcopt/odin-eye/build-main.yaml?label=main"></a>
    <a href="https://github.com/sparcopt/odin-eye/actions/workflows/build-pr.yaml" >
      <img alt="GitHub Workflow Status (with event)" src="https://img.shields.io/github/actions/workflow/status/sparcopt/odin-eye/build-pr.yaml?label=pull%20request"></a>
  </p>
</p>

> [!IMPORTANT]
> This project is currently under development. Beta versions are accessible and ready for use, but please note that breaking changes may be implemented without prior notice.

## ℹ️ Overview

OdinEye is a free, open-source Valheim server plugin that exposes server and gameplay data. The plugin provides a public REST API, enabling consumers to access relevant information about the dedicated server instance, including details like current online players and boss progression. In addition to this, in-game events like player actions or raids, and periodic data such as player stats, are also accessible as a stream of events through WebSockets.

## ✨ Features

- **Seamless integration**
  - Install the plugin and extend your server's capabilities in just a few minutes. Unlock new integration possibilities
- **Game server API**
  - Use the provided REST API to query game server data such as player info, boss progression and game world details
- **Game events**
  - Stay updated with live, in-game events as they occur. Build interactive client applications that mirror the game actions
 
## 📦 Getting started

Installation instructions are available at: [Installation](https://sparcopt.github.io/odin-eye/docs/getting-started/installation)

## 📨 API

Learn more about the API and how to use it: [API Reference](https://sparcopt.github.io/odin-eye/docs/category/api-reference)

## ⚡ Events

Learn more about the game events and how to use them: [Events](https://sparcopt.github.io/odin-eye/docs/category/events)
