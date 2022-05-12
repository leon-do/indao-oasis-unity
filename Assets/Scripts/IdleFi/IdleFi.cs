using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NFTNamespace;

public class IdleFi : MonoBehaviour
{
    private static string chain = "oasis";
    private static string network = "testnet";
    private static string chainId = "42261";
    private static string contract20 = "0x558A95F59834a2b364574822F5fEb614ff70050A";
    private static string contract1155 = "0x2a08A7c55d5391C7801b4F1EF5a18aaCB68d6285";
    private static string contractIdle = "0xF248A9C50d0db54Ea53B6cE0CA0E8D5861b908Ed";
    private static string contractIdleAbi = "[ { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"_admin\", \"type\": \"address\" } ], \"name\": \"addAdmin\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"buy\", \"outputs\": [], \"stateMutability\": \"payable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"_id\", \"type\": \"uint256\" } ], \"name\": \"claim\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"_id\", \"type\": \"uint256\" } ], \"name\": \"mint\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"_admin\", \"type\": \"address\" } ], \"name\": \"removeAdmin\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"_id\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"_total\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"_maxYield\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"_costNext\", \"type\": \"uint256\" } ], \"name\": \"setNftProperty\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"_idle20\", \"type\": \"address\" }, { \"internalType\": \"address\", \"name\": \"_idle1155\", \"type\": \"address\" } ], \"stateMutability\": \"nonpayable\", \"type\": \"constructor\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"_amount\", \"type\": \"uint256\" } ], \"name\": \"withdraw\", \"outputs\": [], \"stateMutability\": \"payable\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"address\", \"name\": \"\", \"type\": \"address\" }, { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"name\": \"lastClaim\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [ { \"internalType\": \"uint256\", \"name\": \"\", \"type\": \"uint256\" } ], \"name\": \"nfts\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"total\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"maxYield\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"costNext\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" } ]";
    private static string rpc = "https://testnet.emerald.oasis.dev";

    async public static Task<string> GetTokenBalance()
    {
        string account = PlayerPrefs.GetString("Account"); // "0xdd4c825203f97984e7867f11eecc813a036089d1";
        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract20, account, rpc);
        return balanceOf.ToString();
    }

    async public static Task<string> GetNftBalance(string _tokenId)
    {
        string account = PlayerPrefs.GetString("Account"); // "0xdd4c825203f97984e7867f11eecc813a036089d1";
        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract1155, account, _tokenId, rpc);
        return balanceOf.ToString();
    }

    async public static Task<string> GetLastClaim(string _tokenId)
    {
        // smart contract method to call
        string method = "lastClaim";
        string[] obj = { PlayerPrefs.GetString("Account"), _tokenId}; // { "0xdd4c825203f97984e7867f11eecc813a036089d1", "1" };
        // array of arguments for contract
        string args = JsonConvert.SerializeObject(obj);
        // connects to user's browser wallet to call a transaction
        string response = await EVM.Call(chain, network, contractIdle, contractIdleAbi, method, args, rpc);
        // display response in game
        return response;
    }

    async public static Task<string> GetCostNext (string _tokenId)
    {
        // smart contract method to call
        string method = "nfts";
        // array of arguments for contract
        string[] obj = { _tokenId };
        string args = JsonConvert.SerializeObject(obj);
        // connects to user's browser wallet to call a transaction
        string response = await EVM.Call(chain, network, contractIdle, contractIdleAbi, method, args, rpc);
        // convert string to json
        NFT nft = JsonConvert.DeserializeObject<NFT>(response);
        return nft.CostNext.ToString();
    }

    async public static Task<string> GetMaxYield (string _tokenId)
    {
        // smart contract method to call
        string method = "nfts";
        // array of arguments for contract
        string[] obj = { _tokenId };
        string args = JsonConvert.SerializeObject(obj);
        // connects to user's browser wallet to call a transaction
        string response = await EVM.Call(chain, network, contractIdle, contractIdleAbi, method, args, rpc);
        // convert string to json
        NFT nft = JsonConvert.DeserializeObject<NFT>(response);
        return nft.MaxYield.ToString();
    }

    async public static Task<string> Claim(string _tokenId) {
        // smart contract method to call
        string method = "claim";
        // array of arguments for contract
        string[] obj = { _tokenId };
        string args = JsonConvert.SerializeObject(obj);
        string response;
        #if UNITY_WEBGL && !UNITY_EDITOR
            // connects to user's browser wallet to call a transaction
            print("webglclimaing");
            response = await Web3GL.SendContract(method, contractIdleAbi, contractIdle, args, "0", "", "");
            print("idlefireponse " + response);
        #else
            string data = await EVM.CreateContractData(contractIdleAbi, method, args);
            response = await Web3Wallet.SendTransaction(chainId, contractIdle, "0", data, "", "");
        #endif
        // display response in game
        return response;
    }

    async public static Task<string> Buy() {
        // smart contract method to call
        string method = "buy";
        string value = "1000000000000000000";
        // array of arguments for contract
        string[] obj = { };
        string args = JsonConvert.SerializeObject(obj);
        string response;
        #if UNITY_WEBGL && !UNITY_EDITOR
            // connects to user's browser wallet to call a transaction
            response = await Web3GL.SendContract(method, contractIdleAbi, contractIdle, args, value, "", "");
        #else
            string data = await EVM.CreateContractData(contractIdleAbi, method, args);
            response = await Web3Wallet.SendTransaction(chainId, contractIdle, value, data, "", "");
        #endif
        // display response in game
        return response;
    }

    async public static Task<string> Mint(string _nftId) {
        // smart contract method to call
        string method = "mint";
        // array of arguments for contract
        string[] obj = { _nftId };
        string args = JsonConvert.SerializeObject(obj);
        string response;
        #if UNITY_WEBGL && !UNITY_EDITOR
            // connects to user's browser wallet to call a transaction
            response = await Web3GL.SendContract(method, contractIdleAbi, contractIdle, args, "0", "", "");
        #else
            string data = await EVM.CreateContractData(contractIdleAbi, method, args);
            response = await Web3Wallet.SendTransaction(chainId, contractIdle, "0", data, "", "");
        #endif
        // display response in game
        return response;
    }

    async public static Task<string> MaxYield(string _nftId) {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int now = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        int lastClaim = int.Parse(await IdleFi.GetLastClaim(_nftId));
        int deltaTime = now - lastClaim;
        int owned = int.Parse(await IdleFi.GetNftBalance(_nftId));
        int calculatedMaxYield =  deltaTime * owned;
        int maxYield = int.Parse(await IdleFi.GetMaxYield(_nftId));
        int ownedMaxYield = maxYield * owned;
        // https://leondo123.gitbook.io/idlefi/mathematics#calculate-max-yield-1
        int displayMaxYield= (calculatedMaxYield > ownedMaxYield) ? ownedMaxYield : calculatedMaxYield;
        return displayMaxYield.ToString();
    }

    async public static Task<bool> WaitForTx(string _txHash) {
        string txConfirmed = "pending";
        while (txConfirmed == "pending") {
            txConfirmed = await EVM.TxStatus(chain, network, _txHash, rpc);
            await new WaitForSeconds(1f);
        }
        if (txConfirmed == "success") {
            return true;
        }
        return false;
    }
}


