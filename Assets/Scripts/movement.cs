using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    public LayerMask walkingLayer;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //check if mouse left button clicked
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition); //cast ray from camera to mouse input position
            RaycastHit hitPoint; //contain infor what the ray hit

            if (Physics.Raycast (myRay, out hitPoint, 100000, walkingLayer))//cast the ray , distance 100, only can click on walking layer
            {
                agent.SetDestination(hitPoint.point); //set designation to the hit point
            }
        }
    }
}
