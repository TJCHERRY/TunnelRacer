using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : PipeObstacleGenerator
{

    
    public override void GenerateThemObstacles(Pipe pipe)
    {
        base.WhenEnabled();
        float angleStep = pipe.CurveAngle / pipe.curveSegmentCount;

        for(int i = 0; i < 2; i++)
        {
            ObstacleItem item = Instantiate<ObstacleItem>(items[Random.Range(0, 2)]);
            float pipeRotation = (Random.Range(0, pipe.pipeSegmentCount) + 0.5f) * 360f / pipe.pipeSegmentCount;
            item.SetPosition(pipe, i * angleStep*6f, pipeRotation);
        }
    }

  
}
