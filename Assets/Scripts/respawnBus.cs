using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnBus : MonoBehaviour
{
    public GameObject agent;
    public GameObject goalObject;
    public GameObject[] allSpawnPoints;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SetActive(false);
        if (!agent)
        {
            Invoke("ReSpawn", 20);
        }
        Destroy(collision.gameObject); //after reSpawn, then is able to destory the old gameObject clone of Vehicle
    }

    void ReSpawn()
    {
       
        int rand = Random.Range(0, allSpawnPoints.Length);
        GameObject spawn = allSpawnPoints[rand];
        GameObject a = (GameObject)Instantiate(agent, spawn.transform.position, Quaternion.identity); //instantiate theh copy of vehical and store in varibal v
        a.GetComponent<driveTo>().goal = goalObject.transform;//get hold of the goal in DriveTo script, andn set it tobe the transform of goalObject
    
    }


}
