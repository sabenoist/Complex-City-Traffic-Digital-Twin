using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class distanceDetect : MonoBehaviour
{
    public GameObject raycastObject;
  
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(isClose());
  
        if (isClose())
        {
           raycastObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

        else if (isClose() == false)
        {
            raycastObject.GetComponent<NavMeshAgent>().isStopped = false;
        }


    }
    //coming from north, direction is left, coming from 
    bool isClose()
    {
        return Physics.Raycast(transform.position, transform.forward, 22);

    }

   

}
