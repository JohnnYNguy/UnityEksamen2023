using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource musicSource;
    public float volumeSlider;

    private Slider sliderComponent; // added variable to reference the Slider component

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

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            sliderComponent = GameObject.Find("Canvas/OptionsMenu/Slider").GetComponent<Slider>();
            sliderComponent.onValueChanged.AddListener(OnVolumeChanged);
            sliderComponent.value = volumeSlider; // setting the Slider value using the float variable
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            sliderComponent = GameObject.Find("Canvas/OptionsMenu/Slider").GetComponent<Slider>();
            sliderComponent.onValueChanged.AddListener(OnVolumeChanged);
            sliderComponent.value = volumeSlider; // setting the Slider value using the float variable
        }
        else
        {
            musicSource.Play();
        }
    }

    void OnVolumeChanged(float volume)
    {
        Debug.Log("Volume changed to: " + volume);
        volumeSlider = volume;
        musicSource.volume = volumeSlider;
    }

    void OnDestroy()
    {
        if (sliderComponent != null)
        {
            sliderComponent.onValueChanged.RemoveListener(OnVolumeChanged);
            volumeSlider = sliderComponent.value;
        }
    }
}
