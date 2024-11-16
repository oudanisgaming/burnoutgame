using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour

{

    // Start is called before the first frame update

    public void GoBackToRoom()
    {
        SceneManager.LoadScene("The_Room");
        //SceneManager.LoadSceneAsync(1);

    }
        

}
