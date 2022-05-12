using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDisplayMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // set this game object to be inactive
            this.gameObject.SetActive(false);
        } 
    }
}
