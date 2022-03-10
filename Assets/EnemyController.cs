using UnityEngine;

public class EnemyController : MonoBehaviour {
  int _hp;
  int _hpMax;
  string _hash;
  GameObject _player;
  [SerializeField] GameObject _hpBar;

  void Start() {
    _hpMax = 100;
    _hp = _hpMax;
    _hpBar.transform.localScale = new Vector3(1, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
    _player = GameObject.Find("Player");
  }

  void Lock() {
    while (PlayerPrefs.GetInt("s") == 0);
    PlayerPrefs.SetInt("s", PlayerPrefs.GetInt("s") - 1);
  }

  void UnLock() {
    PlayerPrefs.SetInt("s", PlayerPrefs.GetInt("s") + 1);
  }
  
  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.K)) {
      //敵人與玩家的距離判定
      if (Vector3.Distance(transform.position, _player.transform.position) <= 5) {
        _hp -= 20;
        if (_hp <= 0) { //敵人死亡
          _hpBar.transform.localScale = new Vector3(0, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
          Destroy(this.gameObject);
          Lock();
          PlayerPrefs.SetInt("killEnemyNum", PlayerPrefs.GetInt("killEnemyNum") + 1);
          UnLock();
        } else {
          //敵人未死亡
          float percent = ((float)_hp / (float)_hpMax);
          _hpBar.transform.localScale = new Vector3(percent, _hpBar.transform.localScale.y, _hpBar.transform.localScale.z);
        }
      }
    }
  }
}
