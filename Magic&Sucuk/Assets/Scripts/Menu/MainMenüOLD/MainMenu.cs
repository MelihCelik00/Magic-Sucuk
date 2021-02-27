using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject htpMenu;
        public GameObject creditsMenu;
        public AudioSource giris, cikis; 
  
        public void PlayGame()
        {
            giris.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void HowToPlayMenu()
        {
            mainMenu.SetActive(false);
            htpMenu.SetActive(true);
        }

        public void Credits()
        {
            giris.Play();
            mainMenu.SetActive(false);
            creditsMenu.SetActive(true);
        }
        
        public void QuitGame()
        {
            cikis.Play();
            Application.Quit();
        }

        public void GoBack()
        {
            if (htpMenu.activeSelf)
            {
                htpMenu.SetActive(false);
            }else if (creditsMenu.activeSelf)
            {
                creditsMenu.SetActive(false);
            }
            mainMenu.SetActive(true);
            
        }
    }
}
