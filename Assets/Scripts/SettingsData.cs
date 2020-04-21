using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsData : MonoBehaviour {

    public int gameplayMode;
    public float volume;
    public int winPoints;
    public Text highScoreTxt;
    public int score;

    //public int highScore;

    private void Start()
    {

        score = SceneChanger.wallScoreNum;
        SettingDataManager();

        highScoreTxt.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    
    }

    public void SettingDataManager()
    {       

        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);        
        }
      
    }
	
}
