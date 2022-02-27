using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ERC721URIExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "binance";
        string network = "testnet";
        string contract = "0xB3A055A9Ca56EB02B2B8bD893D1d8E010eF87A5d";
        string tokenId = "1";

        string uri = await ERC721.URI(chain, network, contract, tokenId);

        // fetch image and display in game
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(uri);
        await textureRequest.SendWebRequest();
        Texture2D image = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0, 0));
        this.gameObject.transform.position = new Vector3(-image.width / (2.0f * 100.0f), -image.height / (2.0f * 100.0f), 0);
    }
}
