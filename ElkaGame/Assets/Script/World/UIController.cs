using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image _endWindow;
    [SerializeField] private Image _winnerWindow;
    [SerializeField] private Button _restartButton;
    private SendParking _sendParking;
    private EndPoint _endPoint;
    private void Awake()
    {
        _endPoint = GameObject.FindAnyObjectByType<EndPoint>();
        _sendParking = GameObject.FindAnyObjectByType<SendParking>();
        _endWindow.gameObject.SetActive(false);
        _winnerWindow.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _sendParking.EndedGame += EnableRestartWindow;
        _endPoint.WinedGame += EnableWinnreWindow;
        _restartButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _sendParking.EndedGame -= EnableRestartWindow;
        _endPoint.WinedGame -= EnableWinnreWindow;
        _restartButton.onClick.RemoveListener(RestartLevel);
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
        // логика перезапуска уровня
        SceneManager.LoadScene(0);
        // ----
        Debug.Log("restart");
    }
}
