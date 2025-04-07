using UnityEngine;


public class CollectiblesItems : MonoBehaviour {
    [SerializeField] private bool ammoItem, lifeItem, silverKey, goldKey;
    [SerializeField] private int ammoQuantity, lifeQuantity;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (ammoItem) {
                other.gameObject.GetComponent<PlayerAttack>().AddAmmo(ammoQuantity);
                SoundEffects.instance.PlaySoundEffects("ammoCollected");
            };

            if (lifeItem) {
                other.gameObject.GetComponent<PlayerLife>().AddLife(lifeQuantity);
                SoundEffects.instance.PlaySoundEffects("lifeCollected");
            };

            if (silverKey) {
                GameManager.instance.haveSilverKey = true;
                SoundEffects.instance.PlaySoundEffects("keyCollected");
            };

            if (goldKey) {
                GameManager.instance.haveGoldenKey = true;
                SoundEffects.instance.PlaySoundEffects("keyCollected");
            };

            Destroy(this.gameObject);
        }
    }
}

