using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {
    [SerializeField] private Text lifeText;

    [SerializeField] private int maxLife;
    [SerializeField] private int life;

    void Start() {
        UpdateLife(life);
    }

    void Update() {
        
    }

    public void HitPlayer(int damage) {
        if (GameManager.instance.playerAlive) {
            life -= damage;
            UpdateLife(life);

            if (life <= 0) {
                GameManager.instance.GameOver();
            }
        }
    }

    private void UpdateLife(int life) {
        lifeText.text = "LIFE\n" + life;
    }

    public void AddLife(int collectedLife) {
        if (collectedLife + life < maxLife) {
            life += collectedLife;
        } else {
            life = maxLife;
        }

        UpdateLife(life);
    }
}
