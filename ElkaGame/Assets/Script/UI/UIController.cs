using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image _endWindow;
    [SerializeField] private Image _winnerWindow;
    [SerializeField] private Image _menuWindow;
    [SerializeField] private Button _restartButtonOne;
    [SerializeField] private Button _restartButtonSecond;
    [SerializeField] private Button _menuOpenutton;
    [SerializeField] private Button _menuCloseButton;
    private SendParking _sendParking;
    private EndPoint _endPoint;
    private void Awake()
    {
        Time.timeScale = 1;
        _endPoint = GameObject.FindAnyObjectByType<EndPoint>();
        _sendParking = GameObject.FindAnyObjectByType<SendParking>();
        _endWindow.gameObject.SetActive(false);
        _menuWindow.gameObject.SetActive(false);
        _winnerWindow.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _sendParking.EndedGame += EnableRestartWindow;
        _endPoint.WinedGame += EnableWinnreWindow;
        _restartButtonOne.onClick.AddListener(RestartLevel);
        _restartButtonSecond.onClick.AddListener(RestartLevel);
        _menuOpenutton.onClick.AddListener(OpenCloseMenu);
        _menuCloseButton.onClick.AddListener(OpenCloseMenu);
    }

    private void OnDisable()
    {
        _sendParking.EndedGame -= EnableRestartWindow;
        _endPoint.WinedGame -= EnableWinnreWindow;
        _restartButtonOne.onClick.RemoveListener(RestartLevel);
        _restartButtonSecond.onClick.RemoveListener(RestartLevel);
        _menuOpenutton.onClick.RemoveListener(OpenCloseMenu);
        _menuCloseButton.onClick.RemoveListener(OpenCloseMenu);
    }

    private void EnableRestartWindow()
    {
        Time.timeScale = 0;
        _endWindow.gameObject.SetActive(true);
    }

    private void EnableWinnreWindow()
    {
        Time.timeScale = 0;
        _winnerWindow.gameObject.SetActive(true);
    }

    private void RestartLevel()
    {
        _endWindow.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void OpenCloseMenu()
    {
        _menuWindow.gameObject.SetActive(!_menuWindow.gameObject.activeSelf);

        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
