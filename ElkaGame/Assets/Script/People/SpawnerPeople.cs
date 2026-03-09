using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPeople : MonoBehaviour
{
    [SerializeField] private int _countMan;
    [SerializeField] private Man _prefabMan;
    [SerializeField] private Transform _conteiner;

    private Queue<Man> _poolMan;
    private Man _tempMan;

    private void Awake()
    {
        _poolMan = new Queue<Man>();
    }

    private void Start()
    {
        FillingQueue(_countMan);
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
        for(int i = 0; i < countMan; i++)
        {
            _tempMan = Instantiate(_prefabMan, _conteiner);
            _poolMan.Enqueue(_tempMan);
            _tempMan.gameObject.SetActive(false);
        }
    }
}
