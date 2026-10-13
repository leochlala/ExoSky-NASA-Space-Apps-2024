using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class PostProcessingBehaviour : MonoBehaviour
{
    private PostProcessVolume volume;
    private Vignette vignette;

    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette); 
    }

    public void SetVignetteIntensity(float intensity)
    {
        if (vignette != null)
        {
            vignette.intensity.value = intensity; 
        }
        else
        {
            Debug.LogWarning("Vignette is not set in the Post Process Profile!");
        }
    }

    public void TogglePostProcessing(bool isActive)
    {
        volume.enabled = isActive; 
    }
}
