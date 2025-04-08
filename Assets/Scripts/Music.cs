using UnityEngine;

public class Music : MonoBehaviour {
    [SerializeField] private AudioSource levelMusic, gameOverMusic;


    void Start() {
        PlayMusic("level");
    }

    public void PlayMusic(string music) {
        if (music.Equals("level")) {
            levelMusic.Play();
        } else {
            levelMusic.Stop();
            gameOverMusic.Play();
        }
    }
}
