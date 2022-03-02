using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Init : MonoBehaviour
{
    // public int sceneIndex;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //直接載入下個場景，並讓玩家不被摧毀
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(player);

    }
}
