using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public AudioSource musicSource;
    public Button toggleButton;
    public Slider volumeSlider;

    private bool isPlaying = true;

    private static MusicToggle instance;

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
        // Check if UI elements are assigned
        if (toggleButton != null && volumeSlider != null)
        {
            toggleButton.onClick.AddListener(ToggleMusic);
            volumeSlider.value = musicSource.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            // Disable the script if UI elements are not present
            this.enabled = false;
        }
    }

    void ToggleMusic()
    {
        if (isPlaying)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }
        isPlaying = !isPlaying;
    }

    void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    private void OnEnable()
    {
        // Re-check if UI elements are present when the script is enabled
        if (toggleButton == null || volumeSlider == null)
        {
            this.enabled = false;
        }
    }
}
