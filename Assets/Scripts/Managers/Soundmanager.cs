using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource;  // ������ǿ� AudioSource
    public AudioSource sfxSource;              // ȿ������ AudioSource

    [Header("Audio Clips")]
    public AudioClip titleBGM;                 // Title �� �������
    public AudioClip inGameBGM;                // InGame �� �������
    public AudioClip itemCollectSound;         // ������ ���� ȿ����

    private static SoundManager instance; // Singleton �ν��Ͻ�

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
        SceneManager.sceneLoaded += OnSceneLoaded; // ���� �ε�� ������ OnSceneLoaded ȣ��
        PlayBackgroundMusic(); // ���� �� ������� ���
    }

    // ���� �ε�� �� ȣ��Ǵ� �޼���
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundMusic(); // �� ��ȯ �� ������� ����
    }

    // ������� ���
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

    // ������ ���� ȿ���� ���
    public void PlayItemCollectSound()
    {
        if (sfxSource != null && itemCollectSound != null)
        {
            sfxSource.PlayOneShot(itemCollectSound);
        }
    }
}


