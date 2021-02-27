using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu222 : MonoBehaviour
{
    private void M_tart()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayGame()
    {
        Invoke("M_tart", 0.1f);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
