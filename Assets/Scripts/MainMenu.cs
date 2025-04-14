using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string levelName;

    void Start() {
        Time.timeScale = 1.0f;
    }

    public void StartGame() {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
