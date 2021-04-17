using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    private Counter CounterScript;
    private CloseDoor Door;
    private const int maxd = 2;

    // Start is called before the first frame update
    void Start()
    {
        Door = GetComponent<CloseDoor>();
        GameObject counter = GameObject.Find("Counter");
        CounterScript = counter.GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localRotation.eulerAngles.y <= 3f)
        {
            CounterScript.add();
            Debug.Log("The door is closed");
            if (CounterScript.counter == maxd)
            {
                CounterScript.flag = 1;
                Debug.Log("All the door has been closed");
            }
            Door.enabled = false;
        }
    }
}
