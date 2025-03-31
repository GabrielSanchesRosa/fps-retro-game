using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int projectileDamage;

    void Start() {
        
    }

    void Update() {
        moveEnemyProjectile();
    }

    private void moveEnemyProjectile() {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerLife>().HitPlayer(projectileDamage);
        }

        Destroy(this.gameObject);
    }
}
