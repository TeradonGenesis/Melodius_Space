using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevelOne() {
        SceneManager.LoadScene("Level_1_Eden_Of_Denialv2",LoadSceneMode.Single);
    }

    public void LoadLevelTwo() {
        SceneManager.LoadScene("Level_2_Sea_Of_Rage",LoadSceneMode.Single);
    }

    public void LoadLevelThree() {
        Debug.Log("Level 3 loaded");
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1,LoadSceneMode.Single);
    }
}
