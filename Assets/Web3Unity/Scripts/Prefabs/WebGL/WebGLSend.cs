using System;
using System.Threading.Tasks;
using UnityEngine;

#if UNITY_WEBGL
public class WebGLSend : MonoBehaviour
{
    // smart contract method to call
    static string Method;
    // abi in json format
    static string Abi = "[{\"inputs\":[],\"name\":\"entityOperation\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"initPlayer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint8\",\"name\":\"NextSite\",\"type\":\"uint8\"}],\"name\":\"moveSite\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_player\",\"type\":\"address\"}],\"name\":\"readSite\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    // address of contract
    static string Contract = "0xfed52e1973777384422bF61F3ca039DD09a09cFB";
    // array of arguments for contract
    static string Args;
    // value in wei
    static string Value = "0";
    // gas limit OPTIONAL
    static string GasLimit = "";
    // gas price OPTIONAL
    static string GasPrice = "";
    async static Task<string> OnSend() {
        // connects to user's browser wallet (metamask) to update contract state
        try
        {
            string response = await Web3GL.SendContract(Method, Abi, Contract, Args, Value, GasLimit, GasPrice);
            // response為transaction hash
            Debug.Log(response);
            return response;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return "Fail at WebGLSend";
        }
    }
    async static public Task<string> OnInitPlayer()
    {
        Method = "initPlayer";
        Args = "[]";
        return await OnSend();
    }

    async static public Task<string> OnMoveSite(int background) {
        Method = "moveSite";
        Args = String.Format("[\"{0}\"]", background);
        return await OnSend();
    }

    async static public Task<string> OnEntityOperation() {
        Method = "entityOperation";
        Args = "[]";
        return await OnSend();
    }
}
#endif
