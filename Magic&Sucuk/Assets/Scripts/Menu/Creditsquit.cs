using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditsquit : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public AudioSource cikis;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditsMenu.SetActive(false);
            mainMenu.SetActive(true);
            cikis.Play();
            
        }

    }
     public void Backmenu()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
        cikis.Play();
       
        
    }

}

