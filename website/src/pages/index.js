import clsx from 'clsx';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import Layout from '@theme/Layout';
import HomepageFeatures from '@site/src/components/HomepageFeatures';

import Heading from '@theme/Heading';
import styles from './index.module.css';

function HeroBanner() {
  return (
    <div className={styles.hero} data-theme="dark">
      <div className={styles.heroInner}>
        <Heading as="h1" className={styles.heroProjectTagline}>
          <img
            alt="Docusaurus with Keytar"
            className={styles.heroLogo}
            src="./img/odineye.png"
            width="200"
            height="200"
          />
          <span
            className={styles.heroTitleTextHtml}
            // eslint-disable-next-line react/no-danger
            dangerouslySetInnerHTML={{
              __html: '<b>Seamlessly</b> expose your Valheim server data through a user-friendly <b>REST API</b> and <b>real time events</b>'
            }}
          />
        </Heading>
        <div className={styles.indexCtas}>
          <Link className="button button--primary" to="/docs/intro">
            Get Started
          </Link>
          {/* Add button to mod website in the future! */}
          <Link className="button button--info" to="https://docusaurus.new" style={{visibility: "hidden"}}>
            Mod link
          </Link>
        </div>
      </div>
    </div>
  );
}

export default function Home() {
  const {siteConfig} = useDocusaurusContext();
  return (
    <Layout
      title={`Seamlessly expose your Valheim server data`}
      description="Description will go into a meta tag in <head />">
      {/* <HomepageHeader /> */}
      <HeroBanner />
      <main>
        <HomepageFeatures />
      </main>
    </Layout>
  );
}
