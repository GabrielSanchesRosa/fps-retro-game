using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    [SerializeField] private float projectileSpeed;

    void Start() {
        
    }

    void Update() {
        moveEnemyProjectile();
    }

    private void moveEnemyProjectile() {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
