using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Man : MonoBehaviour
{
    private const string IsRun = nameof(IsRun);

    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _startRay;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

     
    private Ray _ray;
    private RaycastHit[] _raycastHit;
    private float _currentSpeed;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Collider _collider;
    private bool _isEndRoute = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }
    private void Start()
    {
        _currentSpeed = _speed;
    }
    private void Update()
    {
        if(CheckRouted() && _isEndRoute == false ) 
        {
            _animator.SetBool(IsRun, true);
            MoveForward();
        }
        else
        {
            _animator.SetBool(IsRun, false);
        }

    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
    }

    private bool CheckRouted()
    {
        _ray = new Ray(_startRay.position, transform.forward);

        Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.green);

        _raycastHit = Physics.RaycastAll(_ray, _distance);

        foreach(var item in _raycastHit)
        {
            if(item.transform.TryGetComponent<Man>(out Man man))
            {
                _currentSpeed = 0;
                return false;
            }
        }
        _currentSpeed = _speed; 
        return true;
    }

    public void CommandStop()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        _isEndRoute = true;
    }

    public void SetColor(Color color)
    {
        skinnedMeshRenderer.material.color = color;
    }

    public Color GetColor()
    {
        return skinnedMeshRenderer.material.color;
    }

    public void InviteCar()
    {
        skinnedMeshRenderer.enabled = false;
        _collider.enabled = false;
    }
}
