using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }	
	}
    void OnLevelWasLoaded(int Level)
    {
        if (music == null)
            return;
        music.Stop();
        switch (Level)
        {
            case 0:
                music.clip = startClip;
                break;
            case 1:
                music.clip = gameClip;
                break;
            case 2:
                music.clip = endClip;
                break;
            default:
                break;
        }
        music.loop = true;
        music.Play();
    }
}
