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
        Debug.Log("work");

        if(_cars.Count > 0)
        {
            Debug.Log(_cars.Count + "количество" );
            
            foreach(LoadPeopl car in _cars)
            {
                Debug.Log("1");

                if(car.MaxCapasiti != car.CurrentCapaciti)
                {
                    Debug.Log(_loadZone.IsHaveMan + "=====" + _tempMan );

                    if(_loadZone.IsHaveMan == true || _tempMan != null)
                    {
                        Debug.Log("3");    

                        if(_tempMan == null)
                        {
                            _tempMan = _loadZone.GiveManLOad();
                        }

                        Debug.Log("все готово");

                        if(_tempMan.GetColor() ==  car.GetColor())
                        {
                            Debug.Log("грузим");
                            car.Load(_tempMan);
                            _tempMan = null;
                        }
                        else
                        {
                            Debug.Log("цвет не подошел");
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
