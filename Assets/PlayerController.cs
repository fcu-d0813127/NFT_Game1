using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] : 很像private，但在unity右側欄位可看到 
    [SerializeField] float move_speed = 10.0f;
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject entry0to1;
    [SerializeField] GameObject entry1to0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // Time.deltaTime:Update與下一次update時間花了多久，可解決電腦速度不同執行速度差異
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


        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log(Vector3.Distance(enemy.transform.position, transform.position));
            if (Vector3.Distance(enemy.transform.position, transform.position) <= 3)
                enemy.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "entry0to1")
        {
            Debug.Log("撞到了啦");
            if (!background1.activeSelf)
            {
                return;
            }
            entry0to1.SetActive(false);
            entry1to0.SetActive(true);
            background1.SetActive(false);
            background2.SetActive(true);
            enemy.SetActive(true);
            transform.position = new Vector3(7.0f, 3.8f, 0);
        }
        else if (other.gameObject.tag == "entry1to0")
        {
            if (background1.activeSelf)
            {
                return;
            }
            entry0to1.SetActive(true);
            entry1to0.SetActive(false);
            background1.SetActive(true);
            background2.SetActive(false);
            enemy.SetActive(false);
            transform.position = new Vector3(-7.0f, -3.8f, 0);
        }
        else{
            Debug.Log("撞到未知的東西，建議檢查程式!");
        }
    }
}