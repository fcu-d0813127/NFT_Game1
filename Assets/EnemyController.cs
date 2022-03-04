using UnityEngine;

public class EnemyController : MonoBehaviour
{
    string Hash;
    bool Debounce;
    void Start() {
        Debounce = false;
    }
    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            //敵人與玩家的距離判定
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 5)
            {
                if (Debounce) {
                    return;
                }
                Debounce = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Enable = false;
                Hash = await WebGLSend.OnEntityOperation();
                if (ContractError.CheckError(Hash)) {
                    return;
                }
                await StatusCheck.Check(Hash);
                this.gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Enable = true;
            }
        }
    }
}
