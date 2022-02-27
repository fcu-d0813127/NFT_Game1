using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_WEBGL
public class WebGLReadSite : MonoBehaviour
{
    async public Task<string> OnSendContract()
    {
        // set chain: ethereum, moonbeam, polygon etc
        string chain = "binance";
        // set network mainnet, testnet
        string network = "testnet";
        // smart contract method to call
        string method = "readSite";
        // abi in json format
        string abi = "[{\"inputs\":[],\"name\":\"entityOperation\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"initPlayer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint8\",\"name\":\"NextSite\",\"type\":\"uint8\"}],\"name\":\"moveSite\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_player\",\"type\":\"address\"}],\"name\":\"readSite\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        // address of contract
        string contract = "0xfed52e1973777384422bF61F3ca039DD09a09cFB";
        // array of arguments for contract
        string args = String.Format("[\"{0}\"]", PlayerPrefs.GetString("Account"));
        // connects to user's browser wallet (metamask) to update contract state
        try
        {
            string response = await EVM.Call(chain, network, contract, abi, method, args);
            // response為smart contract return值
            Debug.Log(response);
            return response;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            return "fail";
        }
    }
}
#endif
