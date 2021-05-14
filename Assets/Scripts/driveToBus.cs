using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveToBus : MonoBehaviour
{
    // this is the old code
    //public Transform goal;

    // this is the new code, allowing for two goals for all vehicles
    //public Transform goal;
    //public Transform goal_2;

    public GameObject goal;
    public GameObject goal_2;

    // Start is called before the first frame update
    void Start()
    {
        // this is the old code
        //UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.destination = goal.position;


        // this is the new code, making the first goal the goal of all vehicles
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Transform goal_trans = goal.transform;
        agent.destination = goal_trans.position;
    }

    // this is part of the new code,
    // a function changing the goal of the bus
    // this is called from the 'changeDestination'-script that is actiated at the first goal of the bus
    public void changeGoal()
    {
        Debug.Log("driveTo scrpit called!");

        UnityEngine.AI.NavMeshAgent a = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Transform goal_2_trans = goal_2.transform;
        //a.destination = goal_2_trans.position;
        a.Warp(goal_2.transform.position);
        a.speed = 25f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
