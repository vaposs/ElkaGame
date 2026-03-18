using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    [SerializeField] private Text _textFild;
    [SerializeField] private string[] _text;

    private void OnEnable()
    {
        StartScene.ChangedLanguages += ChangeText;
    }

    private void OnDisable()
    {
        StartScene.ChangedLanguages -= ChangeText;
    }

    private void ChangeText(int index)
    {
        _textFild.text = _text[index];
    }
}
