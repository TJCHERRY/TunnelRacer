using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class Playaa : MonoBehaviour
{
    [HideInInspector]
    public bool playerAlive;
    [HideInInspector]
    public PipeSystem pipeSystem;
    public float velocity;
    public float rotationVelocity;
    Pipe currentPipe;
    [HideInInspector]
    public static float timer;
    [HideInInspector]
    public HeadsupDisplay headsupDisplay;
    TMP_Text timerText;
    [HideInInspector]
    public Image whiteScreen;

    public static UnityAction OnCloseCall;
    [HideInInspector]
    public Transform world,rotater;
    private float worldRotation,carRotation;
    private float distanceTravelled;
    private float systemRotation;
    private float deltaToRotation;
    private float inputValue;

    private Touch touch;
    // Start is called before the first frame update

    void OnEnable(){

        playerAlive=true;
        timer=-1f;
        GameManager.OnPlayerDead+=DeactivatePlayer;

    }
    void Start()
    {
        
        world = pipeSystem.transform.parent;
        //headsupDisplay=FindObjectOfType<HeadsupDisplay>();
        //Transform go=headsupDisplay.transform.Find("Timer");
        //timerText= go.GetComponent<TMP_Text>();

        rotater = transform.GetChild(0);
        currentPipe = pipeSystem.SetupFirstPipe();
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.curveRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelGenerator.sessionStarted)
        {
            timer+=Time.deltaTime;
            //timerText.SetText(string.Format("{0:F1}",timer));

            LevelGenerator.timeOut= timer>LevelGenerator.timeLimit;

        }
        
        float delta = velocity * Time.deltaTime;
        distanceTravelled += delta;
        systemRotation += delta * deltaToRotation;

        //once player passes curve angle of current pipe, convert extra rotation back to distance,jump into the next pipe with remaining delta. Gotta Figure out why :P
        if (pipeSystem != null)
        {
            if (systemRotation > currentPipe.CurveAngle)
            {

                delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
                currentPipe = pipeSystem.SetupNextPipe();
                deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.curveRadius);
                SetupCurrentPipe();
                systemRotation = delta * deltaToRotation;


            }
            pipeSystem.transform.localRotation = Quaternion.Euler(0f, 0f, systemRotation);
        }

        //var touch = Input.GetTouch(0);

        //inputValue = touch.position.x > Screen.width / 2 ? 1f : -1f;
        if(Input.touchCount>0){

            touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {


                UpdateCarRotation();
            }
               

        }
        
    }

    private void SetupCurrentPipe()
    {
        
        worldRotation += currentPipe.RelativeRotation;
        if (worldRotation < 0f)
            worldRotation += 360f;
        else if (worldRotation >= 360f)
            worldRotation -= 360f;

        world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }

    void UpdateCarRotation()
    {
        carRotation += rotationVelocity*touch.deltaPosition.x; //Input.GetAxis("Horizontal"); 
        if (carRotation < 0f)
            carRotation += 360f;
        else if (carRotation >= 360f) 
            carRotation -= 360f;

        transform.localRotation = Quaternion.Euler(carRotation, 0f, 0f);
    }


    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag=="obstacle")
        {

            //LevelGenerator.sessionStarted=false;
            
            //timerText.SetText("Dead....Tap to retry");
           GameManager.OnPlayerDead();


        }

        

    }

    void DeactivatePlayer()
    {
        gameObject.SetActive(false);
        velocity=0f;

    }

    void OnDisable()
    {
        GameManager.OnPlayerDead-=DeactivatePlayer;

    }

   

   
}
