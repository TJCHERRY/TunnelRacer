using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static int currentLevelNumber;
    private  float currentScore;

    private float bestScore;
    public GameObject levelGenPrefab;
    private GameObject inGameWorld;
    private static GameManager instance=null;

   public static GameManager Instance
   {
       get
       {
           if(instance==null)
            {

                instance=FindObjectOfType<GameManager>();
                if(instance==null)
                {
                    GameObject go =new GameObject();
                    go.name="GameManager";
                    go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);

                }
            }

            return instance;  

       }
        

   }
   public static int CurrentLevelNumber{get=>currentLevelNumber; set=>currentLevelNumber=value;}
   public  float CurrentScore{get=>currentScore; set=>currentScore=value;}
   public float BestScore{get=>bestScore;set=>bestScore=value;}

   [HideInInspector]
    public  UIController uIController;

    public LevelGenerator levelGenerator;
   public static UnityAction OnLevelStart;
   public static UnityAction OnGameStart;

   public static UnityAction OnLevelFinish;

   public static UnityAction OnStartNextLevel;

   public static UnityAction OnPlayerDead;

   [HideInInspector]
   public enum GameState{MainMenu, PauseScreen, GameOver, Play }
   public GameState currenGameState;
   void Awake()
   {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
        }
        else
        {
            Destroy(instance.gameObject);
        }

        if(uIController==null)
        {

            uIController =FindObjectOfType<UIController>();
            if(uIController==null){

                GameObject go= new GameObject();
                go.name= "UIController";
                go.AddComponent<UIController>();

            }
        }
        
   }
   void OnEnable()
   {
       OnPlayerDead+=CompareScores;

   }

   void Start()
   {
       currentLevelNumber=0;
        
       OnGameStart();
     
        currentScore=0f;

       currenGameState= GameState.MainMenu;

   }

   void Update()
   {
       switch(currenGameState)
       {
           case GameState.MainMenu:
            Debug.Log("<color=green>"+"Main Menu"+"</color>");
            break;
       }
        
      
   }

   public void ResetCurrentScore()
   {
       instance.currentScore=0f;

   }

   public void CompareScores()
   {
       float _bestScore= PlayerPrefs.GetFloat("HighScore",bestScore);
       if(currentScore>=_bestScore)
       {
            bestScore=currentScore;
            PlayerPrefs.SetFloat("HighScore",bestScore);

        }

   }

  
}
