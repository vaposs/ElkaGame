using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private TextAsset[] _seeds;
    [SerializeField] private string _pathSetingCarResource;
    [SerializeField] private List<GameObject> _prefabs;
    private List<GameObject> _cars;
    private string _setingCars;

    public List<GameObject> FirstStep()
    {
       _cars = new List<GameObject>();
        LoadSeting();
        CreateCar();

        return _cars;
    }

    private void LoadSeting()
    {
        // поменять на номер сцены
        _setingCars = _seeds[Random.Range(0, _seeds.Length)].text;
            YGLog.ShowLog("загрузили сид");
    }

    private void CreateCar()
    {
        YGLog.ShowLog("1");
        string[] line = _setingCars.Split('\n');
        string[] setting;
        
        YGLog.ShowLog("2");

        for (int i = 0; i < line.Length; i++)
        {
            setting = line[i].Split('_');
                    YGLog.ShowLog("3");

            Vector3 position = new Vector3(float.Parse(setting[1]), float.Parse(setting[2]), float.Parse(setting[3]));
                    YGLog.ShowLog("4");

            Quaternion quaternion = Quaternion.Euler(float.Parse(setting[4]),float.Parse(setting[5]),float.Parse(setting[6]));
                    YGLog.ShowLog("5");


            foreach(var car in _prefabs)
            {
                if (setting[0] == car.name)
                {
                    YGLog.ShowLog("6");
                    _cars.Add(Instantiate(car, position, quaternion, null));
                }
            }
        }


        YGLog.ShowLog(this.name + " - " + "закончили спавнить машинки");
    }
}
