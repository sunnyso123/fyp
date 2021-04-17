using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int counter = 0;
    public int flag = 0;
    public int isMistake = 0;

    public void add()
    {
        counter += 1;
    }

    public void minus()
    {
        counter -= 1;
    }
}
