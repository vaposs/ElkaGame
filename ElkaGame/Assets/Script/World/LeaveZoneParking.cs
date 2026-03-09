using System.Collections.Generic;
using UnityEngine;

public class LeaveZoneParking : MonoBehaviour
{
    [SerializeField] private List<Transform> _takeNextPoints;
    
    int indexPoint = 0;

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.TryGetComponent<Move>(out Move move))
        {
            move.transform.LookAt(FindingClosestCorner(move));
        }
    }

    private Transform FindingClosestCorner(Move target)
    {
        float minDistance = float.MaxValue;

        for(int i = 0; i < _takeNextPoints.Count; i++)
        {
            float distance = Vector3.Distance(target.transform.position, _takeNextPoints[i].position);

            if(distance < minDistance)
            {
                minDistance = distance;
                indexPoint = i;
            }
        }

        return _takeNextPoints[indexPoint];
    }
}
