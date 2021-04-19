using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class distanceDetect : MonoBehaviour
{
    public GameObject raycastObject;
    // public GameObject trafficLight1;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        /*Ray ray = new Ray(raycastObject.transform.position, raycastObject.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 30))
        {
            Debug.Log("hit");
            raycastObject.transform.position += new Vector3(0.0f, 0.0f, 0f);
        }
        */
        Debug.Log(isClose());
        //  Debug.Log(isCloseLeft());

        // if (trafficLight.GetComponent<Renderer>().material.color == Color.red)
        //   { 
        if (isClose())
        {
            //raycastObject.transform.position += new Vector3(0.0f, 0.0f, 0f);
            //raycastObject.SetActive(false);
           raycastObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

        else if (isClose() == false)
        {
            raycastObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

        //  }

    }
    //coming from north, direction is left, coming from 
    bool isClose()
    {
        return Physics.Raycast(transform.position, transform.forward, 22);

    }

   

}
