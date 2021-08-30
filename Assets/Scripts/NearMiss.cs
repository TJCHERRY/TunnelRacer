using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NearMiss : MonoBehaviour
{
    public float RayDistance = 0.8f;
   
    [HideInInspector]
    public Transform Comment;

    private HeadsupDisplay HUD;

    float temp;

    void OnEnable(){

       Playaa.OnCloseCall+=CurrentScoreIncrement;

    }

    void Start()
    {



        /*HUD = FindObjectOfType<HeadsupDisplay>();

        if (HUD != null)
        {


            foreach (Transform go in HUD.transform)
            {

                if (go.name == "Comment")
                {

                    Comment = go;
                    Comment.GetComponent<TMP_Text>().SetText("YOOOO");

                }
            }

        }*/

    }

    void Update()
    {
        CheckNearMiss();

        
    }

    void CheckNearMiss()
    {
       
       /* RaycastHit HitInfo;

        Debug.DrawRay(transform.position, transform.forward * RayDistance, Color.blue);
        Debug.DrawRay(transform.position, -transform.forward * RayDistance, Color.blue);

        if (Physics.Raycast(this.transform.position, transform.forward,out HitInfo,RayDistance)) // Left Ray
        {
            if(HitInfo.collider.tag=="obstacle" && !hitOnce)
            {
                if(hitOnce)
                    return;

                Debug.Log("HIT");
                hitOnce=true;
                Playaa.OnCloseCall();
                    //CalDistance(this.transform.position, HitInfo.transform.position);
               

            }
 
        }
        else
        {

            hitOnce=false;;
            
        }
            
        

        if (Physics.Raycast(this.transform.position, -transform.forward, out HitInfo, RayDistance)) // Left Ray
        {
            if(HitInfo.collider.tag=="obstacle" && !hitOnce)
            {
                if(hitOnce)
                    return;
                
                Debug.Log("HIT");

                hitOnce=true;
                Playaa.OnCloseCall();
                    //CalDistance(this.transform.position, HitInfo.transform.position);
            }
            
           
           
        }
        else {

                hitOnce=false;
               
        }*/
            
       
    }

   /* void CalDistance(Vector3 a, Vector3 b)
    {
        float Len = Vector3.Distance(a, b);
        if(Len <1.6f && !nearMiss)
        {
           
            
            Playaa.OnCloseCall();

            GameManager.Instance.CurrentScore+=3f;
            //temp=1000f;
           

        }
       
    }*/

    void FloatText()
    {
        if(Comment != null)
        {
            //Instantiate(Comment, new Vector3(0, 0, 0), Quaternion.identity);
            Comment.GetComponent<TMP_Text>().text = "Near Miss!!";
            Comment.gameObject.SetActive(true);
            Debug.Log("CAme here");
        }
        
    }

    public void CurrentScoreIncrement()
    {
           GameManager.Instance.CurrentScore+=3f;
           
           


    }

    void OnDisable(){

        Playaa.OnCloseCall-=CurrentScoreIncrement;

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="obstacle"){
            Playaa.OnCloseCall();

        }

    }

   

    
}
