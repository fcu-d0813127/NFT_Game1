using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Initialization : MonoBehaviour {
  [SerializeField] GameObject _player;
  string _sceneNumber;
  string _hash;

  // Start is called before the first frame update
  async void Start() {
    // 讀取玩家最後離開遊戲時的場景
    _sceneNumber = await WebGL.Call.OnReadSite();
    // 該玩家為第一次遊玩，先初始化
    while (_sceneNumber == "0") {
      try {
        _hash = await WebGL.Send.OnInitPlayer();
        await StatusCheck.Check(_hash);
      } catch (Exception e) {
        Debug.LogException(e, this);
      }
      _sceneNumber = await WebGL.Call.OnReadSite();
    }
    //載入場景，並讓玩家不被摧毀
    string enemyNum = await WebGL.Call.OnReadEnemyNum(Int32.Parse(_sceneNumber));
    PlayerPrefs.SetInt("enemyNum", Int32.Parse(enemyNum));
    SceneManager.LoadScene(Int32.Parse(_sceneNumber));
    DontDestroyOnLoad(_player);
  }
}
