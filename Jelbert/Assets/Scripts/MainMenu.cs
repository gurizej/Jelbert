using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{    
    GameObject unmuteObject;

    void Start() {
        unmuteObject = GameObject.Find("Unmute");
    }

    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

    public void ControlsScene() {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ToggleMute() {
        if(unmuteObject.active) {
            unmuteObject.SetActive(false);
        } else {
            unmuteObject.SetActive(true);
        }
    }
}
