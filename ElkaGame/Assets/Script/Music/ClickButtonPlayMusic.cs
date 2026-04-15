using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ClickButtonPlayMusic : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private AudioClip _audioClip;
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlayMusic);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.clip = _audioClip;
        _audioSource.outputAudioMixerGroup = _audioMixerGroup;
    }
    private void PlayMusic()
    {
        Debug.Log("Click");
        _audioSource.Play();
    }
}
