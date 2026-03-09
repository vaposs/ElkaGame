using UnityEngine.Splines;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _startRay;

     
    private Ray _ray;
    private RaycastHit[] _raycastHit;
    private float _currentSpeed;
    private bool _isEndRoute = false;

    private void Start()
    {
        _currentSpeed = _speed;
    }
    private void Update()
    {
        if(CheckRouted() && _isEndRoute == false ) 
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * _currentSpeed * Time.deltaTime);
    }

    private bool CheckRouted()
    {
        _ray = new Ray(_startRay.position, -transform.right);

        Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.red);

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
        _isEndRoute = true;
    }
}
