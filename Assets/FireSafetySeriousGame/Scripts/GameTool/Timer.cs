using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime;
    public bool end = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            totalTime -= Time.deltaTime;
            if (totalTime <= 0f)
            {
                end = true;
            }
        }
        
    }
}
