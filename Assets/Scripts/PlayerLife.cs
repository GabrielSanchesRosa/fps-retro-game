using UnityEngine;

public class PlayerLife : MonoBehaviour {
    [SerializeField] private int maxLife;
    [SerializeField] private int life;

    void Start() {
        
    }

    void Update() {
        
    }

    public void HitPlayer(int damage) {
        if (GameManager.instance.playerAlive) {
            life -= damage;

            if (life <= 0) {
                GameManager.instance.GameOver();
            }
        }
    }
}
