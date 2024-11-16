using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Ok : MonoBehaviour
{
    [SerializeField] private GameObject Instructions;
    public void Clicked()
    {
        Instructions.gameObject.SetActive(false);
    }
    
   //public GameObject[] optionPanels; //Drag and drop values in the inspector. These are your canvases, or however you have your option boxes setup.

//    public void openPanel(GameObject selectPanel)
//    {
//    //    foreach (GameObject opPanel in optionPanels)
//    //    {
//    //        opPanel.SetActive(false);
//    //    }

//    //    selectPanel.SetActive(true);
//    //}
}


