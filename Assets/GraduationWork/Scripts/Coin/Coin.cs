using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _offsetY;
    [SerializeField] private float _durationMove;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _reward;

    private Tween _tween;

    private void Start()
    {
        _tween = transform.DOMoveY(transform.position.y + _offsetY, _durationMove).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet playerWallet))
        {
            playerWallet.AddCoins(_reward);

            DestroyCoin();
        }
    }

    public void DestroyCoin()
    {
        _tween.Kill();
        gameObject.SetActive(false);
    }
}
