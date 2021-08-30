using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralGenerator : PipeObstacleGenerator
{
   
    
    public override void GenerateThemObstacles(Pipe pipe)
    {
        base.WhenEnabled();
        float startPos= Random.Range(0,pipe.pipeSegmentCount)+0.5f;
        float spiralDirection= Random.value<0.5f? 1f:-1f;

         float angleStep = 3f*(pipe.CurveAngle / pipe.curveSegmentCount);

        for(int i = 0; i < pipe.curveSegmentCount/3; i++)
        {
            ObstacleItem item = Instantiate<ObstacleItem>(items[Random.Range(0, obsLength)]);
            float pipeRotation = (startPos+ Random.Range(0,10)* spiralDirection) * 360f / pipe.pipeSegmentCount;
            item.SetPosition(pipe, i * angleStep, pipeRotation);
        }



    }


}
