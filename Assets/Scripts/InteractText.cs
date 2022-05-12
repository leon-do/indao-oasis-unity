using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// drag this script onto an game object to make interactable
// drag the interactable object onto the InteractableObjects game object
// set Is Trigger to true
public class InteractText : MonoBehaviour
{
    public InteractController interactables;
    public string[] text;

    void OnTriggerEnter(Collider collider)
    {
        // select random text
        int textIndex = Random.Range(0, text.Length);
        interactables.DisplayText(text[textIndex]);
    }
}
