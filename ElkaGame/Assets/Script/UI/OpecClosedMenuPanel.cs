using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpecClosedMenuPanel : MonoBehaviour
{
    [SerializeField] private Image _menu;
    [SerializeField] private Button _openMenuButton;
    [SerializeField] private Button _closedMenuButton;
    [SerializeField] private Transform _disablePosition;
    [SerializeField] private Transform _enablePosiion;

    private bool _isOpenPanel = false;

    private void OnEnable()
    {
        _openMenuButton.onClick.AddListener(OpenClosed);
        _closedMenuButton.onClick.AddListener(OpenClosed);
    }

    private void OnDisable()
    {
        _openMenuButton.onClick.RemoveListener(OpenClosed);
        _closedMenuButton.onClick.RemoveListener(OpenClosed);
    }

    private void Start()
    {
        _menu.transform.position = _disablePosition.position;
    }

    public void OpenClosed()
    {
        if(_isOpenPanel == false)
        {
            _isOpenPanel = true;
            _menu.transform.position = _enablePosiion.position;
        }
        else
        {
            _menu.transform.position = _disablePosition.position;
            _isOpenPanel = false;
        }
    }
}
