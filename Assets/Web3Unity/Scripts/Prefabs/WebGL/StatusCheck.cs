using UnityEngine;
using System.Threading.Tasks;

public class StatusCheck : MonoBehaviour
{
    async static public Task Check(string hash)
    {
        string chain = "binance";
        string network = "testnet";
        string transaction = hash;
        string txStatus = "";

        while (txStatus != "success")
        {
            txStatus = await EVM.TxStatus(chain, network, transaction);
            print(txStatus); // success, fail, pending
        }
    }
}
