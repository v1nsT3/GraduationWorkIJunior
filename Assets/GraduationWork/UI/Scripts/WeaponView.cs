using GraduationWork;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Button _sellButton;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Image _icon;

    private Weapon _weapon;

    public event UnityAction<WeaponView, Weapon> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
    }

    public void Init(Weapon weapon)
    {
        _weapon = weapon;

        Render();
    }

    private void Render()
    {
        _price.text = _weapon.Price.ToString();
        _label.text = _weapon.Label;
        _icon.sprite = _weapon.Icon;
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(this, _weapon);
    }
}
