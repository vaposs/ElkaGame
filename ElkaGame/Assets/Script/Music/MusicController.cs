using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private const string Master = nameof(Master);
    private const string Fon = nameof(Fon);
    private const string Car = nameof(Car);
    private const string UI = nameof(UI);
    private static MusicController s_musicController;

    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private Slider _sliderVolumeAllMusic;
    [SerializeField] private Slider _sliderVolumeFonMusic;
    [SerializeField] private Slider _sliderVolumeCarMusic;
    [SerializeField] private Slider _sliderVolumeUIMusic;
    [SerializeField] private AudioMixer _audioMixer;

    private int _maxVolumeMusic = 100;
    private int _startVolumeMusic = 10;
    private float _currentVolume;

    private void Start()
    {        
        _currentVolume = _startVolumeMusic;
        _sliderVolumeAllMusic.maxValue = _maxVolumeMusic;
        _sliderVolumeAllMusic.minValue = 0;
        _sliderVolumeAllMusic.value = _currentVolume;
        _sliderVolumeFonMusic.maxValue = _maxVolumeMusic;
        _sliderVolumeFonMusic.minValue = 0;
        _sliderVolumeFonMusic.value = _currentVolume;
        _sliderVolumeCarMusic.maxValue = _maxVolumeMusic;
        _sliderVolumeCarMusic.minValue = 0;
        _sliderVolumeCarMusic.value = _currentVolume;
        _sliderVolumeUIMusic.maxValue = _maxVolumeMusic;
        _sliderVolumeUIMusic.minValue = 0;
        _sliderVolumeUIMusic.value = _currentVolume;
    }

    private void OnEnable()
    {
        _sliderVolumeAllMusic.onValueChanged.AddListener(ChangeAllMusic);
        _sliderVolumeFonMusic.onValueChanged.AddListener(ChangeFonMusic);
        _sliderVolumeCarMusic.onValueChanged.AddListener(ChangeCarMusic);
        _sliderVolumeUIMusic.onValueChanged.AddListener(ChangeUIMusic);
    }

    private void OnDisable()
    {
        _sliderVolumeAllMusic.onValueChanged.RemoveListener(ChangeAllMusic);
        _sliderVolumeFonMusic.onValueChanged.RemoveListener(ChangeFonMusic);
        _sliderVolumeCarMusic.onValueChanged.RemoveListener(ChangeCarMusic);
        _sliderVolumeUIMusic.onValueChanged.RemoveListener(ChangeUIMusic);
    }

    private void ChangeAllMusic(float value)
    {
        _audioMixer.SetFloat(Master, ConvertToDecibels(value/100));
    }

    private void ChangeFonMusic(float value)
    {
        _audioMixer.SetFloat(Fon, ConvertToDecibels(value/100));
    }

    private void ChangeCarMusic(float value)
    {
        _audioMixer.SetFloat(Car, ConvertToDecibels(value/100));
    }

    private void ChangeUIMusic(float value)
    {
        _audioMixer.SetFloat(UI, ConvertToDecibels(value/100));
    }

    private float ConvertToDecibels(float volume)
    {
        if (volume <= 0.001f) return -80f;
        return Mathf.Log10(volume) * 20f;
    }
}
