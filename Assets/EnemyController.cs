using UnityEngine;

public class EnemyController : MonoBehaviour
{  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            //敵人與玩家的距離判定
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) <= 5)
                gameObject.SetActive(false);
        }
    }
}
