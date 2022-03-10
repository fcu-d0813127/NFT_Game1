using UnityEngine;

public class PlayerController : MonoBehaviour {
  // 控制玩家是否可以移動
  public bool Enable;
  // [SerializeField] : 很像private，但在unity右側欄位可看到 
  [SerializeField] float _moveSpeed;
  
  void Start() {
    Enable = true;
    _moveSpeed = 10.0f;
  }

  // Update is called once per frame
  // Time.deltaTime : Update與下一次update時間花了多久，可解決電腦速度不同執行速度差異
  void Update() {
    if (!Enable) {
      GetComponent<Animator>().SetBool("isRun", false);
      return;
    }
    if (Input.GetKey(KeyCode.RightArrow)) {
      GetComponent<SpriteRenderer>().flipX = false;
      transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
    } else if (Input.GetKey(KeyCode.LeftArrow)) {
      GetComponent<SpriteRenderer>().flipX = true;
      transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
    }
    if (Input.GetKey(KeyCode.UpArrow)) {
      transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
    } else if (Input.GetKey(KeyCode.DownArrow)) {
      transform.Translate(0, -_moveSpeed * Time.deltaTime, 0);
    }
    // 角色移動動畫
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
        Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
      GetComponent<Animator>().SetBool("isRun", true);
    } else {
      GetComponent<Animator>().SetBool("isRun", false);
    }
    // 角色攻擊動畫
    if (Input.GetKey(KeyCode.K)) {
      GetComponent<Animator>().SetBool("isAttack", true); //利用isAttack這個bool去判定玩家是否在攻擊而播出動畫!
    } else {
      GetComponent<Animator>().SetBool("isAttack", false);
    }
  }
}
