using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TraderController : MonoBehaviour {
  string _hash;
  PlayerController _playerScript;

  void Start() {
    _playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }
  async void OnCollisionEnter2D(Collision2D collision) {
    if (PlayerPrefs .GetInt("killEnemyNum") != 0 && collision.gameObject.tag == "Player") {
      _playerScript.Enable = false;
      try {
        _hash = await WebGL.Send.OnKillEnemy(SceneManager.GetActiveScene().buildIndex, PlayerPrefs.GetInt("killEnemyNum"));
        await StatusCheck.Check(_hash);
      } catch (Exception e) {
        Debug.LogException(e, this);
      }
      _playerScript.Enable = true;
    }
  }
}
