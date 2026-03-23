using TMPro;
using UnityEngine;

public class TextChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textFild;
    [SerializeField] private string[] _text;

    private void Awake()
    {
        _textFild.text = _text[SettingUi.s_currentIndexLanguages];
    }

    private void OnEnable()
    {
        SettingUi.ChangedLanguages += ChangeText;
    }

    private void OnDisable()
    {
        SettingUi.ChangedLanguages -= ChangeText;
    }

    private void ChangeText(int index)
    {
        _textFild.text = _text[index];
    }
}
