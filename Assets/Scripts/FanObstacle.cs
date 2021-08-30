using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanObstacle : ObstacleItem
{
    public float rotationSpeed;
    public override void SetPosition(Pipe pipe, float curveRotation, float ringRotation){

        base.SetPosition(pipe,curveRotation,ringRotation);

    }

    void Update()
    {
        rotater.localRotation *= Quaternion.AngleAxis(rotationSpeed*Time.deltaTime, Vector3.right);

    }
    
}
