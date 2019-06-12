using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public GameObject audioSourceGO;
    public AudioSource SoundAudio;
    public AudioSource MusicAudio;
    
  


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(audioSourceGO);
            return;
        }
      
        
        
    }

    public AudioSource Sound()
    {
        return SoundAudio;
        
    }

    public AudioSource Music()
    {
        return MusicAudio;

    }
}
