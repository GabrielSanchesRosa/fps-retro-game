using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] public bool playerAlive;

    void Awake() {
        instance = this;
    }

    void Start() {
        playerAlive = true;
    }

    void Update() {
        
    }

    public void GameOver() {
        playerAlive = false;

        Debug.Log("Game Over");
    }
}
