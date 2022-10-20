using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    AudioPlayer audioPlayer;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            audioPlayer.PlayGetCoinClip();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
