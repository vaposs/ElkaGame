using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    private string _pathCarResource = "Prefab/Car";
    [SerializeField] private string _pathSetingCarResource;
    private Dictionary<string, GameObject> _carPrefabs;
    private List<GameObject> _cars;
    private string _setingCars;

    public List<GameObject> FirstStep()
    {
        _carPrefabs = new Dictionary<string, GameObject>();
        _cars = new List<GameObject>();;
        LoadPrefabs();
        LoadSeting();
        CreateCar();

        return _cars;
    }

    private void LoadPrefabs()
    {
        GameObject[] carPrefabs = Resources.LoadAll<GameObject>(_pathCarResource);

        foreach (var car in carPrefabs)
        {
            _carPrefabs.Add(car.name, car);
        }
    }

    private void LoadSeting()
    {
        TextAsset fileSettingCar = Resources.Load<TextAsset>(_pathSetingCarResource);

        _setingCars = fileSettingCar.text;
    }

    private void CreateCar()
    {
        string[] line = _setingCars.Split('\n');
        string[] setting;

        for (int i = 0; i < line.Length; i++)
        {
            setting = line[i].Split('_');

            Vector3 position = new Vector3(float.Parse(setting[1]), float.Parse(setting[2]), float.Parse(setting[3]));
            Quaternion quaternion = Quaternion.Euler(float.Parse(setting[4]),float.Parse(setting[5]),float.Parse(setting[6]));

            if (_carPrefabs.TryGetValue(setting[0], out GameObject car))
            {
                _cars.Add(Instantiate(car, position, quaternion, null));
            }
        }
    }
}
