using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(AudioSource))]
public class CarEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effects;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;


    private Move _move;
    private AudioSource _audioSource;

    private void Awake()
    {
        _move = GetComponent<Move>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
        _audioSource.outputAudioMixerGroup = _audioMixerGroup;
    }

    private void Update()
    {
        if(_move.IsMove == true)
        {
            if(_audioSource.isPlaying == false)
            {
                _audioSource.Play();

            }

            if(_effects.isPlaying == false)
            {
                _effects.gameObject.SetActive(true);
                _effects.Play();
            }
        }
        else
        {
            _effects.gameObject.SetActive(false);
            _audioSource.Stop();
        }
    }
}
