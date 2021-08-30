using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RetryUI : MonoBehaviour
{
    public Transform subPanel;
    public Transform retryButton;
    public Transform quitButton;

    public TMP_Text currentScore;
    public TMP_Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        // transform.GetComponent<CanvasRenderer>().SetAlpha(0f);
        
        
        
    }

    void OnEnable()
    {
       

        GameManager.OnPlayerDead+=RunGameOverScreenTween;
        GameManager.OnLevelStart+= GameManager.Instance.ResetCurrentScore;
        GameManager.OnPlayerDead+=DisplayScores;
        GameManager.OnPlayerDead();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
            

        
       

       
    }

    public void DisplayScores()
    {
        currentScore.SetText("Your Score:"+ Mathf.Round(GameManager.Instance.CurrentScore).ToString());
        highScore.SetText("Best Score:"+ Mathf.Round(PlayerPrefs.GetFloat("HighScore")).ToString());


    }

    public void RunGameOverScreenTween()
    {

        subPanel.GetComponent<RectTransform>().LeanSetLocalPosY(Screen.height+50f);
        retryButton.GetComponent<RectTransform>().LeanSetLocalPosX(-retryButton.GetComponent<RectTransform>().rect.width*4f);
        quitButton.GetComponent<RectTransform>().LeanSetLocalPosX(quitButton.GetComponent<RectTransform>().rect.width*4f);
      
        LeanTween.moveY(subPanel.GetComponent<RectTransform>(),0f,0.3f).setEaseLinear().setDelay(0.2f);
        LeanTween.moveX(retryButton.GetComponent<RectTransform>(),0f,0.3f).setEaseLinear().setDelay(0.8f);
        LeanTween.moveX(quitButton.GetComponent<RectTransform>(),0f,0.3f).setEaseLinear().setDelay(0.8f);
       

    }

    
    void OnDisable()
    {
        GameManager.OnPlayerDead-=RunGameOverScreenTween;
        GameManager.OnLevelStart-= GameManager.Instance.ResetCurrentScore;
        GameManager.OnPlayerDead-=DisplayScores;

    }

    public void RestartLevel()
    {
        Debug.Log("RestartLevel");
        LevelGenerator.sessionStarted=false;
        GameManager.OnLevelStart();

    }

    public void Quit()
    {

        Debug.Log("Back to main meny");
        GameManager.CurrentLevelNumber=0;
        LevelGenerator.sessionStarted=false;
        GameManager.OnGameStart();
    }
}
