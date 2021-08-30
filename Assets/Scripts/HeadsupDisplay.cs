using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeadsupDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform levelNumber;
    public Transform nextLevelNumber;
    public Transform Score;

    public Transform bestScore;
    public Transform Comment;

    public Transform progressBar;
    private NearMiss nearMiss;
    void OnEnable()
    {
        Playaa.OnCloseCall += DisplayNearMiss;
        GameManager.OnLevelStart += TweenLevelNumber;
        GameManager.OnLevelStart+=SetDynamicScorePos;
        GameManager.OnLevelStart+=SetHighScore;
       // GameManager.OnPlayerDead+=TweenLevelNumber;
        GameManager.OnLevelStart();
        Comment.GetComponent<TMP_Text>().canvasRenderer.SetAlpha(0f);

    }

    // Update is called once per frame
    void Update()
    {
        
         levelNumber.GetComponent<TMP_Text>().text=GameManager.CurrentLevelNumber.ToString();
         Score.GetComponent<TMP_Text>().SetText(Mathf.Round(GameManager.Instance.CurrentScore).ToString());
         nextLevelNumber.GetComponent<TMP_Text>().SetText((GameManager.CurrentLevelNumber+1).ToString());
        

    }

    public void DisplayNearMiss()
    {

        if (Comment != null)
        {
            Comment.GetComponent<TMP_Text>().canvasRenderer.SetAlpha(1f);
            Comment.GetComponent<RectTransform>().LeanSetPosY(Screen.height / 2f + 250f);

            //Instantiate(Comment, new Vector3(0, 0, 0), Quaternion.identity);
            Comment.GetComponent<TMP_Text>().SetText("Near Miss!! +3");
            LeanTween.moveY(Comment.GetComponent<RectTransform>(), -150f, 0.4f).setEaseInOutSine();
            Debug.Log("<color=blue>" + "NEAR MISS!!" + "</color>");


            Comment.GetComponent<TMP_Text>().CrossFadeAlpha(0f, 0.5f, true);



        }

        //StartCoroutine(DisplayText());
    }

    public void TweenLevelNumber()
    {
        if (levelNumber != null)
        {
            Debug.Log(Screen.width+" "+ Screen.height);
           
           //nextLevelNumber.GetComponent<RectTransform>().LeanSetPosX(progressBar.GetComponent<RectTransform>().localPosition.x+10f);

           nextLevelNumber.GetComponent<RectTransform>().LeanSetLocalPosX(progressBar.GetComponent<RectTransform>().rect.width/2f+5f);
           nextLevelNumber.GetComponent<RectTransform>().LeanSetLocalPosY(Screen.height/2f-13f);

            //levelNumber.GetComponent<RectTransform>().localPosition= new Vector2(-Screen.width ,-Screen.height/2f);
            levelNumber.GetComponent<RectTransform>().LeanSetPosY(Screen.height/2f);
           levelNumber.GetComponent<RectTransform>().LeanSetPosX(Screen.width / 2f);
            levelNumber.GetComponent<RectTransform>().localScale = new Vector3(5f, 5f, 5f);
            
            LeanTween.moveY(levelNumber.GetComponent<RectTransform>(),/*Screen.height-levelNumber.GetComponent<RectTransform>().rect.height*/-levelNumber.GetComponent<RectTransform>().rect.height+12f, 0.5f).setEaseInOutSine().setDelay(0.8f);
             LeanTween.moveX(levelNumber.GetComponent<RectTransform>(), progressBar.GetComponent<RectTransform>().localPosition.x-progressBar.GetComponent<RectTransform>().rect.width/2f-10f, 0.5f).setEaseInOutSine().setDelay(0.8f);
            LeanTween.scale(levelNumber.GetComponent<RectTransform>(), new Vector3(1f, 1f, 1f), 0.5f).setEaseInOutSine().setDelay(0.8f);

            
        }


    }

    public void SetDynamicScorePos()
    {
        if(Score!=null)
        {
            //Score.GetComponent<RectTransform>().rect.Set(0f,0f,Screen.width*(7.8f/100f),Screen.height*(50f/100f));
            Score.GetComponent<RectTransform>().LeanSetLocalPosY(Screen.height/2-Score.GetComponent<RectTransform>().rect.height/2f);
            Score.GetComponent<RectTransform>().LeanSetLocalPosX(Screen.width/2-Score.GetComponent<RectTransform>().rect.width/2f);
            
        }

        if(bestScore!=null)
        {

            bestScore.GetComponent<RectTransform>().LeanSetLocalPosY(Screen.height/2-bestScore.GetComponent<RectTransform>().rect.height/2f);
            bestScore.GetComponent<RectTransform>().LeanSetLocalPosX(-Screen.width/2+bestScore.GetComponent<RectTransform>().rect.width/2f);


        }


    }

    public IEnumerator DisplayText()
    {


        if (Comment != null)
        {
            Comment.GetComponent<RectTransform>().LeanSetPosY(Screen.height / 2f);
            yield return null;
            //Instantiate(Comment, new Vector3(0, 0, 0), Quaternion.identity);
            Comment.GetComponent<TMP_Text>().SetText("Near Miss!!");
            LeanTween.moveY(Comment.GetComponent<RectTransform>(), -150f, 0.5f);
            Debug.Log("<color=blue>" + "NEAR MISS!!" + "</color>");

        }

        yield return new WaitForSeconds(1f);

        Comment.GetComponent<TMP_Text>().text = "";

    }

    public void SetHighScore()
    {

        float temp =PlayerPrefs.GetFloat("HighScore",GameManager.Instance.BestScore);

         bestScore.GetComponent<TMP_Text>().SetText("Best:"+"\n"+Mathf.Round(temp).ToString());
    }



    void OnDisable()
    {
        Playaa.OnCloseCall -= DisplayNearMiss;
        GameManager.OnLevelStart -= TweenLevelNumber;
        GameManager.OnLevelStart-=SetDynamicScorePos;
        GameManager.OnLevelStart-=SetHighScore;
        // GameManager.OnPlayerDead-=TweenLevelNumber;

    }
}
