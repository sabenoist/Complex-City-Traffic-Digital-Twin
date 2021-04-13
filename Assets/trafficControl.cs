using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class trafficControl : MonoBehaviour
{
    public GameObject[] light;
    public GameObject[] obstacle;

    void Start()
    {
        //UnityEngine.AI.NavMeshObstacle obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        // obstacle.gameObject.SetActive(true);

    }
    void Update()
    {
        // UnityEngine.AI.NavMeshObstacle obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        for (int i = 0; i < light.Length; i++)
        {
            if (light[i].GetComponent<Renderer>().material.color == Color.red)
            {
                stop();
                Debug.Log("red");
            }

            // if(light.GetComponent<Renderer>().material.color == Color.green)
            else
            {
                go();
                Debug.Log("green");
            }
        }
    }
    void stop()
    {
        //UnityEngine.AI.NavMeshObstacle obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        for (int i = 0; i < obstacle.Length; i++)
        {
            obstacle[i].gameObject.SetActive(true);
        }

    }

    void go()
    {
        //UnityEngine.AI.NavMeshObstacle obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        for (int i = 0; i < obstacle.Length; i++)
        {
            obstacle[i].gameObject.SetActive(false);
        }
    }




}
