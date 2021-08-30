using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelGenerator : MonoBehaviour
{
    private static LevelGenerator instance=null;

    public static bool sessionStarted;
    public static LevelGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelGenerator>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "LevelGen";
                    instance=go.AddComponent<LevelGenerator>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }

    }

    public static float timeLimit;

    public static bool timeOut;
    public LevelData levelData;
    static int levelCount;
    private PipeSystem pipeSystem;
    public Transform worldPrefab;
    public static Playaa playaa;
    public static GameObject currentWorld;

    private Touch tap;
    private void Awake()
    {
/*         if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
        }
        else
        {
            Destroy(instance.gameObject);
        } */

        timeLimit= 60f;

        

    }

    void Update()
    {
     
        if(( /*Input.touchCount>0 &&*/!sessionStarted) || timeOut)
        {
          
            if(timeOut)
            {
                sessionStarted=false;
                GameManager.CurrentLevelNumber+=1;
                levelData.LevelNumber=GameManager.CurrentLevelNumber;
                GameManager.OnLevelStart();
                
            }
           
            timeOut=false;
            if(currentWorld!=null)
            {

                Destroy(currentWorld);
                if(playaa.gameObject!=null)
                {
                    
                    Destroy(playaa.gameObject);
                    
                }

            }
            currentWorld=Instantiate<GameObject>(worldPrefab.gameObject);
            
            
            if(currentWorld!=null)
            {

                pipeSystem = currentWorld.transform.GetChild(0).GetComponent<PipeSystem>();
                pipeSystem.gameObject.name="PIPESYSTEM!!!";
                pipeSystem.og.AddRange(levelData.obstacleGenerator);
                
                Debug.Log("Assign Obstacle Reference");
                if (pipeSystem == null)
                {
                    return;
                }
                
                GameObject player = Instantiate<GameObject>(levelData.playerPrefab,Vector3.zero,Quaternion.identity);
                
                playaa = player.GetComponent<Playaa>();
                playaa.pipeSystem = pipeSystem;
                
            }

            

            sessionStarted=true;
        }

        if(GameManager.CurrentLevelNumber>0 )
        {
            GameManager.Instance.CurrentScore+=Time.deltaTime;

        }
       
 
    }
  

    
   

}
