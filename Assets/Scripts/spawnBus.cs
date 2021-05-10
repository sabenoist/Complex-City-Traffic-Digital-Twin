using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBus : MonoBehaviour
{
    public GameObject bus;
    public GameObject goalObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 2); //call Spawnfunction after 2 seconds
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject a = (GameObject)Instantiate(bus, this.transform.position, Quaternion.identity); //instantiate theh copy of vehical and store in varibal v
        a.GetComponent<driveTo>().goal = goalObject.transform;//get hold of the goal in DriveTo script, andn set it to be the transform of goalObject
       // Invoke("Spawn", 50);
    }

    void Update()
    {


    }
}
