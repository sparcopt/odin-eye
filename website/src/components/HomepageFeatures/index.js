import styles from './styles.module.css';

import Api from '@site/static/img/api.svg';
import Events from '@site/static/img/events.svg';
import Install from '@site/static/img/install.svg';

export default function HomepageFeatures() {
  return (
    <div className="container">
      <div className={styles.gallery}>
        <div className={styles.card}>
          <div className={styles.cardheader}>
            <Install className={styles.featureSvg}/>
            <h4>Seamless integration</h4>
          </div>
          <p>Install the plugin and extend your server's capabilities in just a few minutes. Unlock new integration possibilities.</p>
        </div>
        <div className={styles.card}>
          <div className={styles.cardheader}>
            <Api className={styles.featureSvg}/>
            <h4>Game server API</h4>
          </div>
          <p>Use the provided REST API to query game server data such as player info, boss progression and game world details.</p>
        </div>
        <div className={styles.card}>
          <div className={styles.cardheader}>
            <Events className={styles.featureSvg}/>
            <h4>Game events</h4>
          </div>
          <p>Stay updated with live, in-game events as they occur. Build interactive client applications that mirror the game actions.</p>
        </div>
      </div>
    </div>
  );
}
