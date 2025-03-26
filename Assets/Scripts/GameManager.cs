using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] private bool playerAlive;

    void Awake() {
        instance = this;
    }

    void Update() {
        
    }
}
