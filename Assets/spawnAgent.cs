using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAgent : MonoBehaviour
{
    public GameObject agent1;
    public GameObject agent2;
    public GameObject[] allGoals;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", (Random.Range(0, 10))); //call Spawnfunction after 2 seconds
    }

    // Update is called once per frame
   void Spawn()
    {
        GameObject[] allAgents = { agent1, agent2 };
        int random_num = Random.Range(0, allAgents.Length);
        GameObject agent = allAgents[random_num];
        GameObject a = (GameObject)Instantiate(agent, this.transform.position, Quaternion.identity); //instantiate theh copy of vehical and store in varibal v

        int rand = Random.Range(0, allGoals.Length);
        GameObject goalObject = allGoals[rand];
        a.GetComponent<driveTo>().goal = goalObject.transform;//get hold of the goal in DriveTo script, andn set it to be the transform of goalObject
        //Invoke("Spawn", Random.Range(2,5);
        //Invoke("Spawn", 30);
    }

    void Update()
    {
       
       
    }

    
}
