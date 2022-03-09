using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EnemyController : MonoBehaviour {
  int _hp;
  int _hpMax;
  string _hash;
  GameObject _player;
  PlayerController _playerScript;
  [SerializeField] GameObject _hpBar;

  void Start() {
    _hpMax = 100;
    _hp = _hpMax;
    _hpBar.transform.localScale = new Vector3(1, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
    _player = GameObject.Find("Player");
    _playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }
  
  // Update is called once per frame
  async void Update() {
    if (Input.GetKeyDown(KeyCode.K)) {
      //敵人與玩家的距離判定
      if (Vector3.Distance(transform.position, _player.transform.position) <= 5) {
        _hp -= 20;
        if (_hp <= 0) { //敵人死亡
          _hpBar.transform.localScale = new Vector3(0, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
          _playerScript.Enable = false;
          Destroy(this.gameObject);
          try {
            _hash = await WebGL.Send.OnKillEnemy(SceneManager.GetActiveScene().buildIndex);
            await StatusCheck.Check(_hash);
          } catch (Exception e) {
            Debug.LogException(e, this);
          }
          _playerScript.Enable = true;
        } else {
          //敵人未死亡
          float percent = ((float)_hp / (float)_hpMax);
          _hpBar.transform.localScale = new Vector3(percent, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
        }
      }
    }
  }
}
