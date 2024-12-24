using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{

    [Header("UI Objects")]
    public Button playBtn;
    public Slider musicSlider;
    public Slider soundSlider;

    [Header("Sounds")]
    public AudioSource[] musicBG;
    public AudioSource sound;
    void Start()
    {
        playBtn.onClick.AddListener(StartGame);

        sound.volume = soundSlider.value;
        soundSlider.onValueChanged.AddListener(SetVolume);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SetVolume(float volume)
    {
        sound.volume = volume;
        Debug.Log("sound Volume" + sound.volume );
    }
}
