using UnityEngine;

public class TrackingPlayer : MonoBehaviour
{ 
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetZ;

    private void Start()
    {
        _camera.transform.LookAt(_player.transform.position, Vector3.forward);
    }

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _offsetX, transform.position.y, _player.transform.position.z + _offsetZ);
    }
}
