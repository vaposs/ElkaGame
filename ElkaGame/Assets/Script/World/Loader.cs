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
            foreach(LoadPeopl car in _cars)
            {
                if(car.MaxCapasiti != car.CurrentCapaciti)
                {
                    if(_loadZone.IsHaveMan == true || _tempMan != null)
                    {
                        if(_tempMan == null)
                        {
                            _tempMan = _loadZone.GiveManLOad();
                        }

                        if(_tempMan.GetColor() ==  car.GetColor())
                        {
                            car.Load(_tempMan);
                            _tempMan = null;
                        }
                    }
                }
                
                if(car.MaxCapasiti == car.CurrentCapaciti)
                {
                    car.transform.GetComponent<Move>().TakeNextTarget(_exitZone);
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
