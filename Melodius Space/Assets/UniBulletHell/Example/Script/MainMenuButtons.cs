using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void QuitGame () {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
