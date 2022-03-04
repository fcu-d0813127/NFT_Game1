using UnityEngine;

public class EnemyController : MonoBehaviour
{  
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position));
            
            //敵人與玩家的距離判定
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) <= 3)
                gameObject.SetActive(false);
        }
    }
}
