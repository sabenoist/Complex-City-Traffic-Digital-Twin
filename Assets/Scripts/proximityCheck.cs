using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class proximityCheck : MonoBehaviour
{
    public GameObject[] light;
    public GameObject pedestrian;
    public GameObject[] bus;
    public GameObject busStation;
    public float BusDistance;

    public GameObject buttonPrefab;
    public RectTransform buttonContainer;
    private GameObject button;
    public GameObject activeButtonTag;


    public List<GameObject> buttonList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // foreach (Button button in AppButton) //disable all buttons at start
        //  {
        // button.interactable = false;
        // button.gameObject.SetActive(false);
        // }


    }

    // Update is called once per frame
    void Update()
    {
        bus = GameObject.FindGameObjectsWithTag("bus");


        //for (int l = 0; l < light.Length; l++) 
        //LightDistance = Vector3.Distance(light[l].transform.position, pedestrian.transform.position);

        if (Vector3.Distance(light[0].transform.position, pedestrian.transform.position) < 35)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else if (Vector3.Distance(light[1].transform.position, pedestrian.transform.position) < 35)
        {
            checkDistance();
        }
        else if (Vector3.Distance(light[2].transform.position, pedestrian.transform.position) < 35)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        else if (Vector3.Distance(light[3].transform.position, pedestrian.transform.position) < 35)
        {
            // Debug.Log("close to light");

            checkDistance();
        }
        // else
        // {
        //     disableAllButton();
        //  }

        // }//for loop 
        void checkDistance()
        {

            for (int i = 0; i < bus.Length; i++)
            {
                int busNo = bus[i].GetComponent<busNumber>().busNo;
                activeButtonTag = GameObject.FindGameObjectWithTag(busNo.ToString());
                if ((Vector3.Distance(bus[i].transform.position, pedestrian.transform.position) < 250) && (Vector3.Distance(bus[i].transform.position, busStation.transform.position) < 60))
                {

                    // AppButton[i].interactable = true;

                    // GameObject b = GameObject.FindGameObjectsWithTag("busNo");

                    if (!activeButtonTag)
                    {
                        // AppButton[busNo - 1].gameObject.SetActive(true);
                        button = (GameObject)Instantiate(buttonPrefab);
                        button.tag = busNo.ToString();
                        button.GetComponentInChildren<Text>().text = "bus No " + busNo;
                        button.transform.SetParent(buttonContainer, false);
                        buttonList.Add(button);
                    }

                    //BusDistance = Vector3.Distance(bus[i].transform.position, pedestrian.transform.position);
                    //Debug.Log(BusDistance);
                }
                else
                {

                    // AppButton[busNo - 1].gameObject.SetActive(false);
                    if (activeButtonTag)
                    {
                        activeButtonTag.SetActive(false);
                    }
                }
            }

        }


        /*     void disableAllButton()
             {
                 foreach (Button button in AppButton) //disable all buttons 
                 {
                     // button.interactable = false;
                     button.gameObject.SetActive(false);
                 }
             }*/
    }
}