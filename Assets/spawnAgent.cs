using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAgent : MonoBehaviour
{
    public GameObject agent;
    public GameObject goalObject;

    // Start is called before the first frame update
    void Start()
    {
       Invoke("Spawn", 2); //call Spawnfunction after 2 seconds
    }

    // Update is called once per frame
   void Spawn()
    {
      GameObject a = (GameObject) Instantiate(agent, this.transform.position, Quaternion.identity); //instantiate theh copy of vehical and store in varibal v
      a.GetComponent<driveTo>().goal = goalObject.transform;//get hold of the goal in DriveTo script, andn set it to be the transform of goalObject
      //Invoke("Spawn", Random.Range(2,5);
      //Invoke("Spawn", 30);
    }

    void Update()
   {
       
       
    }

    
}
