using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractController : MonoBehaviour
{
    public GameObject DisplayMenu;
    public TMP_Text DisplayMenuText;
    public GameObject NFTMenu;

    public void DisplayText(string _text)
    {
        NFTMenu.SetActive(false);
        DisplayMenu.SetActive(true);
        DisplayMenuText.text = _text.Replace("\\n", "\n");;        
    }
}
