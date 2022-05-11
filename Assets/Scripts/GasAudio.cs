using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasAudio : MonoBehaviour
{
    public AudioClip gas;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(gas, transform.position);
    }
}

