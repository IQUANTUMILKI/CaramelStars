using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class CaramelPostSet : MonoBehaviour
{
    
    private PostProcessVolume _volume;
    private Vignette _vignette;
    private ColorGrading _colorGrading;
    private DepthOfField _depthOfField;
    private Bloom _bloom;
    public Camera _camera;

    [Header("是否设置暗角")]
    public bool _setVignette;
    [Header("暗角变化持续时间"),SerializeField]
    private float _fadeTime = 1f;
    [Header("暗角值"), Range(0, 1),SerializeField]
    private float _vignetteIndex = 0.6f;

    [Header("是否设置对比度")]
    public bool _setSaturation;
    [Header("对比度变化持续时间"),SerializeField]
    private float _changeTime = 1f;
    [Header("对比度值"), Range(-100, 100),SerializeField]
    private float _saturationIndex = 0.6f;

    [Header("是否设置模糊半径")]
    public bool _setDepthInField;
    [Header("模糊半径变化持续时间"),SerializeField]
    private float _depthTime = 1f;
    [Header("模糊半径值"),SerializeField]
    private float _depthIndex = 14f;
    
    [Header("是否设置辉光")]
    public bool _setBloom;
    [Header("辉光变化持续时间"),SerializeField]
    private float _bloomTime = 1f;
    [Header("辉光值"),SerializeField]
    private float _bloomIndex = 2f;
    
    

    [Header("是否更换配置文件"),SerializeField]
    public bool _setProfile;
    [Header("新配置文件")]
    public PostProcessProfile _profile;
    
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "line")
        {
            if (_setProfile) _volume.profile = _profile;
            if (_setVignette) FadeIn();
            if(_setSaturation) SetIn();
            if(_setDepthInField) DepthIn();
            if(_setBloom) BloomIn();
        }
        _volume = _camera.GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings(out _vignette);
        _volume.profile.TryGetSettings(out _colorGrading);
        _volume.profile.TryGetSettings(out _depthOfField);
        _volume.profile.TryGetSettings(out _bloom);
    }

    void FadeIn()
    {
        DOTween.To(()=> _vignette.intensity.value, x => _vignette.intensity.value = x, _vignetteIndex, _fadeTime).SetEase(Ease.InOutSine);
    }

    void SetIn()
    {
        DOTween.To(()=> _colorGrading.saturation.value, x => _colorGrading.saturation.value = x, _saturationIndex, _changeTime).SetEase(Ease.InOutSine);
    }

    void DepthIn()
    {
        DOTween.To(()=> _depthOfField.focusDistance.value, x => _depthOfField.focusDistance.value = x, _depthIndex, _depthTime).SetEase(Ease.InOutSine);
    }

    void BloomIn()
    {
        DOTween.To(()=> _bloom.intensity.value, x => _bloom.intensity.value = x, _bloomIndex, _bloomTime).SetEase(Ease.InOutSine);
    }
}