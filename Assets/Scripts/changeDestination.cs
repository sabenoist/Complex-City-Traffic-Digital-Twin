using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDestination : MonoBehaviour
{
    // the bus prefab needs to be dragged into this slot in the Inspector
    //public driveToBus dT;
    public GameObject ownObject;

    void OnCollisionEnter(Collision collision)
    //void OnTriggerEnter(Collider collider)
    {
        //collision.gameObject.SetActive(false);
        Debug.LogWarning("collision");
        
        GameObject bus = collision.gameObject;
        //bus.GetComponent<driveToBus>().stopBus();
        bus.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //busControl(bus);

        StartCoroutine(busControl(bus));

       // dT.changeGoal(); // this line calls the function in the 'driveTo'-script

        //ownObject.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator busControl(GameObject bus) {
        yield return new WaitForSeconds(10);
        
        if (bus.GetComponent<driveToBus>().waitLonger) {
            yield return new WaitForSeconds(20);
        }
        bus.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        bus.GetComponent<driveToBus>().changeGoal();
        ownObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(5);
        ownObject.GetComponent<BoxCollider>().enabled = true;
    }
}
