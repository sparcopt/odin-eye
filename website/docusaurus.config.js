const { DOCUSAURUS_VERSION } = require("@docusaurus/utils");

import {themes as prismThemes} from 'prism-react-renderer';

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: 'OdinEye',
  tagline: 'OdinEye yea',
  favicon: 'img/favicon.ico',
  url: 'https://sparcopt.github.io/',
  baseUrl: '/odin-eye/',
  organizationName: 'sparcopt',
  projectName: 'odin-eye',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  i18n: {
    defaultLocale: 'en',
    locales: ['en'],
  },

  presets: [
    [
      'classic',
      /** @type {import('@docusaurus/preset-classic').Options} */
      ({
        docs: {
          sidebarPath: './sidebars.js',
          docRootComponent: "@theme/DocRoot",
          docItemComponent: "@theme/ApiItem"
        },
        theme: {
          customCss: './src/css/custom.css',
        },
      }),
    ],
  ],

  themeConfig:
    /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
    ({
      docs: {
        sidebar: {
          hideable: true,
        },
      },
      colorMode: {
        defaultMode: 'dark'
      },
      image: 'img/odineye.png',
      navbar: {
        title: 'OdinEye',
        logo: {
          alt: 'My Site Logo',
          src: 'img/odineye.png',
        },
        items: [
          {
            type: 'docSidebar',
            sidebarId: 'docsSidebar',
            position: 'left',
            label: 'Docs',
          },
          {
            href: 'https://github.com/sparcopt/odin-eye',
            className: "header-github-link",
            position: 'right',
            "aria-label": "GitHub repository",
          },
        ],
      },
      footer: {
        style: 'dark',
        links: [
          {
            title: 'Docs',
            items: [
              {
                label: 'Installation',
                to: '/docs/getting-started/installation',
              },
              {
                label: 'API Reference',
                to: '/docs/api-reference/intro',
              },
              {
                label: 'Events',
                to: '/docs/events/intro',
              },
            ],
          },
          {
            title: 'Game',
            items: [
              {
                label: 'Valheim',
                href: 'https://www.valheimgame.com/',
              }
            ],
          },
          {
            title: 'More',
            items: [
              {
                label: 'GitHub',
                href: 'https://github.com/sparcopt/odin-eye',
              },
            ],
          },
        ],
        copyright: `Copyright © ${new Date().getFullYear()} OdinEye. Built with Docusaurus ${DOCUSAURUS_VERSION}.`,
      },
      prism: {
        theme: prismThemes.github,
        darkTheme: prismThemes.dracula,
      },
    }),

    plugins: [
      [
        "docusaurus-plugin-openapi-docs",
        {
          id: "openapi",
          docsPluginId: "classic",
          config: {
            petstore: {
              specPath: "specs/",
              outputDir: "docs/api-reference",
              sidebarOptions: {
                groupPathsBy: "tag",
                categoryLinkSource: "tag",
              },
            }
          }
        },
      ]
    ],

    markdown: {
      mermaid: true,
    },

    themes: ["docusaurus-theme-openapi-docs", "@docusaurus/theme-mermaid"]
};


export default config;
