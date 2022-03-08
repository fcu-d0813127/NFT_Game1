using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EnemyController : MonoBehaviour {
  string _hash;
  bool _debounce;
  GameObject _player;
  PlayerController _playerScript;

  void Start() {
    _debounce = false;
    _player = GameObject.Find("Player");
    _playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }
  
  // Update is called once per frame
  async void Update() {
    if (Input.GetKey(KeyCode.K)) {
      //敵人與玩家的距離判定
      if (Vector3.Distance(transform.position, _player.transform.position) <= 5) {
        if (_debounce) {
          return;
        }
        _debounce = true;
        _playerScript.Enable = false;
        try {
          _hash = await WebGL.Send.OnKillEnemy(SceneManager.GetActiveScene().buildIndex);
          await StatusCheck.Check(_hash);
          this.gameObject.SetActive(false);
        } catch (Exception e) {
          Debug.LogException(e, this);
          _debounce = false;
        }
        _playerScript.Enable = true;
      }
    }
  }
}
