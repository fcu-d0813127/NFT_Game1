using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyControllor : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            //敵人與玩家的距離判定
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position) <= 3)
                gameObject.SetActive(false);
        }
    }
}
