using UnityEngine;
using UnityEngine.UI;

public class ClickSoundEvent : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (_audioSource.isPlaying)
            _audioSource.PlayOneShot(_audioSource.clip);
        else
            _audioSource.Play();
    }
}