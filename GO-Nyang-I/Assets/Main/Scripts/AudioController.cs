using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource _bgmPlayer;
    public AudioSource _buttonPlayer;
    public AudioSource _catPlayer;
    public AudioSource _coffeePlayer;
    public AudioSource _coinPlayer;

    [SerializeField]
    private AudioClip mainBgmAudioClip;

    [SerializeField]
    private AudioClip _buttonCips;
    [SerializeField]
    private AudioClip _catCips;
    [SerializeField]
    private AudioClip _coffeeCips;
    [SerializeField]
    private AudioClip _coinCips;

    public void OnPlayBGMSound()
    {
        _bgmPlayer.volume = 2.0f;
        _bgmPlayer.clip = mainBgmAudioClip;
        _bgmPlayer.Play();
    }

    public void OnPlayBtnSound()
    {
        _buttonPlayer.PlayOneShot(_buttonCips, 3.0f);
    }

    public void OnPlayCatSound()
    {
        _catPlayer.PlayOneShot(_catCips, 3.0f);
    }

    public void OnPlayCoffeeSound()
    {
        _coffeePlayer.PlayOneShot(_coffeeCips, 3.0f);
    }

    public void OnPlayCoinSound()
    {
        _coinPlayer.PlayOneShot(_coinCips, 3.0f);
    }
}
