using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetingGame : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    private List<GameObject> _car;
    private SpawnCars _spawnCars;
    private SpawnerPeople _spawnerPeople;
    private Dictionary<Color, int> _countPeopleAndColor;

    private void Awake()
    {
        _countPeopleAndColor = new Dictionary<Color, int>();
        _spawnCars = FindAnyObjectByType<SpawnCars>();
        _car = _spawnCars.FirstStep();
        SearchCountPeople(_car);
        _spawnerPeople = FindAnyObjectByType<SpawnerPeople>();
        _spawnerPeople.SecondStep(_countPeopleAndColor);
    }

    public Color[] GetAllColors()
    {
        return _colors;
    }

    private void SearchCountPeople(List<GameObject> cars)
    {
        foreach (GameObject item in cars)
        {
            LoadPeopl tempLoadPeapl = item.GetComponentInChildren<LoadPeopl>();

            if(_countPeopleAndColor.ContainsKey(tempLoadPeapl.GetColor()))
            {
                _countPeopleAndColor[tempLoadPeapl.GetColor()] += tempLoadPeapl.MaxCapasiti;
            }
            else
            {
                _countPeopleAndColor.Add(tempLoadPeapl.GetColor(), tempLoadPeapl.MaxCapasiti);
            }
        }
    }

    // 1 - заспавнить машинки и дать им цвета
    // 2 - узнать цвета и количество мест по цветам

}
