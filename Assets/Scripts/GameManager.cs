using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] public bool playerAlive = true, haveSilverKey = false, haveGoldenKey = false;

    void Awake() {
        instance = this;
    }

    void Start() {
        playerAlive   = true;
        haveSilverKey = false;
        haveGoldenKey = false;
    }

    void Update() {
        
    }

    public void GameOver() {
        playerAlive = false;

        Debug.Log("Game Over");
    }
}
