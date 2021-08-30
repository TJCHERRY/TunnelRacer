using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipeObstacleGenerator : MonoBehaviour
{
    public ObstacleItem[] items;
    public LevelData levelData;

     protected int obsLength;
    public virtual void WhenEnabled()
    {
        obsLength=0;

        if(GameManager.CurrentLevelNumber<items.Length)
                obsLength=GameManager.CurrentLevelNumber;
        else
            obsLength=items.Length;

        Debug.Log(obsLength);
    }
    public abstract void GenerateThemObstacles(Pipe pipe);
 
}
