using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    GameObject _boss;
    UbhEmitter _Emitter;
    UbhEnemy _Enemy;
    LevelSelection _Selection;
    int currentWave;
    int totalWave;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        _Emitter = FindObjectOfType<UbhEmitter>();
        _Enemy = FindObjectOfType<UbhEnemy>();
        _Selection = FindObjectOfType<LevelSelection>();
        //this checks for current level
        if (SceneManager.GetActiveScene().name == "Level_2_Sea_Of_Rage") {
            level = 2;
        } else if (SceneManager.GetActiveScene().name == "Level_1_Eden_of_Denialv2") {
            level = 1;
        }
        Debug.Log("Level:" + level);
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = _Emitter.CurrentWave;
        totalWave = _Emitter.TotalWave;
        _boss = GameObject.FindGameObjectWithTag("Boss");
        // this checks if boss is dead at boss stage
        if(currentWave == totalWave) {
            if(_boss == null){
                Debug.Log("End game");
                if (level == 1) {
                } else if (level == 2) {
                }
            }
        }
        
    }
}
