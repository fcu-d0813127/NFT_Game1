using System;
using System.Threading.Tasks;
using UnityEngine;

public class WebGL {
  #if UNITY_WEBGL
  public class Send : MonoBehaviour {
    // smart contract method to call
    static string _method;
    // abi in json format
    static string _abi = Contract.Abi;
    // address of contract
    static string _contract = Contract.Address;
    // array of arguments for contract
    static string _args;
    // value in wei
    static string _value = "0";
    // gas limit OPTIONAL
    static string _gasLimit = "";
    // gas price OPTIONAL
    static string _gasPrice = "";
    
    static async Task<string> OnSend() {
      // connects to user's browser wallet (metamask) to update contract state
      try {
        string response = await Web3GL.SendContract(_method, _abi, _contract, _args, _value, _gasLimit, _gasPrice);
        // response為transaction hash
        Debug.Log(response);
        return response;
      } catch {
        throw;
      }
    }

    public static async Task<string> OnInitPlayer() {
      _method = "initPlayer";
      _args = "[]";
      return await OnSend();
    }

    public static async Task<string> OnMoveSite(int background) {
      _method = "moveSite";
      _args = String.Format("[\"{0}\"]", background);
      return await OnSend();
    }

    public static async Task<string> OnKillEnemy(int background) {
      _method = "killEnemy";
      _args = String.Format("[\"{0}\", \"1\"]", background);
      return await OnSend();
    }
  }
  #endif

  public class Call : MonoBehaviour {
    // set chain: ethereum, moonbeam, polygon etc
    static string _chain = "binance";
    // set network mainnet, testnet
    static string _network = "testnet";
    // smart contract method to call
    static string _method;
    // abi in json format
    static string _abi = Contract.Abi;
    // address of contract
    static string _contract = Contract.Address;
    // array of arguments for contract
    static string _args = String.Format("[\"{0}\"]", PlayerPrefs.GetString("Account"));

    static async Task<string> OnCall() {
      // connects to user's browser wallet (metamask) to update contract state
      string response = await EVM.Call(_chain, _network, _contract, _abi, _method, _args);
      // response為smart contract return值
      Debug.Log(response);
      return response;
    }

    public static async Task<string> OnReadSite() {
      _method = "readSite";
      return await OnCall();
    }

    public static async Task<string> OnReadEnemyNum(int background) {
      _method = "map";
      _args = String.Format("[\"{0}\"]", background);
      return await OnCall();
    }
  }
}
