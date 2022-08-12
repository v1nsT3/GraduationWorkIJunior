using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;
    [SerializeField] private Color _colorMaxValue;
    [SerializeField] private Color _colorMinValue;
    [SerializeField] private Image _image;

    protected void OnChangeValue(float value, float maxValue)
    {
        float result = value / maxValue;
        _slider.DOValue(result, _duration);
        _image.DOColor(Color.Lerp(_colorMinValue, _colorMaxValue, result), _duration);
    }
}
