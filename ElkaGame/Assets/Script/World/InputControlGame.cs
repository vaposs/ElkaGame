using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputControlGame : MonoBehaviour
{
    public event Action ChoosedCar;
    [SerializeField] private KeyCode _chooseCarButton;

    private Touch touch;
    
    private void Update()
    {
        ChooseCar();
        ChooseCarMobile();
    }

    private void ChooseCar()
    {
        if(Input.GetKeyDown(_chooseCarButton))
        {
            ChoosedCar?.Invoke();
        }
    }

    private void ChooseCarMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log($"Касание в позиции: {touch.position}");
                ChoosedCar?.Invoke();
            }
        } 
    }
        

}
