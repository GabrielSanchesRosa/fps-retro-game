using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] GameObject pausePanel;
    [SerializeField] public bool playerAlive, haveSilverKey, haveGoldenKey;

    void Awake() {
        instance = this;
    }

    void Start() {
        playerAlive   = true;
        haveSilverKey = false;
        haveGoldenKey = false;

        Time.timeScale = 1f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void PauseGame() {
        if (!pausePanel.activeSelf) {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        } else {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
        }
    }

    public void GameOver() {
        playerAlive = false;
        FindAnyObjectByType<Music>().PlayMusic("Game Over");
        Debug.Log("Game Over");
    }
}
