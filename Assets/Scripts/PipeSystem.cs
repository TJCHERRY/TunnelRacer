using UnityEngine;
using System.Collections.Generic;

public class PipeSystem : MonoBehaviour {

	public Pipe pipePrefab;
    public static bool hasInstantiatedPipes;
    public int pipeCount;

    [HideInInspector]
    public List<PipeObstacleGenerator> og;
	private Pipe[] pipes;

    private void Start()
    {
        pipes = new Pipe[pipeCount];
        
        for(int i = 0; i < pipes.Length; i++)
        {
            Pipe pipe = pipes[i] = Instantiate<Pipe>(pipePrefab);
            pipe.transform.SetParent(transform, false);
            pipe.Generate();
            hasInstantiatedPipes = true;
             
            if (i > 0)
            {
                pipe.AlignWith(pipes[i - 1]);

                if(GameManager.CurrentLevelNumber>0)
                {
                   
                    if (i > 1 && og!=null)
                    {
                        Debug.Log("GenerateOBstacle!!");
                        og[Random.Range(0,og.Count)].GenerateThemObstacles(pipe);

                    }
                }
                     
            }
            
        }
        hasInstantiatedPipes = false;

        AlignNextPipeWithOrigin();
    }

    public Pipe SetupFirstPipe()
    {
        transform.localPosition = new Vector3(0f, -pipes[1].curveRadius);
        return pipes[1];
    }

    public Pipe SetupNextPipe()
    {
        ShiftPipes();
        if(GameManager.Instance.currenGameState==GameManager.GameState.Play)
        {

            for(int i=0;i<pipes[pipes.Length-1].transform.childCount;i++)
            {
             Destroy(obj: pipes[pipes.Length-1].transform.GetChild(i).gameObject);
            }
            if(Playaa.timer<42f)
                og[Random.Range(0,og.Count)].GenerateThemObstacles(pipes[pipes.Length-1]);
        }
       

        AlignNextPipeWithOrigin();
        //pipes[pipes.Length - 1].Generate();
		pipes[pipes.Length - 1].AlignWith(pipes[pipes.Length - 2]);
        transform.localPosition = new Vector3(0f, -pipes[1].curveRadius);
        return pipes[1];

    }

   

    private void ShiftPipes()
    {
        var temp = pipes[0];
        for(int i = 1; i < pipes.Length ; i++)
        {
            pipes[i - 1] = pipes[i];
        }
        pipes[pipes.Length - 1] = temp;
    }

    private void AlignNextPipeWithOrigin()
    {
        Transform transformToAlign = pipes[1].transform;

        for(int i = 0; i < pipes.Length; i++)
        {
            if(i != 1)
                pipes[i].transform.SetParent(transformToAlign);
        }
        transformToAlign.localPosition = Vector3.zero;
        transformToAlign.localRotation = Quaternion.identity;

        for(int i = 0; i < pipes.Length; i++)
        {
            if (i != 1)
                pipes[i].transform.SetParent(transform);
        }

    }

}