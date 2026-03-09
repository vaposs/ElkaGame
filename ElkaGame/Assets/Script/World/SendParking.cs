using System;
using System.Collections.Generic;
using UnityEngine;
using ElkaGame.Men;

public class SendParking : MonoBehaviour
{
    public event Action EndedGame;

    [SerializeField] private List<LoadPeopleZone> _loadPeopleZones;
    [SerializeField] private Transform _exitPoint;

    private Transform TakeParkingPlace()
    {
        for(int i = 0; i < _loadPeopleZones.Count; i++)
        {
            if(_loadPeopleZones[i].IsFreePlace == true)
            {
                _loadPeopleZones[i].TakeParking();
                return _loadPeopleZones[i].transform;
            }
        }

        EndedGame?.Invoke();

        return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<Move>(out Move move))
        {
            if(move.IsCanMove == true)
            {
                move.TakeNextTarget(TakeParkingPlace());
            }
            else
            {
                move.TakeNextTarget(_exitPoint);
            }
        
        }
    }
}
