using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class proximityCheck : MonoBehaviour
{
    public GameObject[] light;
    public GameObject pedestrian;
    public GameObject[] bus;
  //  public GameObject[] busPrefab;
    //  public float LightDistance;
    public float BusDistance;
    public Button[] AppButton;
    //public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in AppButton) //disable all buttons at start
        {
            // button.interactable = false;
            button.gameObject.SetActive(false);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        bus = GameObject.FindGameObjectsWithTag("bus");

        //for (int l = 0; l < light.Length; l++) 
        //LightDistance = Vector3.Distance(light[l].transform.position, pedestrian.transform.position);

        if (Vector3.Distance(light[0].transform.position, pedestrian.transform.position) < 30)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else if (Vector3.Distance(light[1].transform.position, pedestrian.transform.position) < 30)
        {
            checkDistance();
        }
        else if (Vector3.Distance(light[2].transform.position, pedestrian.transform.position) < 30)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else if (Vector3.Distance(light[3].transform.position, pedestrian.transform.position) < 30)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else
        {
            disableAllButton();
        }

        // }//for loop 
        void checkDistance()
        {
           
            for (int i = 0; i < bus.Length; i++)
            {

                if (Vector3.Distance(bus[i].transform.position, pedestrian.transform.position) < 200)
                {
                    // AppButton[i].interactable = true;
                   int busNo = bus[i].GetComponent <busNumber>().busNo;
                    
                    AppButton[busNo-1].gameObject.SetActive(true);
                  
                    //BusDistance = Vector3.Distance(bus[i].transform.position, pedestrian.transform.position);
                    //Debug.Log(BusDistance);
                }
               // else //disable buttons if far from the bus
               // {
                //    AppButton[i].gameObject.SetActive(false);
               // }
            }

        }

        void disableAllButton()
        {
            foreach (Button button in AppButton) //disable all buttons 
            {
                // button.interactable = false;
                button.gameObject.SetActive(false);
            }
        }
    }
}