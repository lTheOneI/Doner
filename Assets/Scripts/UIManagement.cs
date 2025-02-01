using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{

    [Header("UI Objects")]
    public Button playBtn;
    public GameObject settingPanel;
    public Slider musicSlider;
    public Slider soundSlider;

    [Header("Sounds")]
    public AudioSource[] musicBG;
    public AudioSource sound;

    private bool isPaused;
    private int currenTrackIndex = -1;
    void Start()
    {
        playBtn.onClick.AddListener(StartGame);

        sound.volume = soundSlider.value;
        soundSlider.onValueChanged.AddListener(SetVolume);

        //BG Music play randomly
        if (musicBG.Length > 0)
        {
            PlayRandomTrack();
        }
    }

    void Update()
    {
        if (!musicBG[currenTrackIndex].isPlaying)
        {
            PlayRandomTrack();
        }
        if (settingPanel.activeSelf)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PlayRandomTrack()
    {
        int newTrackIndex;
        do
        {
            newTrackIndex = Random.Range(0, musicBG.Length);
        }
        while (newTrackIndex == currenTrackIndex);
        if (newTrackIndex == currenTrackIndex )
        {
            musicBG[currenTrackIndex].Stop();
        }

        currenTrackIndex = newTrackIndex;
        musicBG[currenTrackIndex].Play();

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

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
