using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NFTMenuController : MonoBehaviour
{
    public GameObject NFTMenu;
    public GameObject DisplayMenu;
    private int tokenId;
    public TMP_Text DisplayNFTText;
    private bool canSendTx = true;

    private string[] skyships = { "----", "Athena", "Demeter", "Calliope", "Chloe", "Electra", "Daphne", "Penolope", "Iris", "Hestia", "Aphrodite", "Calypso", "Hera", "Artemis", "DeJesus" };

    void Start()
    {
        DisplayMenu.SetActive(false);
        DisplayNFTText.text = "loading skyship...";
    }

    void Update()
    {
        // listen to key press: claim, mint, buy
        if (Input.GetKeyDown(KeyCode.M) && canSendTx)
        {
            // canSendTx = false;
            Mint();
        }

        if (Input.GetKeyDown(KeyCode.C) && canSendTx)
        {
            // canSendTx = false;
            Claim();
        }

        if (Input.GetKeyDown(KeyCode.B) && tokenId == 1 && canSendTx)
        {
            // canSendTx = false;
            Buy();
        }
    }

    async public void UpdateNFTText(int _tokenId)
    {
        tokenId = _tokenId;

        string nftBalance = await IdleFi.GetNftBalance(tokenId.ToString());
        string tokenBalance = await IdleFi.GetTokenBalance();
        string maxYield = await IdleFi.MaxYield(tokenId.ToString());
        string costNext = await IdleFi.GetCostNext(tokenId.ToString());

        if (nftBalance == "0") costNext = "0";

        string text = "skyship: " + skyships[tokenId] +
                "\n" + "model: ECC-" + tokenId.ToString() +
                "\n" + "ships owned: " + nftBalance +
                "\n" + "t-rays owned: " + tokenBalance +
                "\n" +
                "\n" + "<m to mint ship>: " + costNext + " t-rays" +
                "\n" + "<c to claim>: " + maxYield + " t-rays";

        // can only buy tokenId 1 
        if (tokenId == 1)
        {
            text = text + "\n" + "<b to buy ship>";
        }

        DisplayNFTText.text = text.Replace("\\n", "\n");
    }

    async private void Claim()
    {
        string txHash = await IdleFi.Claim(tokenId.ToString());
        bool status = await IdleFi.WaitForTx(txHash);
        UpdateNFTText(tokenId);
        // canSendTx = true;
    }

    async private void Mint()
    {
        string txHash = await IdleFi.Mint(tokenId.ToString());
        await IdleFi.WaitForTx(txHash);
        UpdateNFTText(tokenId);
        // canSendTx = true;
    }

    async private void Buy()
    {
        string txHash = await IdleFi.Buy();
        await IdleFi.WaitForTx(txHash);
        UpdateNFTText(tokenId);
        // canSendTx = true;
    }
}
