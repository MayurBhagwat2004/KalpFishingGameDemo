using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [Header("Background Music")]
    public AudioClip menuMusic;
    public AudioClip fishingMusic;
    
    public AudioClip castLineClip;
    public AudioClip fishBiteClip;
    public AudioClip catchSuccessClip;
    public AudioClip catchFailClip;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayMusic(menuMusic);
    }

    void Update()
    {
        
    }

    public void PlayMusic(AudioClip clip)
    {
        if(musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.Play();
    }
    
    public void PlaySfx(AudioClip clip)
    {
        if(clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
