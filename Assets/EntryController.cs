using UnityEngine.SceneManagement;
using UnityEngine;

public class EntryController : MonoBehaviour
{
    [SerializeField] int enemyNum; //俊哥用這裡接合約ㄉ咚咚
    void OnCollisionEnter2D(Collision2D other) //碰撞判定
    {
        if (other.gameObject.tag == "Player") //當碰撞到的是玩家
        {   
            //下面的2和1，亦可替換成nextScenes，更有彈性
            if(GetComponent<Renderer>().tag == "entry"){
                enemyNum = 3;
                PlayerPrefs.SetInt("enemyNum", enemyNum);  //將怪物數存在"enemyNum"的key 
                SceneManager.LoadScene(2);
                GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3(7.0f, 3.8f, 0);
                Debug.Log(PlayerPrefs.GetInt("enemyNum"));
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
