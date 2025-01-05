using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource _explosion_audio;
    // Start is called before the first frame update
    void Start()
    {
        _explosion_audio = GetComponent<AudioSource>();
        _explosion_audio.Play();
        Destroy(this.gameObject, 2.35f);
    }

}
