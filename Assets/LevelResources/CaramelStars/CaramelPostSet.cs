using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;

namespace LevelResources.CaramelStars
{
    public class CaramelPostSet : MonoBehaviour
{
    
    private PostProcessVolume profile1;
    private PostProcessVolume profile2;
    private Vignette vignette;
    private ColorGrading colorGrading;
    private DepthOfField depthOfField;
    private Bloom bloom;
    [SerializeField] private bool isProfile2;

    [Header("暗角")]
    public bool setVignette;
    [SerializeField] private float fadeTime = 1f;
    [Range(0, 1),SerializeField] private float vignetteIndex = 0.6f;

    [Header("对比度")]
    public bool setSaturation;
    [SerializeField] private float changeTime = 1f;
    [Range(-100, 100),SerializeField] private float saturationIndex = 0.6f;

    [Header("模糊半径")]
    public bool setDepthInField;
    [SerializeField] private float depthTime = 1f;
    [SerializeField] private float depthIndex = 14f;
    
    [Header("辉光")]
    public bool setBloom;
    [SerializeField] private float bloomTime = 1f;
    [SerializeField] private float bloomIndex = 2f;

    void Start()
    {
        profile1 = GameObject.Find("Camera").GetComponent<PostProcessVolume>();
        profile2 = GameObject.Find("P3Post").GetComponent<PostProcessVolume>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isProfile2)
            {
                profile1.profile.TryGetSettings(out vignette);
                profile1.profile.TryGetSettings(out colorGrading);
                profile1.profile.TryGetSettings(out depthOfField);
                profile1.profile.TryGetSettings(out bloom);
            }
            else
            {
                profile2.profile.TryGetSettings(out vignette);
                profile2.profile.TryGetSettings(out colorGrading);
                profile2.profile.TryGetSettings(out depthOfField);
                profile2.profile.TryGetSettings(out bloom);
            }
            
            if (setVignette) FadeIn();
            if(setSaturation) SetIn();
            if(setDepthInField) DepthIn();
            if(setBloom) BloomIn();
        }
    }

    private void FadeIn()
    {
        DOTween.To(()=> vignette.intensity.value, x => vignette.intensity.value = x, vignetteIndex, fadeTime).SetEase(Ease.InOutSine);
    }

    private void SetIn()
    {
        DOTween.To(()=> colorGrading.saturation.value, x => colorGrading.saturation.value = x, saturationIndex, changeTime).SetEase(Ease.InOutSine);
    }

    private void DepthIn()
    {
        DOTween.To(()=> depthOfField.focusDistance.value, x => depthOfField.focusDistance.value = x, depthIndex, depthTime).SetEase(Ease.InOutSine);
    }

    private void BloomIn()
    {
        DOTween.To(()=> bloom.intensity.value, x => bloom.intensity.value = x, bloomIndex, bloomTime).SetEase(Ease.InOutSine);
    }
}
}