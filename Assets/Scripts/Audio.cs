using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource _finGanar;
    public AudioSource _finPerder;
    public AudioSource _InGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayFinGanar()
    {
        _finGanar.Play();
    }
    public void PlayFinPerder()
    {
        _finPerder.Play();
    }
    public void StopSound()
    {
        _InGame.Stop();
    }

}
