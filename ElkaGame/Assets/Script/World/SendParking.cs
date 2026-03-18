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
                _loadPeopleZones[i].SetBusy();
                return _loadPeopleZones[i].transform;
            }
        }

        EndedGame?.Invoke();

        return null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.TryGetComponent<Move>(out Move move))
        {
            if(move.IsCanMove == true && move.IsHaveParkingPlace == false)
            {
                move.TakeParkingPlace();
                move.TakeNextTarget(TakeParkingPlace());
            }
            else if(move.IsFool() == true)
            {
                move.TakeNextTarget(_exitPoint);
            }
        
        }
    }

}
