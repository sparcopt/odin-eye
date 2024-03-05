import type { SidebarsConfig } from "@docusaurus/plugin-content-docs";

const sidebar: SidebarsConfig = {
  apisidebar: [
    {
      type: "doc",
      id: "api-reference/sample-api",
    },
    {
      type: "category",
      label: "Users",
      link: {
        type: "doc",
        id: "api-reference/user",
      },
      items: [
        {
          type: "doc",
          id: "api-reference/returns-a-list-of-users",
          label: "Returns a list of users.",
          className: "api-method get",
        },
      ],
    },
  ],
};

export default sidebar.apisidebar;
