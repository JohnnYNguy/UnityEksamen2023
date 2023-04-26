// Importing necessary Unity libraries which comes with autcompletion when writing code thanks to visual :)
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// calling our class MusicController, inheriting from MonoBehaviour  
public class MusicController : MonoBehaviour
{
    // Defining instance variable as static to make it a singleton
    public static MusicController instance;

    // Creating a AudioSource variable to hold music audio
    public AudioSource musicSource;

    // Creating float variable to hold volume value
    public float volumeSlider;

    // Adding a Slider variable to reference the Slider component
    private Slider sliderComponent;

    // Awake method is called when script instance is being loaded
    void Awake()
    {
        // Check if instance is null, if so set instance as this and then continue between scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // If instance already exists, destroy this instance
        {
            Destroy(gameObject);
        }
    }

    // Start method is called on the first frame the script is active so only activate once after game starts
    void Start()
    {
        // Add OnSceneLoaded method to sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // If the active scene is the main menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Find the Slider component in the OptionsMenu canvas and set its value, to get to slider we had to set filepath like this "Canvas/OptionsMenu/Slider"
            sliderComponent = GameObject.Find("Canvas/OptionsMenu/Slider").GetComponent<Slider>();
            sliderComponent.onValueChanged.AddListener(OnVolumeChanged);
            sliderComponent.value = volumeSlider; // setting the Slider value using the float variable
        }
    }

    // OnSceneLoaded method is called after a new scene has finished loading
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the loaded scene is the main menu
        if (scene.name == "MainMenu")
        {
            // Find the Slider component in the OptionsMenu canvas and set its value, to get to slider we had to set filepath like this "Canvas/OptionsMenu/Slider"
            sliderComponent = GameObject.Find("Canvas/OptionsMenu/Slider").GetComponent<Slider>();
            sliderComponent.onValueChanged.AddListener(OnVolumeChanged);
            sliderComponent.value = volumeSlider; // setting the Slider value using the float variable
        }
        else // Otherwise, play the music
        {
            musicSource.Play();
        }
    }

    // OnVolumeChanged method is called when the slider value for volume changes
    void OnVolumeChanged(float volume)
    {
        // a debugger for checkiing if it does actually change the volumes value by using slider
        Debug.Log("Volume changed to: " + volume);
        volumeSlider = volume;
        musicSource.volume = volumeSlider;
    }

    // OnDestroy method is called when the script is being destroyed
    void OnDestroy()
    {
        // If the Slider component exists, remove the OnVolumeChanged event listener and set the volumeSlider value
        if (sliderComponent != null)
        {
            sliderComponent.onValueChanged.RemoveListener(OnVolumeChanged);
            volumeSlider = sliderComponent.value;
        }
    }
}
