import type { SidebarsConfig } from "@docusaurus/plugin-content-docs";

const sidebar: SidebarsConfig = {
  apisidebar: [
    {
      type: "category",
      label: "Bosses",
      link: {
        type: "doc",
        id: "api-reference/boss",
      },
      items: [
        {
          type: "doc",
          id: "api-reference/list-all-bosses",
          label: "List all bosses",
          className: "api-method get",
        },
      ],
    },
    {
      type: "category",
      label: "Players",
      link: {
        type: "doc",
        id: "api-reference/player",
      },
      items: [
        {
          type: "doc",
          id: "api-reference/list-all-players",
          label: "List all players",
          className: "api-method get",
        },
      ],
    },
    {
      type: "category",
      label: "Server",
      link: {
        type: "doc",
        id: "api-reference/server",
      },
      items: [
        {
          type: "doc",
          id: "api-reference/retrieve-game-server-info",
          label: "Retrieve game server info",
          className: "api-method get",
        },
      ],
    },
    {
      type: "category",
      label: "World",
      link: {
        type: "doc",
        id: "api-reference/world",
      },
      items: [
        {
          type: "doc",
          id: "api-reference/retrieve-game-world-info",
          label: "Retrieve game world info",
          className: "api-method get",
        },
      ],
    },
  ],
};

export default sidebar.apisidebar;
