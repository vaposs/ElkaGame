using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputControlGame : MonoBehaviour
{
    public event Action ChoosedCar;
    [SerializeField] private KeyCode _chooseCarButton;
    private void Update()
    {
        ChooseCar();
    }

    private void ChooseCar()
    {
        if(Input.GetKeyDown(_chooseCarButton))
        {
            ChoosedCar?.Invoke();
        }
    }

}
