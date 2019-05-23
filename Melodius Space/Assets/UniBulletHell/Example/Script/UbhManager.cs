using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UbhManager : UbhMonoBehaviour
{
    public const int BASE_SCREEN_WIDTH = 600;
    public const int BASE_SCREEN_HEIGHT = 450;
    public bool _ScaleToFit = false;
    [SerializeField]
    GameObject _PlayerPrefab;
    [SerializeField]
    GameObject _GoTitle;
    [SerializeField]
    GameObject _GoLetterBox;
    [SerializeField]
    GameObject _RestartGame;
    [SerializeField]
    UbhScore _Score;
    bool restart;

    void Start ()
    {
        _GoLetterBox.SetActive(!_ScaleToFit);
        restart = false;
         _RestartGame.SetActive(false);
    }

    void Update ()
    {
        if (restart == true) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (Input.GetKeyDown(KeyCode.M)) {
                SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
            }
        }
        
        if (UbhUtil.IsMobilePlatform()) {
            /*
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch (i);

                if (IsPlaying () == false && touch.phase == TouchPhase.Began) {
                    GameStart ();
                }
            }
            */
            if (IsPlaying() == false && Input.GetMouseButtonDown(0)) {
                GameStart();
            }

        } else {
            if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X) && restart == false) {
                GameStart();
            }
        }
    }

    void GameStart ()
    {
        if (_Score != null) {
            _Score.Initialize();
        }
        if (_GoTitle != null) {
            _GoTitle.SetActive(false);
        }
        if (_RestartGame != null) {
            _RestartGame.SetActive(false);
        }

        CreatePlayer();
    }

    public void GameOver ()
    {
        restart = true;
        _RestartGame.SetActive(true);
        _GoLetterBox.SetActive(false);
        if (_Score != null) {
            _Score.Save();
        } 
        else {
            // for UBH_ShotShowcase scene.
            CreatePlayer();
        }
    }

    void CreatePlayer ()
    {
        Instantiate(_PlayerPrefab, _PlayerPrefab.transform.position, _PlayerPrefab.transform.rotation);
    }

    public bool IsPlaying ()
    {
        if (_GoTitle != null) {
            return _GoTitle.activeSelf == false;
        } else {
            // for UBH_ShotShowcase scene.
            return true;
        }
    }
}
