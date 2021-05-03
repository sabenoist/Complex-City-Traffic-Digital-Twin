using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveTo : MonoBehaviour
{

    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/* THIS IS THE WORK YAZZ DID TRYING TO MAKE THE BUS HAVE TWO DESTINATIONS
 * 
 * 
 * 
public class driveTo : MonoBehaviour
{
    // this is the old code
    //public Transform goal;

    // this is the new code, allowing for two goals for all vehicles
    public Transform goal_1;
    public Transform goal_2;

    // Start is called before the first frame update
    void Start()
    {
        // this is the old code
        //UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.destination = goal.position;


        // this is the new code, making the first goal the goal of all vehicles
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal_1.position;
    }

    // this is part of the new code,
    // a function changing the goal of the bus
    // this is called from the 'changeDestination'-script that is actiated at the first goal of the bus
    public void changeGoal()
    {
        Debug.Log("driveTo scrpit called!");

        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal_2.position;

    }

    // Update is called once per frame
    void Update()
    {

    }
}*/