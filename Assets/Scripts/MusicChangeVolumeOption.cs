using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicChangeVolumeOption : MonoBehaviour
{
    private const float ConvertMultiplier = 20f;

    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private MusicOptionType _musicOptionType;
    [SerializeField] private Slider _volumeSlider;

    private string _musicParameterName;

    private void Awake()
    {
        _musicParameterName = _musicOptionType.ToString();
    }

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float level)
    {
        _audioMixer.audioMixer.SetFloat(_musicParameterName, ConvertToAttenuation(level));
    }

    private float ConvertToAttenuation(float level)
    {
        return Mathf.Log10(level) * ConvertMultiplier;
    }
}