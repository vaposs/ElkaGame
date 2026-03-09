using UnityEngine;

public class LoadZone : MonoBehaviour
{
    private Man _tempMan;
    public bool IsHaveMan { get; private set; } = false; 
    
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.TryGetComponent<Man>(out Man man))
        {
            IsHaveMan = true;
            man.CommandStop();
            _tempMan = man;
        }
    }

    public Man GiveManLOad()
    {
        IsHaveMan = false;
        return _tempMan;
    }
}


