using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] : 很像private，但在unity右側欄位可看到 
    [SerializeField] float move_speed = 10.0f;
    void Start()
    { 
    
        
    }
    
    // Update is called once per frame
    // Time.deltaTime : Ubpdate與下一次update時間花了多久，可解決電腦速度不同執行速度差異
    void Update()
    {
       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(move_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(-move_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, move_speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -move_speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.K)) //此處僅做動畫偵測
        {
            GetComponent<Animator>().SetBool("isAttack", true); //利用isAttack這個bool去判定玩家是否在攻擊而播出動畫!
        }
        else{
            GetComponent<Animator>().SetBool("isAttack", false);
        }
    }
}