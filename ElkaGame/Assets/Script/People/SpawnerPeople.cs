using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerPeople : MonoBehaviour
{
    [SerializeField] private int _countMan;
    [SerializeField] private Man _prefabMan;
    [SerializeField] private Transform _conteiner;

    private Queue<Man> _poolMan;
    private Man _tempMan;
    private List<Color> _colors;
    private List<int> _counts;

    public void SecondStep(Dictionary<Color, int> colorsAndCountPeople)
    {
        _colors = colorsAndCountPeople.Keys.ToList();
        _counts = colorsAndCountPeople.Values.ToList();
        _poolMan = new Queue<Man>();
        FillingQueue(MaxPeople(colorsAndCountPeople));
    }

    public void TakeColors(List<Color> colors)
    {
        _colors = colors;
    }

    private int MaxPeople(Dictionary<Color, int> colorsAndCountPeople)
    {
        int maxPeople = 0;

        foreach(var item in colorsAndCountPeople)
        {
            maxPeople += item.Value;
        }

        return maxPeople;
    }

    public Man GetMan()
    {
        return _poolMan.Dequeue();
    }

    public bool CheckCountPeopleQueue()
    {
        return Convert.ToBoolean(_poolMan.Count);
    }

    private void FillingQueue(int countMan)
    {
        int minRandom = 2;
        int maxRaodom = 9;
        int randomCountPeople;
        int indexColor;

        while(countMan > 0)
        {
            randomCountPeople = UnityEngine.Random.Range(minRandom, maxRaodom);
            indexColor = UnityEngine.Random.Range(0, _colors.Count);

            if(_counts[indexColor] > 0)
            {
                if(_counts[indexColor] > randomCountPeople)
                {
                    _counts[indexColor] -= randomCountPeople;
                }
                else
                {
                    randomCountPeople = _counts[indexColor];
                }

                while(randomCountPeople > 0)
                {
                    randomCountPeople--;
                    countMan--;
            
                    CreateMan(_colors[indexColor]);
                }
            }
        }
    }

    private void CreateMan(Color color)
    {
        _tempMan = Instantiate(_prefabMan, _conteiner);
        _tempMan.SetColor(color);
        _poolMan.Enqueue(_tempMan);
        _tempMan.gameObject.SetActive(false);
    }
}
