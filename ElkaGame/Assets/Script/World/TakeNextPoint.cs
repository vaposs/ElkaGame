using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeNextPoint : MonoBehaviour
{
    [SerializeField] private Transform _nextPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<Move>(out Move move))
        {
            move.TakeNextTarget(_nextPoint);
        }
    }
}
