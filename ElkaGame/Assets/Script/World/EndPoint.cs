using System;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public event Action WinedGame;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out LoadPeopl loadPeopl))
        {
            GameObject[] _man = GameObject.FindGameObjectsWithTag("Man");

            if(_man.Length - loadPeopl.CurrentCapaciti == 0)
            {
                WinedGame?.Invoke();
            }

            Destroy(loadPeopl.gameObject);
        }
    }
}
