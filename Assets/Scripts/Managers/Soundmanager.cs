using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource;  // 배경음악용 AudioSource
    public AudioSource sfxSource;              // 효과음용 AudioSource

    [Header("Audio Clips")]
    public AudioClip titleBGM;                 // Title 씬 배경음악
    public AudioClip inGameBGM;                // InGame 씬 배경음악
    public AudioClip itemCollectSound;         // 아이템 수집 효과음

    private static SoundManager instance; // Singleton 인스턴스

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때마다 OnSceneLoaded 호출
        PlayBackgroundMusic(); // 시작 시 배경음악 재생
    }

    // 씬이 로드될 때 호출되는 메서드
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundMusic(); // 씬 전환 시 배경음악 변경
    }

    // 배경음악 재생
    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource == null)
            return;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                backgroundMusicSource.clip = titleBGM;
                break;
            case "InGame":
                backgroundMusicSource.clip = inGameBGM;
                break;
            default:
                backgroundMusicSource.clip = null;
                break;
        }

        if (backgroundMusicSource.clip != null)
        {
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    // 아이템 수집 효과음 재생
    public void PlayItemCollectSound()
    {
        if (sfxSource != null && itemCollectSound != null)
        {
            sfxSource.PlayOneShot(itemCollectSound);
        }
    }
}


