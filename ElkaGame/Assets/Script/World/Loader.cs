using UnityEngine;
using System.Collections.Generic;

public class Loader : MonoBehaviour
{
    [SerializeField] private LoadZone _loadZone;
    [SerializeField] private Transform _exitZone;
    private List<LoadPeopl> _cars;

    private Man _tempMan;

    private void Awake()
    {
        _cars = new List<LoadPeopl>();
    }

    private void Update()
    {
        if(_cars.Count > 0)
        {
            for(int i = 0; i < _cars.Count; i++)
            {
                if(_cars[i].IsFullLoad() == false)
                {
                    if(_loadZone.IsHaveMan == true)
                    {
                        _tempMan = _loadZone.GiveManLOad();
                        _cars[i].Load(_tempMan);
                        _tempMan = null;
                    }
                }
                else
                {
                    _cars[i].transform.GetComponent<Move>().TakeNextTarget(_exitZone);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out LoadPeopl car))
        {
            _cars.Add(car);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out LoadPeopl car))
        {
            _cars.Remove(car);
        } 
    }
}
