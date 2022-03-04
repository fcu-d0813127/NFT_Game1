using UnityEngine.SceneManagement;
using UnityEngine;

public class EntryController : MonoBehaviour
{
    string Hash;

    async void OnCollisionEnter2D(Collision2D other) //碰撞判定
    {
        if (other.gameObject.tag == "Player") //當碰撞到的是玩家
        {
            //下面的2和1，亦可替換成nextScenes，更有彈性
            if (GetComponent<Renderer>().tag == "entry")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Enable = false;
                Hash = await WebGLSend.OnMoveSite(2);
                if (ContractError.CheckError(Hash)) {
                    return;
                }
                await StatusCheck.Check(Hash);
                SceneManager.LoadScene(3);
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(7.0f, 3.8f, 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Enable = true;
            }
            else if (GetComponent<Renderer>().tag == "exit")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Enable = false;
                Hash = await WebGLSend.OnMoveSite(1);
                if (ContractError.CheckError(Hash)) {
                    return;
                }
                await StatusCheck.Check(Hash);
                SceneManager.LoadScene(2);
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-7.0f, -3.8f, 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Enable = true;
            }
        }
    }
}
