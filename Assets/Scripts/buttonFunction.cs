using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonFunction : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
       Button btn = button.GetComponent<Button>();
       btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
