using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void LoadGameUI()
    {
        SceneManager.LoadScene("Game_UI");
    }
}
