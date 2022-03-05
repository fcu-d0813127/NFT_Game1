using UnityEngine;
using System.Threading.Tasks;

public class StatusCheck : MonoBehaviour {
  public static async Task Check(string hash) {
    string _chain = "binance";
    string _network = "testnet";
    string _transaction = hash;
    string _txStatus = "";

    while (_txStatus != "success") {
      _txStatus = await EVM.TxStatus(_chain, _network, _transaction);
      Debug.Log(_txStatus); // success, fail, pending
    }
  }
}
