using UnityEngine;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour
{
    public void restgame()
    {
        SceneManager.LoadScene("遊戲場景");

    }

    public void quit()
    {
        Application.Quit();
    }
}
