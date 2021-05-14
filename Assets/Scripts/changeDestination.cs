using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDestination : MonoBehaviour
{
    // the bus prefab needs to be dragged into this slot in the Inspector
    public driveToBus dT;
    public GameObject ownObject;

    void OnCollisionEnter(Collision collision)
    //void OnTriggerEnter(Collider collider)
    {
        //collision.gameObject.SetActive(false);
        Debug.Log("collision");
        dT.changeGoal(); // this line calls the function in the 'driveTo'-script

        ownObject.GetComponent<BoxCollider>().enabled = false;
    }

}
