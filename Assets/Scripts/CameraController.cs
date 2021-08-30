using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Playaa player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Playaa>();
            Debug.Log(player.name);
            return;
        }
        else
        {
            transform.rotation=Quaternion.LookRotation(player.transform.right,player.transform.up);
        }

    }
}
