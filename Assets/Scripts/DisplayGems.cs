using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGems : MonoBehaviour
{
    private List<string> Gems = new List<string>
    {
        "Blue",
        "Red",
        "Green",
        "Yellow",
        "Purple"
    };

    //If we change the name of these gameobjects in the scene, this script will break/need to be updated

    void Awake()
    {
        foreach (string gem in Gems) {
            gameObject.transform.Find($"DoorGem_{gem}").gameObject.SetActive(false);
        }
    }

    public void AddGem(string color)
    {
        gameObject.transform.Find($"DoorGem_{color}").gameObject.SetActive(true);
        gameObject.transform.Find("GemSlots").transform.Find($"GemSlot_{color}").gameObject.SetActive(false);
    }
}
