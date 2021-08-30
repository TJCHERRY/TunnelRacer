using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float currentTime;
    private float timeLimit;
    public Transform handle;

    public Slider slider;


    // Start is called before the first frame update
    void Start(){
       


    }
    void OnEnable()
    {
       
             timeLimit= LevelGenerator.timeLimit;
             slider.value=0f;
              
       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime=Playaa.timer;
        float _value = currentTime/timeLimit;
        slider.value= _value;
        
        
       

        //handle.transform.Rotate(Vector3.forward, 100f*Time.deltaTime);

    }
}
