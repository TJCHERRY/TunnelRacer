using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : MonoBehaviour
{
    
     protected Transform rotater;

    protected void Awake()
    {
        rotater = transform.GetChild(0);
        
    }



    public virtual void SetPosition(Pipe pipe,float curveRotation,float ringRotation)
    {
        transform.SetParent(pipe.transform, false);
        transform.localRotation=Quaternion.Euler(0f, 0f, -curveRotation);
        rotater.localPosition = new Vector3(0f, pipe.curveRadius);
        rotater.localRotation = Quaternion.Euler(ringRotation, 0f, 0f);
    }
}
