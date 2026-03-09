using UnityEngine;

public class LoadPeopl : MonoBehaviour
{
    [SerializeField] private Transform[] _peoplePlace;
    private int _maxCapasiti;

    public int CurrentCapaciti {get; private set;} = 0;

    private void Awake()
    {
        _maxCapasiti = _peoplePlace.Length;
    }

    public bool IsFullLoad()
    {
        if(CurrentCapaciti < _maxCapasiti)
        {
            return false;
        }

        return true;
    }

    public void Load(Man man)
    {
        man.transform.SetParent(this.transform);
        man.transform.position = _peoplePlace[CurrentCapaciti].position;
        CurrentCapaciti ++;
    }
}
