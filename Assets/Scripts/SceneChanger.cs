using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    static public float Dificulty;
    static public int gameplaySetting = 0;
    static public int winPoints = 3;
    public AudioMixer audioMixer;
    public Text wallModeScore;
    static public int wallScoreNum;
    static public string sceneNameActive;
    public SettingsData scoreCheck;

    private void Start()
    {
        wallScoreNum = DeathZone.scoreWallCount;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneNameActive = currentScene.name;
    }

    private void Update()
    {
        if (sceneNameActive == "WinWallMode")
        {
            UpdateScoreLabel(wallModeScore, wallScoreNum);
        }
    }

    public void ChangeSceneTo(string sceneName)
    {

        if (sceneName == "SampleSceneE")
        {
            if (gameplaySetting == 0)
            {
                sceneName = "SampleScene";
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                sceneName = "SampleSceneR";
                SceneManager.LoadScene(sceneName);
            }
            Dificulty = 0.12f;
        }
        else if(sceneName == "SampleSceneNE")
        {
            if (gameplaySetting == 0)
            {
                sceneName = "SampleScene";
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                sceneName = "SampleSceneR";
                SceneManager.LoadScene(sceneName);
            }
            Dificulty = 0.2f;
        }
        else if (sceneName == "SampleSceneH")
        {
            if (gameplaySetting == 0)
            {
                sceneName = "SampleScene";
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                sceneName = "SampleSceneR";
                SceneManager.LoadScene(sceneName);
            }
            Dificulty = 0.28f;
        }
        else if (sceneName == "WallMode")
        {
            scoreCheck.SettingDataManager();
            if (gameplaySetting == 0)
            {
                sceneName = "WallMode";
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                sceneName = "WallModeR";
                SceneManager.LoadScene(sceneName);
            }
           
        }
        else if (sceneName == "Left")
        {
            gameplaySetting = 0;
        }
        else if (sceneName == "Right")
        {
            gameplaySetting = 1;
        }       
        else
        {
            if(gameplaySetting == 0 && sceneName == "SampleScene")
            {               
                SceneManager.LoadScene(sceneName);
            }
            else if (gameplaySetting == 1 && sceneName == "SampleScene")
            {
                sceneName = "SampleSceneR";
                SceneManager.LoadScene(sceneName);
            }

            SceneManager.LoadScene(sceneName);
        }
        
    }
    

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Se ah cerrado el juego.");
    }

    public void winManager(int points)
    {
        if (points == 0)
        {
            winPoints = 3;
        }else if(points == 1)
        {
            winPoints = 6;
        }
        else if (points == 2)
        {
            winPoints = 10;
        }
        else if (points == 3)
        {
            winPoints = 16;
        }

    }

    public void SetVolumen(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}
