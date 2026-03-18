using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    private Camera _camera;
    private Ray _ray;
    private RaycastHit _raycastHit;
    private InputControlGame _inputControlGame;

    private void Awake()
    {
        _camera = Camera.main;
        _inputControlGame = GameObject.FindAnyObjectByType<InputControlGame>();
    }

    private void OnEnable()
    {
        _inputControlGame.ChoosedCar += SendRayCast;
    }

    private void OnDisable()
    {
        _inputControlGame.ChoosedCar -= SendRayCast;
    }

    private void SendRayCast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.red);
        Physics.Raycast(_ray, out _raycastHit);

// -------------

        if(_raycastHit.transform.TryGetComponent<Move>(out Move move))
        {
            move.OnClicked();
        }
    }
}
