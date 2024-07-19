using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Serialization;

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
    [SerializeField] private float _fadeTime = 1f;
    [Range(0, 1),SerializeField] private float _vignetteIndex = 0.6f;

    [Header("对比度")]
    public bool _setSaturation;
    [SerializeField] private float _changeTime = 1f;
    [Range(-100, 100),SerializeField] private float _saturationIndex = 0.6f;

    [Header("模糊半径")]
    public bool _setDepthInField;
    [SerializeField] private float _depthTime = 1f;
    [SerializeField] private float _depthIndex = 14f;
    
    [Header("辉光")]
    public bool _setBloom;
    [SerializeField] private float _bloomTime = 1f;
    [SerializeField] private float _bloomIndex = 2f;

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
            if(_setSaturation) SetIn();
            if(_setDepthInField) DepthIn();
            if(_setBloom) BloomIn();
        }
    }

    private void FadeIn()
    {
        DOTween.To(()=> vignette.intensity.value, x => vignette.intensity.value = x, _vignetteIndex, _fadeTime).SetEase(Ease.InOutSine);
    }

    private void SetIn()
    {
        DOTween.To(()=> colorGrading.saturation.value, x => colorGrading.saturation.value = x, _saturationIndex, _changeTime).SetEase(Ease.InOutSine);
    }

    private void DepthIn()
    {
        DOTween.To(()=> depthOfField.focusDistance.value, x => depthOfField.focusDistance.value = x, _depthIndex, _depthTime).SetEase(Ease.InOutSine);
    }

    private void BloomIn()
    {
        DOTween.To(()=> bloom.intensity.value, x => bloom.intensity.value = x, _bloomIndex, _bloomTime).SetEase(Ease.InOutSine);
    }
}