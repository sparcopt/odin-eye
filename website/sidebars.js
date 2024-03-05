// @ts-check

/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  docsSidebar: [
    {
      type: "doc",
      id: "intro",
    },
  ],
  apiSidebar: [
    {
      type: "category",
      label: "API Reference",
      link: {
        type: "generated-index",
        title: "API Reference",
        description:
          "This is a sample server Petstore server. You can find out more about Swagger at http://swagger.io or on irc.freenode.net, #swagger. For this sample, you can use the api key special-key to test the authorization filters.",
        slug: "/category/api-reference",
      },
      items: require("./docs/api-reference/sidebar.ts"),
    },
  ],
  
};

export default sidebars;
