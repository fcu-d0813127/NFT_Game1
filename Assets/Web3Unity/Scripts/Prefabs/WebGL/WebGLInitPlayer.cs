using System;
using System.Threading.Tasks;
using UnityEngine;

#if UNITY_WEBGL
public class WebGLInitPlayer : MonoBehaviour
{
    async static public Task<string> OnSendContract()
    {
        // smart contract method to call
        string method = "initPlayer";
        // abi in json format
        string abi = "[{\"inputs\":[],\"name\":\"entityOperation\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"initPlayer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint8\",\"name\":\"NextSite\",\"type\":\"uint8\"}],\"name\":\"moveSite\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_player\",\"type\":\"address\"}],\"name\":\"readSite\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        // address of contract
        string contract = "0xfed52e1973777384422bF61F3ca039DD09a09cFB";
        // array of arguments for contract
        string args = "[]";
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to update contract state
        try
        {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
            // response為transaction hash
            Debug.Log(response);
            return response;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return "Fail at WebGLInitPlayer";
        }
    }
}
#endif
