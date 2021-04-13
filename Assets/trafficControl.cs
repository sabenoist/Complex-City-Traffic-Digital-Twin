using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class trafficControl : MonoBehaviour
{
    public GameObject lightA;
    
    
    void Start()
    {
        UnityEngine.AI.NavMeshObstacle obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        obstacle.gameObject.SetActive(true);
    }
   void Update()
    {
        UnityEngine.AI.NavMeshObstacle obstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
        
            if(lightA.GetComponent<Renderer>().material.color == Color.red)
            {
                obstacle.enabled = true;
                Debug.Log("red");
            }
       
       else if (lightA.GetComponent<Renderer>().material.color == Color.green)
           {
            obstacle.enabled = false;
            Debug.Log("green");
           } 
    }


}
