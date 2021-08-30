using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelDataProfile", menuName ="Create New Level Data Profile")]
public class LevelData : ScriptableObject
{
    private int levelNumber;

    private float timeLimit;
    public PipeObstacleGenerator[] obstacleGenerator;
    public GameObject playerPrefab;
    public int LevelNumber { get => levelNumber; set => levelNumber = value; }
    public float TimeLimit { get => timeLimit; set => timeLimit = value; }
}
