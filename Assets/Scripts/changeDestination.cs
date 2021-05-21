using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDestination : MonoBehaviour
{
    public GameObject ownObject;

    void OnCollisionEnter(Collision collision)
    //void OnTriggerEnter(Collider collider)
    {
        Debug.LogWarning("collision");
        
        GameObject bus = collision.gameObject;
        bus.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        StartCoroutine(busControl(bus));
    }

    IEnumerator busControl(GameObject bus) {
        yield return new WaitForSeconds(10);
        
        if (bus.GetComponent<driveToBus>().waitLonger) {
            yield return new WaitForSeconds(20);
        }
        
        bus.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        bus.GetComponent<driveToBus>().changeGoal();
        bus.GetComponent<driveToBus>().waitLonger = false;

        ownObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2);
        ownObject.GetComponent<BoxCollider>().enabled = true;

    }
}
