using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundMaanger : MonoBehaviour
{
    [SerializeField] public Button soundOnButton;
    [SerializeField] public Button soundOffButton;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1f);
        // Set up button listeners
        soundOnButton.onClick.AddListener(TurnSoundOn);
        soundOffButton.onClick.AddListener(TurnSoundOff);


    }
    private void TurnSoundOn()
    {
        AudioListener.volume = 1f;
        PlayerPrefs.SetFloat("Volume", 1f);
        //UpdateButtonVisibility();
    }

    private void TurnSoundOff()
    {
        AudioListener.volume = 0f;
        PlayerPrefs.SetFloat("Volume", 0f);
        //UpdateButtonVisibility();
    }
}
