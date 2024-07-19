using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CaramelLyricsHolder : MonoBehaviour
{
    private Text _text;
    [HideInInspector] public bool IsUsing;

    void Start()
    {
        _text = this.GetComponent<Text>();
        _text.text = null;
        _text.color = new Color32(255,200,168,0);
        IsUsing = false;
    }

    public IEnumerator ShowLyric(string _lyric , float _startTime , float _endTime , Vector3 _pos , Color32 _color)
    {
        IsUsing = true;
        _text.text = _lyric;
        Color32 _tepColor = new Color32(_color.r , _color.g , _color.b , 0);
        this.transform.localPosition = _pos;
        DOTween.To(()=> _text.color, x => _text.color = x, _color, 0.3f);
        yield return new WaitForSeconds(_endTime - _startTime);
        DOTween.To(()=> _text.color, x => _text.color = x, _tepColor, 0.3f);
        yield return new WaitForSeconds(0.3f);
        IsUsing = false;
    }
}
