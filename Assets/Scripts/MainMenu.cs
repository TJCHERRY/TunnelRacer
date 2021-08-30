using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject levelGenPrefab;
    private GameObject menuWorld;
    private GameObject inGameWorld;

    public Transform Tunnel;
    public Transform Racer;

    public Slider instructionSlider;
    float angle=0;
    void Start()
    {
        
    }

    void OnEnable(){

        menuWorld=Instantiate(levelGenPrefab,Vector3.zero,Quaternion.identity) as GameObject;
        GameManager.OnGameStart+=TitleAnim;
        GameManager.OnLevelStart+=StartLevel;

        GameManager.OnGameStart();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount>0)
        {
            GameManager.OnLevelStart();
            
            

        }
        SidetoSide();
    }

    public void StartLevel()
    {
            GameManager.CurrentLevelNumber+=1;
        
            inGameWorld=Instantiate(levelGenPrefab,Vector3.zero,Quaternion.identity) as GameObject;
            Playaa.timer=0f;
            LevelGenerator.currentWorld.name="WORLD!";
            
            Debug.Log("<Color=blue>"+GameManager.CurrentLevelNumber+"</color>");
            LevelGenerator.sessionStarted=false;
            GameManager.Instance.currenGameState=GameManager.GameState.Play;
            gameObject.SetActive(false);

    }

    public void TitleAnim()
    {

         Tunnel.GetComponent<RectTransform>().LeanSetLocalPosX(-Tunnel.GetComponent<RectTransform>().rect.width*4f);
        Racer.GetComponent<RectTransform>().LeanSetLocalPosX(Racer.GetComponent<RectTransform>().rect.width*4f);

        LeanTween.moveX(Tunnel.GetComponent<RectTransform>(),0,2f).setEaseOutBounce();
        LeanTween.moveX(Racer.GetComponent<RectTransform>(),0,2f).setEaseOutBounce();

        Destroy(inGameWorld);


    } 

    public void SidetoSide()
    {
        
       instructionSlider.value= Mathf.PingPong(Time.time,1f);

    }

    void OnDisable()
    {    
        Destroy(menuWorld);
        GameManager.OnGameStart-=TitleAnim;
        GameManager.OnLevelStart-=StartLevel;
    }


}
