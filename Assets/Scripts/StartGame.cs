using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
    }
}
