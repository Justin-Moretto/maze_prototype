using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone_M2Doors : MonoBehaviour
{
    public GameObject doorL_Target = null;
    public GameObject doorR_Target = null;

    private void OnTriggerEnter(Collider playerAvatar)
    {
        if(playerAvatar.gameObject.tag == "Player")
        {
            doorL_Target.SendMessage("DoorsAnimation");
            doorR_Target.SendMessage("DoorsAnimation");
        }
    }
}
