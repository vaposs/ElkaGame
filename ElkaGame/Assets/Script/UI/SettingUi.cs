using UnityEngine;
using TMPro;
using System;

public class SettingUi : MonoBehaviour
{
    public static event Action<int> ChangedLanguages;
    public static int s_currentIndexLanguages = 0;
    [SerializeField] private TMP_Dropdown _languages;
    private void OnEnable()
    {
        _languages.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDisable()
    {
        _languages.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        s_currentIndexLanguages = index;
        ChangedLanguages?.Invoke(index);
    }
}
