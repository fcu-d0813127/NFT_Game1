using System;
using System.Threading.Tasks;
using UnityEngine;

public class WebGLCall : MonoBehaviour
{
    // set chain: ethereum, moonbeam, polygon etc
    static string Chain = "binance";
    // set network mainnet, testnet
    static string Network = "testnet";
    // smart contract method to call
    static string Method;
    // abi in json format
    static string Abi = "[{\"inputs\":[],\"name\":\"entityOperation\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"initPlayer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint8\",\"name\":\"NextSite\",\"type\":\"uint8\"}],\"name\":\"moveSite\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_player\",\"type\":\"address\"}],\"name\":\"readSite\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    // address of contract
    static string Contract = "0xfed52e1973777384422bF61F3ca039DD09a09cFB";
    // array of arguments for contract
    static string Args = String.Format("[\"{0}\"]", PlayerPrefs.GetString("Account"));

    async static Task<string> OnCall() {
        // connects to user's browser wallet (metamask) to update contract state
        string response = await EVM.Call(Chain, Network, Contract, Abi, Method, Args);
        // response為smart contract return值
        Debug.Log(response);
        return response;
    }
    async static public Task<string> OnReadSite()
    {
        Method = "readSite";
        return await OnCall();
    }
}
