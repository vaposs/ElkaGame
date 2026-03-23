using UnityEngine;

public class LoadPeopl : MonoBehaviour
{
    [SerializeField] private Transform[] _peoplePlace;
    [SerializeField]private MeshRenderer[] _meshRenderers;
    private Color _colorCar;
    private Color[] _colors;

    public int CurrentCapaciti {get; private set;} = 0;
    public Color CurrentColor {get; private set;}
    public int MaxCapasiti {get; private set;}

    private void Awake()
    {
        _colors = FindAnyObjectByType<SetingGame>().GetAllColors();
        SetRandomColor();
        MaxCapasiti = _peoplePlace.Length;
    }

    public void SetRandomColor()
    {
        _colorCar = _colors[Random.Range(0,_colors.Length)];

        foreach(MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material.color = _colorCar;
        }
    }

    public bool IsFool()
    {
        return CurrentCapaciti == MaxCapasiti;
    }

    public void Load(Man man)
    {
        man.transform.SetParent(this.transform);
        man.InviteCar();
        man.transform.position = _peoplePlace[CurrentCapaciti].position;
        CurrentCapaciti ++;
    }

    public Color GetColor()
    {
        return _colorCar;
    }

    
}
