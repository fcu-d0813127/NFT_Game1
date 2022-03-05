using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class EntryController : MonoBehaviour {
  string _hash;
  GameObject _player;
  PlayerController _playerScript;

  void Start() {
    _player = GameObject.Find("Player");
    _playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  //碰撞判定
  async void OnCollisionEnter2D(Collision2D collision) {
    //當碰撞到的是玩家
    if (collision.gameObject.tag == "Player") {
      //下面的2和1，亦可替換成nextScenes，更有彈性
      if (tag == "entry") {
        _playerScript.Enable = false;
        try {
          _hash = await WebGL.Send.OnMoveSite(2);
          await StatusCheck.Check(_hash);
          SceneManager.LoadScene(3);
          _player.transform.position = new Vector3(7.0f, 3.8f, 0);
        } catch (Exception e) {
          Debug.LogException(e, this);
        }
        _playerScript.Enable = true;
      } else if ( tag == "exit" ) {
        _playerScript.Enable = false;
        try {
          _hash = await WebGL.Send.OnMoveSite(1);
          await StatusCheck.Check(_hash);
          SceneManager.LoadScene(2);
          _player.transform.position = new Vector3(-7.0f, -3.8f, 0);
        } catch (Exception e) {
          Debug.LogException(e, this);
        }
        _playerScript.Enable = true;
      }
    }
  }
}
