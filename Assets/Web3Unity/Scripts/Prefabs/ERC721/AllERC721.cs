using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class AllERC721 : MonoBehaviour
{
    private class NFTs
    {
        public string contract { get; set; }
        public string tokenId { get; set; }
        public string uri { get; set; }
        public string balance { get; set; }
    }

    async static public Task<List<string>> CheckNFT()
    {
        string chain = "binance";
        string network = "testnet"; // mainnet ropsten kovan rinkeby goerli
        string account = PlayerPrefs.GetString("Account");
        // string account = "0x23FdC87bEeC6da70cFD285eD947550fcA69a6e38";
        string contract = "";
        int first = 500;
        int skip = 0;
        string response = await EVM.AllErc721(chain, network, account, contract, first, skip);
        try
        {
            NFTs[] erc721s = JsonConvert.DeserializeObject<NFTs[]>(response);
            if (erc721s.Length > 0)
            {
                return new List<string> { erc721s[0].contract, erc721s[0].tokenId };
            }
            else
            {
                return null;
            }
            // for (int i = 0; i < erc721s.Length; i++) {
            //     print(String.Format("第{0}", i));
            //     print(erc721s[i].contract);
            //     print(erc721s[i].tokenId);
            //     print(erc721s[i].uri);
            //     print(erc721s[i].balance);
            // }
        }
        catch
        {
            print("Error: " + response);
            return null;
        }
    }
}
