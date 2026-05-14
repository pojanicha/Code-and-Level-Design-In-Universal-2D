using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.value = AudioManager.Instance.CurrentVolume;

        slider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
    }
}