using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioClip coin;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coin, transform.position);
    }
}
