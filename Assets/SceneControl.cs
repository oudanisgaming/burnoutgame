using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour
{
    

    public void GoBackToMenu()
    {
        //SceneManager.LoadScene("Game_ui");
        SceneManager.LoadSceneAsync(1);

    }
}

