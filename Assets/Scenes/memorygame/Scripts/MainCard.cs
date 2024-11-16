using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUniqueSpace;

public class MainCard : MonoBehaviour
{
    [SerializeField] private MyUniqueSpace.SceneController controller;
    [SerializeField] private GameObject Card_Back;
    private pauseMenu pause_menu;

    private void Start()
    {

        pause_menu = FindObjectOfType<pauseMenu>();

    }

    public void OnMouseDown()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        if (Card_Back.activeSelf && controller.canReveal)
            Card_Back.SetActive(false);
            controller.CardRevealed(this);
    }



    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }


    public void Unreveal()
    {
        Card_Back.SetActive(true);
    }



}//end class
 