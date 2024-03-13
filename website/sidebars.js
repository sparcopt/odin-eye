// @ts-check

/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  docsSidebar: [
    {
      type: "doc",
      id: "intro",
    },
    {
      type: "category",
      label: "Getting Started",
      link: {
        type: "generated-index",
      },
      collapsed: false,
      items: [
        "getting-started/installation",
        // 'configuration',
        // 'playground',
        // 'typescript-support',
      ],
    },
    {
      type: "category",
      label: "API Reference",
      collapsed: false,
      link: {
        type: "generated-index",
        title: "API Reference",
        slug: "/category/api-reference",
      },
      items: require("./docs/api-reference/sidebar.ts"),
    },
    {
      type: "category",
      label: "Events",
      link: {
        type: "generated-index",
      },
      collapsed: false,
      items: [
        "events/intro"
      ],
    }
  ]
  
};

export default sidebars;
