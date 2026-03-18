using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class LoadPeopl : MonoBehaviour
{
    [SerializeField] private Transform[] _peoplePlace;
    
    private MeshRenderer _meshRenderer;
    private Color[] _colors;

    public int CurrentCapaciti {get; private set;} = 0;
    public Color CurrentColor {get; private set;}
    public int MaxCapasiti {get; private set;}

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _colors = FindAnyObjectByType<SetingGame>().GetAllColors();
        SetRandomColor();
        MaxCapasiti = _peoplePlace.Length;
    }

    public void SetRandomColor()
    {
        _meshRenderer.material.color = _colors[Random.Range(0,_colors.Length)];
    }

    public bool IsFool()
    {
        return CurrentCapaciti == MaxCapasiti;
    }

    public void Load(Man man)
    {
        man.transform.SetParent(this.transform);
        man.transform.position = _peoplePlace[CurrentCapaciti].position;
        CurrentCapaciti ++;
    }

    public Color GetColor()
    {
        return _meshRenderer.material.color;
    }

    
}
