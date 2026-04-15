using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private Transform _conteiner;
    private List<GameObject> _cars;

    public List<GameObject> FirstStep()
    {
       _cars = new List<GameObject>();
        CreateCar();

        return _cars;
    }


    private void CreateCar()
    {
       //int randomSeed = Random.Range(0, _prefabs.Count);
        int randomSeed = 7;
       GameObject tempSeed = Instantiate(_prefabs[randomSeed]);

        for(int i = 0; i < tempSeed.transform.childCount; i++)
        {
            _cars.Add(tempSeed.transform.GetChild(i).gameObject);
        }
    }
}
