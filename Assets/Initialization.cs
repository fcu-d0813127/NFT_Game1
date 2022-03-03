using UnityEngine.SceneManagement;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //直接載入下個場景，並讓玩家不被摧毀
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(Player);
    }
}
