using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(NextScene);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(NextScene);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
