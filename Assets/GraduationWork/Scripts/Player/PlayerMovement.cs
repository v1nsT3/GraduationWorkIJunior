using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private Animator _animator;
    private float verticalSpeed;
    private float horizontalSpeed;
    private int stageLayerMask = 1 << 3;
    private float _rayDistance = 2000;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.fireEvents = false;
    }

    public void Move(float vertical, float horizontal)
    {
        verticalSpeed = Mathf.MoveTowards(verticalSpeed, 1 * vertical, _speedMove * Time.deltaTime);
        horizontalSpeed = Mathf.MoveTowards(horizontalSpeed, 1 * horizontal, _speedMove * Time.deltaTime);

        transform.position += (transform.forward * vertical + transform.right * horizontal) * _speedMove * Time.deltaTime;

        _animator.SetBool(AnimatorController.Params.IsMove, Mathf.Abs(vertical) + Mathf.Abs(horizontal) != 0);
        _animator.SetFloat(AnimatorController.Params.Horizontal, horizontalSpeed);
        _animator.SetFloat(AnimatorController.Params.Vertical, verticalSpeed);
    }

    public void RotateToRay(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit, _rayDistance, stageLayerMask))
        {
            Quaternion targetRotation = Quaternion.LookRotation(raycastHit.point - transform.position, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speedRotate * Time.deltaTime);
            Vector3 euler = transform.rotation.eulerAngles;
            euler.x = 0;
            euler.z = 0;
            transform.rotation = Quaternion.Euler(euler);
        }
    }
}
