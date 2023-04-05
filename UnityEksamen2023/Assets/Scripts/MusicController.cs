using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource musicSource;
    public Slider volumeSlider;

    void Awake()
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

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            volumeSlider = GameObject.Find("SliderForMusicAdjsut").GetComponent<Slider>();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "OptionsMenu")
        {
            musicSource.Play();
        }
    }

    void OnVolumeChanged(float volume)
    {
        musicSource.volume = volume;
    }
}
