using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public int gems = 0;
    public void AddKey()
    {
        hasKey = true;
    }

    public void UseKey()
    {
        hasKey = false;
    }
}
