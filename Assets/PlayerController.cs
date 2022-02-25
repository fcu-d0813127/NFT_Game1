using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField]:是private，但仍能出現在inspector
    [SerializeField] float move_speed = 10.0f;
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // Time.deltaTime:這一次Update()與下一次Update()呼叫之間隔時間，可解決個別電腦速度不同造成之呼叫速度差異
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
            enemy.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.contacts[0].normal == new Vector2(1.0f, 0))
        {
            if (!background1.activeSelf)
            {
                return;
            }
            background1.SetActive(false);
            background2.SetActive(true);
            enemy.SetActive(true);
            transform.position = new Vector3(7.0f, -3.8f, 0);
        }
        else if (other.contacts[0].normal == new Vector2(-1.0f, 0))
        {
            if (background1.activeSelf)
            {
                return;
            }
            background1.SetActive(true);
            background2.SetActive(false);
            enemy.SetActive(false);
            transform.position = new Vector3(-7.0f, -3.8f, 0);
        }
    }
}
