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
    [SerializeField] private Button _nextSceneButton;
    [SerializeField] private Button _menuOpenutton;
    [SerializeField] private Button _menuCloseButton;
    [SerializeField] private Transform _disablePosition;
    [SerializeField] private Transform _enablePosiion;

    private bool _isOpenPanel = false;
    private SendParking _sendParking;
    private EndPoint _endPoint;
    private ShowAd _showAd;
    
    private void Awake()
    {
        Time.timeScale = 1;
        _endPoint = GameObject.FindAnyObjectByType<EndPoint>();
        _sendParking = GameObject.FindAnyObjectByType<SendParking>();
        _showAd = GameObject.FindAnyObjectByType<ShowAd>();
        _endWindow.gameObject.SetActive(false);
        //_menuWindow.gameObject.SetActive(false);
        _winnerWindow.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _sendParking.EndedGame += EnableRestartWindow;
        _endPoint.WinedGame += EnableWinnreWindow;
        _restartButtonOne.onClick.AddListener(RestartLevel);
        _restartButtonSecond.onClick.AddListener(RestartLevel);
        _menuOpenutton.onClick.AddListener(OpenClosed);
        _menuCloseButton.onClick.AddListener(OpenClosed);
        _nextSceneButton.onClick.AddListener(LoadNextScene);
    }

    private void OnDisable()
    {
        _sendParking.EndedGame -= EnableRestartWindow;
        _endPoint.WinedGame -= EnableWinnreWindow;
        _restartButtonOne.onClick.RemoveListener(RestartLevel);
        _restartButtonSecond.onClick.RemoveListener(RestartLevel);
        _menuOpenutton.onClick.RemoveListener(OpenClosed);
        _menuCloseButton.onClick.RemoveListener(OpenClosed);
        _nextSceneButton.onClick.RemoveListener(LoadNextScene);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene()
    {
        _showAd.ShowAdNextLvl();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenClosed()
    {
        if(_isOpenPanel == false)
        {
            _isOpenPanel = true;
            _menuWindow.transform.position = _enablePosiion.position;
        }
        else
        {
            _menuWindow.transform.position = _disablePosition.position;
            _isOpenPanel = false;
        }
    }
}
