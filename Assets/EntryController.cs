using UnityEngine.SceneManagement;
using UnityEngine;

public class EntryController : MonoBehaviour {
    [SerializeField] int _enemyNum; //俊哥用這裡接合約ㄉ咚咚
    void OnCollisionEnter2D(Collision2D other) {//碰撞判定
        int _index = SceneManager.GetActiveScene().buildIndex;
        if (other.gameObject.tag == "Player") {  //當碰撞到的是玩家
           
            if(GetComponent<Renderer>().tag == "entry"){
                _enemyNum = 3;
                PlayerPrefs.SetInt("enemyNum", _enemyNum);  //將怪物數存在"enemyNum"的key 
                SceneManager.LoadScene(_index + 1);
                GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3(7.0f, 3.8f, 0);
                Debug.Log(PlayerPrefs.GetInt("enemyNum"));

            } else if(GetComponent<Renderer>().tag == "exit"){
                SceneManager.LoadScene(_index - 1);
                GameObject.FindGameObjectWithTag ("Player").transform.position = new Vector3(-7.0f, -3.8f, 0);
            }

        }
    }
}
