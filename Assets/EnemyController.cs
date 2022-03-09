using UnityEngine;

public class EnemyController : MonoBehaviour
{  
    [SerializeField] int _hp;
    [SerializeField] int _hpMax;
    [SerializeField] GameObject hpBar;

    void Start() {
       _hpMax = 100;
       _hp = _hpMax;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            //敵人與玩家的距離判定
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) <= 3){
                Debug.Log("有打中 !");
                _hp -= 20;

                if(_hp <= 0){ //敵人死亡
                    hpBar.transform.localScale = new Vector3(0, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
                    Destroy(this.gameObject);
                    return;
                }

                //敵人未死亡
                float _percent =((float)_hp / (float)_hpMax);
                hpBar.transform.localScale = new Vector3(_percent, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
                
            }
                
        }
    }
}
