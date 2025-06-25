using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteOption : MonoBehaviour
{
    private const float MinVolume = -79.9999f;

    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private MusicOptionType _musicOptionType;

    [SerializeField] private Toggle _muteToggle;
    [SerializeField] private Slider _volumeSlider;

    private float _previousVolume = MinVolume;
    private string _musicParameterName;

    private void Awake()
    {
        _musicParameterName = _musicOptionType.ToString();
    }

    private void OnEnable()
    {
        _muteToggle.onValueChanged.AddListener(OnToggleValueChange);
        _volumeSlider.onValueChanged.AddListener(OnSliderValueChange);
    }

    private void OnDisable()
    {
        _muteToggle.onValueChanged.RemoveListener(OnToggleValueChange);
        _volumeSlider.onValueChanged.RemoveListener(OnSliderValueChange);
    }

    private void OnToggleValueChange(bool isOn)
    {
        AudioMixer audioMixer = _audioMixer.audioMixer;

        if (audioMixer.GetFloat(_musicParameterName, out float current) == false)
            throw new InvalidOperationException(nameof(_musicOptionType));

        audioMixer.SetFloat(_musicParameterName, _previousVolume);
        _previousVolume = current;
    }

    private void OnSliderValueChange(float volume)
    {
        if (_muteToggle.isOn == false)
            return;

        _previousVolume = volume;
        _muteToggle.isOn = false;
        _previousVolume = MinVolume;
    }
}