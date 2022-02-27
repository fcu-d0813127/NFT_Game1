using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    // [SerializeField]:是private，但仍能出現在inspector
    [SerializeField] float move_speed;
    string now_background;
    string now_hash;
    // 透過Unity assign的Object
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject nft_show;
    // 控制玩家是否可移動
    bool enable_player;
    // 交易相關Object
    WebGLSendContractExample transaction;
    WebGLReadSite read;
    WebGLInitPlayer init;
    StatusCheck check;

    // Start is called before the first frame update
    async void Start()
    {
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
            background2.SetActive(false);
            enemy.SetActive(false);
            nft_show.SetActive(true);
        }
        else if (now_background == "2")
        {
            background1.SetActive(false);
            background2.SetActive(true);
            enemy.SetActive(true);
            nft_show.SetActive(false);
        }
        enable_player = true;
    }

    // Update is called once per frame
    // Time.deltaTime:這一次Update()與下一次Update()呼叫之間隔時間，可解決個別電腦速度不同造成之呼叫速度差異
    void Update()
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
            enemy.SetActive(false);
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
        // 目前判斷方式為透過碰撞的法線來判斷左右
        if (other.contacts[0].normal == new Vector2(1.0f, 0))
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
            nft_show.SetActive(false);
            // 控制玩家切換場景後的初始位置
            transform.position = new Vector3(7.0f, -3.8f, 0);
        }
        else if (other.contacts[0].normal == new Vector2(-1.0f, 0))
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
            nft_show.SetActive(true);
            // 控制玩家切換場景後的初始位置
            transform.position = new Vector3(-7.0f, -3.8f, 0);
        }
    }
}
