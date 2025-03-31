using UnityEngine;


public class CollectiblesItems : MonoBehaviour {
    [SerializeField] private bool ammoItem, lifeItem, silverKey, goldKey;
    [SerializeField] private int ammoQuantity, lifeQuantity;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (ammoItem) {
                other.gameObject.GetComponent<PlayerAttack>().AddAmmo(ammoQuantity);
            };

            if (lifeItem) {

            };

            if (silverKey) {

            };

            if (goldKey) {

            };

            Destroy(this.gameObject);
        }
    }
}

