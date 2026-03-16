using UnityEngine;

public class QueuePeople : MonoBehaviour
{
    [SerializeField] private float _scanRadiys;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private SpawnerPeople _spawnerPeople;
    [SerializeField] private Transform _startPosition;
    private Collider[] _hits;
    private float _currentSpawn;
    private Man _tempMan;

    private void Start()
    {
        _currentSpawn = _timeSpawn;
    }

    private void Update()
    {
        if(CheckQueue() == true && _currentSpawn < 0 && _spawnerPeople.CheckCountPeopleQueue())
        {
            _tempMan = _spawnerPeople.GetMan();
            _tempMan.gameObject.SetActive(true);
            _tempMan.transform.SetParent(null);
            _tempMan.transform.position = _startPosition.localPosition;
            _currentSpawn = _timeSpawn;
        }

        _currentSpawn -= Time.deltaTime;   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _scanRadiys);
    }

    private bool CheckQueue()
    {
        _hits = Physics.OverlapSphere(transform.position, _scanRadiys);

        for (int i = 0; i < _hits.Length; i++)
        {
            if(_hits[i].TryGetComponent(out Man man))
            {
                return false;
            }
        }

        return true;
    }
}
