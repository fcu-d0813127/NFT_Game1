using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Initialization : MonoBehaviour
{
    [SerializeField] GameObject Player;
    string SceneNumber;
    string Hash;

    // Start is called before the first frame update
    async void Start()
    {
        // 讀取玩家最後離開遊戲時的場景
        SceneNumber = await WebGLReadSite.OnSendContract();
        // 該玩家為第一次遊玩，先初始化
        if (SceneNumber == "0")
        {
            Hash = await WebGLInitPlayer.OnSendContract();
            if (ContractError.CheckError(Hash)) {
                return;
            }
            await StatusCheck.Check(Hash);
            SceneNumber = await WebGLReadSite.OnSendContract();
        }
        //載入場景，並讓玩家不被摧毀
        SceneManager.LoadScene(Int32.Parse(SceneNumber) + 1);
        DontDestroyOnLoad(Player);
    }
}
