using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

    public Text scorePlayertxt;
    public Text scoreEnemytxt;
    public Text scoreWall;
    //public AudioSource audioScore;

    int scorePlayerCount;
    int scoreEnemyCount;
    int winCondition;

    static public int scoreWallCount;
   
    string sceneName;
    public SceneChanger sceneChanger;

    private void Start()
    {
        winCondition = SceneChanger.winPoints;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "WallMode" || sceneName == "WallModeR")
        {
            if(scoreWallCount > 0)
            {
                scoreWallCount = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D ball)
    {
        /*
         Existe el GameObject con "G" y el gameObject con "g". 
         con "G" se refiere al tipo de dato. 
         con "g" se refiere a la variable.
         ----------------------------------------
         gameObject.CompareTag() hace la mismas función que gameObject.tag == "".
         */
        if (gameObject.tag == "playerWall") 
        {
            scoreEnemyCount++;
            UpdateScoreLabel(scoreEnemytxt, scoreEnemyCount);
        }
        else if(gameObject.CompareTag("enemyWall"))
        {
            scorePlayerCount++;
            UpdateScoreLabel(scorePlayertxt, scorePlayerCount);
        }
        else if(gameObject.tag == "loseWall")
        {
            sceneChanger.ChangeSceneTo("WinWallMode");
        }

        ball.GetComponent<BallBehaviour>().gameStarted = false;
        ball.GetComponent<BallBehaviour>().audioScore.Play();
        checkScore();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(sceneName == "WallMode" || sceneName == "WallModeR")
        {
                scoreWallCount++;
                UpdateScoreLabel(scoreWall, scoreWallCount);
        }
    }

    void checkScore()
    {
        if(scorePlayerCount >= winCondition)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if(scoreEnemyCount >= winCondition)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }
    
    void UpdateScoreLabel (Text label, int score)
    {
        label.text = score.ToString();
    }
}
