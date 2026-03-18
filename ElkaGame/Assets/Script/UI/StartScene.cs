using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public static event Action<int> ChangedLanguages;

    [SerializeField] private Dropdown _languages;
    [SerializeField] private Button _startGameButton;


    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(NextScene);
        _languages.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(NextScene);
        _languages.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        ChangedLanguages?.Invoke(index);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
