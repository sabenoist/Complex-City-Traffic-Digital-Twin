using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBus : MonoBehaviour
{
    public GameObject bus;
    public GameObject goalObject;
    public GameObject busStopObject;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Spawn", (Random.Range(3, 10))); 
        Invoke("Spawn", 4);
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject a = (GameObject)Instantiate(bus, this.transform.position, Quaternion.identity); //instantiate theh copy of vehical and store in varibal v
        //a.GetComponent<driveTo>().goal = busStopObject.transform;//get hold of the goal in DriveTo script, andn set it to be the transform of goalObject
        //a.GetComponent<driveTo>().goal_2 = goalObject.transform;
        Invoke("Spawn", 60);
    }

    void Update()
    {


    }
}
