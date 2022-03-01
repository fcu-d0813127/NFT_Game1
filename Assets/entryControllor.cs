using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class entryControllor : MonoBehaviour
{
    
    [SerializeField] int thisScenes =  SceneManager.GetActiveScene().buildIndex;
    [SerializeField] int nextScenes;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    void OnCollisionEnter2D(Collision2D other) //碰撞判定
    {
        if (other.gameObject.tag == "Player")
        {
            if(GetComponent<Renderer>().tag == "entry"){
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

            else if(GetComponent<Renderer>().tag == "exit"){
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
            
        }
    }
}
