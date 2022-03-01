using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] : 很像private，但在unity右側欄位可看到 
    [SerializeField] float move_speed;
    string now_background;
    string now_hash;
    bool debounce;
    // 透過Unity assign的Object
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject entry0to1;
    [SerializeField] GameObject entry1to0;
    [SerializeField] GameObject nft_show;
    // 控制玩家是否可移動
    bool enable_player;
    // 交易相關Object
    WebGLSendContractExample transaction;
    WebGLReadSite read;
    WebGLInitPlayer init;
    StatusCheck check;
    AttackEnemy attack_transaction;

    // Start is called before the first frame update
    async void Start()
    {
        // 連接component
        transaction = GetComponent<WebGLSendContractExample>();
        read = GetComponent<WebGLReadSite>();
        init = GetComponent<WebGLInitPlayer>();
        check = GetComponent<StatusCheck>();
        attack_transaction = GetComponent<AttackEnemy>();
        // 解決擊殺敵人時送出多次交易
        debounce = false;
        // 玩家移動速度
        move_speed = 10.0f;
        // 玩家是否可以移動
        enable_player = false;
        // 遊戲一開始先讀取當前玩家所在地圖
        await readSite();
        // 0: 新玩家, 1: 玩家最後遊玩位置為場景一, 2: 玩家最後遊玩位置為場景二
        if (now_background == "0")
        {
            // Call初始化的function
            now_hash = await init.OnSendContract();
            // 檢查目前交易狀態，直到交易完成
            await check.Check(now_hash);
            // 重新讀取玩家位置
            await readSite();
        }
        if (now_background == "1")
        {
            background1.SetActive(true);
            entry0to1.SetActive(true);
            nft_show.SetActive(true);
        }
        else if (now_background == "2")
        {
            background2.SetActive(true);
            entry1to0.SetActive(true);
            enemy.SetActive(true);
        }
        enable_player = true;
    }

    // Update is called once per frame
    // Time.deltaTime:Update與下一次update時間花了多久，可解決電腦速度不同執行速度差異
    async void Update()
    {
        if (!enable_player)
        {
            return;
        }
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

        // 敵人擊殺按鍵
        if (Input.GetKey(KeyCode.K))
        {
            GetComponent<Animator>().SetBool("isAttack", true); //利用isAttack這個bool去判定玩家是否在攻擊而播出動畫
            Debug.Log(Vector3.Distance(enemy.transform.position, transform.position));
            if (Vector3.Distance(enemy.transform.position, transform.position) <= 5)
            {
                if (!debounce)
                {
                    debounce = true;
                    enable_player = false;
                    now_hash = await attack_transaction.OnSendContract();
                    await check.Check(now_hash);
                    enemy.SetActive(false);
                    enable_player = true;
                }
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("isAttack", false);
        }
    }

    async Task readSite()
    {
        now_background = await read.OnSendContract();
    }

    async Task sendContract(int num)
    {
        now_hash = await transaction.OnSendContract(num);
        await check.Check(now_hash);
        await readSite();
    }

    // 碰撞
    async void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "entry0to1")
        {
            if (!background1.activeSelf)
            {
                return;
            }
            enable_player = false;
            await sendContract(2);
            enable_player = true;
            // 場景切換
            background1.SetActive(false);
            background2.SetActive(true);
            enemy.SetActive(true);
            entry0to1.SetActive(false);
            entry1to0.SetActive(true);
            nft_show.SetActive(false);
            // 控制玩家切換場景後的初始位置
            transform.position = new Vector3(7.0f, 3.8f, 0);
        }
        else if (other.gameObject.tag == "entry1to0")
        {
            if (background1.activeSelf)
            {
                return;
            }
            enable_player = false;
            await sendContract(1);
            enable_player = true;
            // 場景切換
            background1.SetActive(true);
            background2.SetActive(false);
            enemy.SetActive(false);
            entry0to1.SetActive(true);
            entry1to0.SetActive(false);
            nft_show.SetActive(true);
            // 控制玩家切換場景後的初始位置
            transform.position = new Vector3(-7.0f, -3.8f, 0);
        }

    }
}
