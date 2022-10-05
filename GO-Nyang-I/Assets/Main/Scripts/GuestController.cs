using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    private GameObject AudioManager;

    private void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
    }

    public void OnTouchedDrink()
    {
        AudioManager.GetComponent<AudioController>().OnPlayCatSound();
    }
}
