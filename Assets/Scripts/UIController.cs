using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Canvas canvas;
    public HeadsupDisplay headsupDisplayPrefab;

    public MainMenu mainMenuPrefab;

    public RetryUI retryPrefab;

    [HideInInspector]
    public GameObject HUD;

    [HideInInspector]
    public GameObject MainMenu;

    [HideInInspector]

    public GameObject RetryPanel;
    // Start is called before the first frame update
    void Awake()
    {
        canvas= FindObjectOfType<Canvas>();
        HeadsupDisplay currentHUD =FindObjectOfType<HeadsupDisplay>();
        MainMenu currentMainMenu= FindObjectOfType<MainMenu>();
        RetryUI currentRetryUI= FindObjectOfType<RetryUI>();
        if(currentHUD==null)
        {

            currentHUD =Instantiate<HeadsupDisplay>(headsupDisplayPrefab);
            currentHUD.gameObject.transform.SetParent(canvas.transform);
            
            currentHUD.transform.GetComponent<RectTransform>().offsetMax= Vector2.zero;
        }

         if(currentMainMenu==null)
        {

            currentMainMenu =Instantiate<MainMenu>(mainMenuPrefab);
            currentMainMenu.gameObject.transform.SetParent(canvas.transform);
            currentMainMenu.gameObject.transform.SetAsFirstSibling();
            MainMenu=currentMainMenu.gameObject;
            
            currentMainMenu.transform.GetComponent<RectTransform>().offsetMax= Vector2.zero;
        }
        if(currentRetryUI==null)
        {
            currentRetryUI =Instantiate<RetryUI>(retryPrefab);
            currentRetryUI.gameObject.transform.SetParent(canvas.transform);
            currentRetryUI.transform.GetComponent<RectTransform>().offsetMax= Vector2.zero;
            
            


        }

            
            
    }

    // Update is called once per frame
    void OnEnable()
    {
        GameManager.OnGameStart+= ActivateMainMenu;
        GameManager.OnLevelStart+=ActivateHUD;
        GameManager.OnPlayerDead+= ActivateGameOverPanel;
        
    }

    void Update(){

        if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null)
        {
            return;
        }
            

    }

    public void ActivateMainMenu(){

        foreach(Transform go in canvas.transform)
        {

            if(go.GetComponent<MainMenu>()!=null){

                go.gameObject.SetActive(true);
                
            }
            else
                go.gameObject.SetActive(false);



        }


    }

    public void ActivateHUD()
    {

        foreach(Transform go in canvas.transform){

            if(go.GetComponent<HeadsupDisplay>()!=null){

                go.gameObject.SetActive(true);
                
            }
            else
                go.gameObject.SetActive(false);



        }



    }

    public void ActivateGameOverPanel()
    {
        //StartCoroutine(GameOverPanel());
        foreach(Transform go in canvas.transform)
        {

            if(go.GetComponent<RetryUI>()!=null){

                go.gameObject.SetActive(true);
                
            }
            else
                go.gameObject.SetActive(false);

        }
    }


    /*IEnumerator GameOverPanel()
    {
        yield return new WaitForSeconds(0.8f);
        foreach(Transform go in canvas.transform){

            if(go.GetComponent<RetryUI>()!=null){

                go.gameObject.SetActive(true);
                
            }
            else
                go.gameObject.SetActive(false);



        }



    }*/


     void OnDisable()
    {
        GameManager.OnGameStart-= ActivateMainMenu;
        GameManager.OnLevelStart-=ActivateHUD;
        GameManager.OnPlayerDead-= ActivateGameOverPanel;
        
    }
   


}
