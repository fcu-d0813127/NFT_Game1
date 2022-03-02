using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EntryControllor : MonoBehaviour
{
    
    // [SerializeField] int thisScenes =  SceneManager.GetActiveScene().buildIndex;
    // [SerializeField] int nextScenes;
    void OnCollisionEnter2D(Collision2D other) //碰撞判定
    {
        if (other.gameObject.tag == "Player") //當碰撞到的是玩家
        {   
            //下面的2和1，亦可替換成nextScenes，更有彈性
            if(GetComponent<Renderer>().tag == "entry"){
                Debug.Log("玩家碰到入口");          
                SceneManager.LoadScene(2);
                GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3(7.0f,3.8f, 0);
                
            }

            else if(GetComponent<Renderer>().tag == "exit"){
                //DontDestroyOnLoad(player);
                Debug.Log("玩家碰到出口");
                SceneManager.LoadScene(1);
                GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3(-7.0f, -3.8f, 0);
                
            }
            

        }
    }
}
