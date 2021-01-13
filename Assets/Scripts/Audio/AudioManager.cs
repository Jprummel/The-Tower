using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager s_Instance;
    [SerializeField] private AudioSource m_MusicPlayer;
    [SerializeField] private List<AudioClip> m_Songs = new List<AudioClip>();
    [SerializeField] private List<AudioClip> m_SoundEffects = new List<AudioClip>();

    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        PlaySong(SceneManager.GetActiveScene().name);
    }

    public void PlaySong(string song)
    {
        m_MusicPlayer.PlayOneShot(GetSongByName(song));
    }

    public void FadeIntoNewSong(string newSong)
    {
        if (m_MusicPlayer.isPlaying)
        {

        }
    }

    public void PlaySoundEffect(string sfx)
    {
        AudioSource source = new GameObject().AddComponent<AudioSource>();
        AudioClip SoundEffect = GetSoundEffectByName(sfx);
        source.PlayOneShot(SoundEffect);
        StartCoroutine(DestroyTemporaryObject(source.gameObject, SoundEffect.length));
    }

    IEnumerator DestroyTemporaryObject(GameObject objectToDestroy, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(objectToDestroy);
    }

    public AudioClip GetSongByName(string songName)
    {
        for (int i = 0; i < m_Songs.Count; i++)
        {
            if (m_Songs[i].name == songName)
            {
                return m_Songs[i];
            }
        }
        return null;
    }

    public AudioClip GetSoundEffectByName(string sfxName)
    {
        for (int i = 0; i < m_SoundEffects.Count; i++)
        {
            if (m_SoundEffects[i].name == sfxName)
            {
                return m_SoundEffects[i];
            }
        }
        return null;
    }
}