using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NFTController: MonoBehaviour
{
    public NFTMenuController nftMenuController;
    public GameObject DisplayMenu;
    public GameObject NFTMenu;
    public int tokenId = 1;

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag == "Player")
        {
            DisplayMenu.SetActive(false);
            NFTMenu.SetActive(true);
            nftMenuController.UpdateNFTText(tokenId);
        }
    }
}
