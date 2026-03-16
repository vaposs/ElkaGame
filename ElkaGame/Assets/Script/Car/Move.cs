using UnityEngine;
using ElkaGame.Men;

[RequireComponent(typeof(LoadPeopl))]
public class Move : MonoBehaviour
{
    [SerializeField] private Transform _startRay;
    [SerializeField] private float _speed;
    private Ray _ray;
    private LoadPeopl _loadPeopl;
    private RaycastHit[] _raycastHit;
    private Transform _target = null;

    public bool  IsCanMove {get; private set; }  = false;

    private void Awake()
    {
        _loadPeopl = GetComponent<LoadPeopl>();
    }
    private void Update()
    {
        if(IsCanMove == true && _target == null )
        {
            MoveForward();
        }
        else if(_target != null && IsCanMove == true) 
        {
            MoveToTarget(_target);
        }
        else if(_loadPeopl.MaxCapasiti == _loadPeopl.CurrentCapaciti)
        {
            MoveToTarget(_target);
        }
    }

    public void OnClicked()
    {
        if(CheckRouted())
        {
            IsCanMove = true;
        }
    }

    public void TakeNextTarget(Transform target)
    {
        _target = target;
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        transform.LookAt(target);
    }

    public bool CheckRouted()
    {
        _ray = new Ray(_startRay.position, transform.forward);

        Debug.DrawRay(_ray.origin, _ray.direction, Color.red);

        _raycastHit = Physics.RaycastAll(_ray);

        foreach(var item in _raycastHit)
        {
            if(item.transform.TryGetComponent<Move>(out Move component))
            {
                return false;
            }
        }

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent<LoadPeopleZone>(out LoadPeopleZone loadPeopleZone))
        {
            IsCanMove = false;
            transform.position = loadPeopleZone.transform.position;
            transform.rotation = loadPeopleZone.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.TryGetComponent<LoadPeopleZone>(out LoadPeopleZone loadPeopleZone))
        {
            loadPeopleZone.SetFree();
        }
    }
}
