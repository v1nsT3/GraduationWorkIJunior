using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ButtonChangeStateGame : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] protected Game Game;
    [SerializeField] protected UnityEvent ChangedStateGame;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}
