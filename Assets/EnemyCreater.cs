using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Start()
    {
        if( PlayerPrefs.GetInt("enemyNum") == 0){
           gameObject.SetActive(false);
        }
        else{
            for(int i = 0; i < PlayerPrefs.GetInt("enemyNum") - 1; i++){
                Instantiate(enemy, new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(-3.5f, 3.5f), 0), Quaternion.identity);
            }
           
       }
    }
}
