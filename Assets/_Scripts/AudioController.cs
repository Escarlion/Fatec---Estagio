using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] public AudioClip buttonSfx, itemSfx;

    private AudioSource audioSource;
     public static AudioController current;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySfx(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }

    public void VolumeConfig(Slider slider)
    {
        audioSource.volume = slider.value;
    }


}
