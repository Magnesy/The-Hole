using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private GameObject gameWinDisplay;
    [SerializeField] private GameObject navigator;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject winSound;
    [SerializeField] private AudioSource eatSound;
    private float value;
    
    
    private void Start() 
    {
        value = 100f / GameObject.FindGameObjectsWithTag("Objects").Length;
    }
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Objects"))
        {
            other.gameObject.SetActive(false);

            slider.value += value;

            eatSound.Play();

            if(slider.value >= 99.5f)
            {
                winSound.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
                Invoke("GameWinDisplay", 0.7f);
            }
        }
        if(other.CompareTag("bomb"))
        {
            other.gameObject.SetActive(false);
            explosion.SetActive(true);
            Invoke("GameOverDisplay",1);
            this.GetComponent<BoxCollider>().enabled = false;

        }
    }
    
    public void GameOverDisplay()
    {
        gameOverDisplay.gameObject.SetActive(true);
    }

    public void GameWinDisplay()
    {
        gameWinDisplay.gameObject.SetActive(true);
    }

}
