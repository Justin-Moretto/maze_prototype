using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;

    public void AddKey()
    {
        hasKey = true;
    }

    public void UseKey()
    {
        hasKey = false;
    }
}
