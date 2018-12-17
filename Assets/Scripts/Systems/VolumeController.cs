using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour {

    [SerializeField] AudioMixer mixer;

    public float masterVolume
    {
        set { mixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, value)); }
    }
    
}
