using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class yonetici : MonoBehaviour
{   public GameObject at;
    public GameObject havalikorna;
    public GameObject madanadrak;
    public GameObject zombi;
    public GameObject adana;
    public GameObject bursa;
    public GameObject ceyhan;
    public GameObject denizli;
    public GameObject devambutonu;
    public GameObject geributonu;
    public GameObject yenidenbutonu;
    int secimsirasi = 0;
    Vector3 birincisira;
    Vector3 ikincisira;
    Vector3 ucuncusira;
    Vector3 dorduncusira;
    bool atatandi = false;
    bool havalikornaatandi = false;
    bool madanadrakatandi = false;
    bool zombiatandi = false;

    private void Start()
    {
        birincisira = adana.transform.position;
        ikincisira = bursa.transform.position;
        ucuncusira = ceyhan.transform.position;
        dorduncusira = denizli.transform.position;
    }
    public void atsirasi()
    {

        if (!atatandi)
        {

            if (secimsirasi < 1)
            {



                at.SetActive(true);
                at.transform.position = birincisira;
                secimsirasi++;
                atatandi = !atatandi;
                PlayerPrefs.SetInt("atadam", 1);
            }
            else if (secimsirasi < 2)
            {



                at.SetActive(true);
                at.transform.position = ikincisira;
                secimsirasi++;
                atatandi = !atatandi;
                PlayerPrefs.SetInt("atadam", 2);
            }
            else if (secimsirasi < 3)
            {



                at.SetActive(true);
                at.transform.position = ucuncusira;
                secimsirasi++;
                atatandi = !atatandi;
                PlayerPrefs.SetInt("atadam", 3);
            }

        }
    }
    public void havalikornasirasi()
    {
        if (!havalikornaatandi)
        {

            if (secimsirasi < 1)
            {



                havalikorna.SetActive(true);
                havalikorna.transform.position = birincisira;
                secimsirasi++;
                havalikornaatandi = !havalikornaatandi;
                PlayerPrefs.SetInt("havalikorna", 1);
            }
            else if (secimsirasi < 2)
            {



                havalikorna.SetActive(true);
                havalikorna.transform.position = ikincisira;
                secimsirasi++;
                havalikornaatandi = !havalikornaatandi;
                PlayerPrefs.SetInt("havalikorna", 2);
            }
            else if (secimsirasi < 3)
            {



                havalikorna.SetActive(true);
                havalikorna.transform.position = ucuncusira;
                secimsirasi++;
                havalikornaatandi = !havalikornaatandi;
                PlayerPrefs.SetInt("havalikorna", 3);
            }

        }
    }
    public void madanadraksirasi()
    {

        if (!madanadrakatandi)
        {

            if (secimsirasi < 1)
            {



                madanadrak.SetActive(true);
                madanadrak.transform.position = birincisira;
                secimsirasi++;
                madanadrakatandi = !madanadrakatandi;
                PlayerPrefs.SetInt("madanadrak", 1);
            }
            else if (secimsirasi < 2)
            {



                madanadrak.SetActive(true);
                madanadrak.transform.position = ikincisira;
                secimsirasi++;
                madanadrakatandi = !madanadrakatandi;
                PlayerPrefs.SetInt("madanadrak", 2);
            }
            else if (secimsirasi < 3)
            {



                madanadrak.SetActive(true);
                madanadrak.transform.position = ucuncusira;
                secimsirasi++;
                madanadrakatandi = !madanadrakatandi;
                PlayerPrefs.SetInt("madanadrak", 3);
            }
        }

    }
    public void zombisirasi()
    {
        if (!zombiatandi)
        {
            if (secimsirasi < 1)
            {



                zombi.SetActive(true);
                zombi.transform.position = birincisira;
                secimsirasi++;
                zombiatandi = !zombiatandi;
                PlayerPrefs.SetInt("zombi", 1);
            }
            else if (secimsirasi < 2)
            {



                zombi.SetActive(true);
                zombi.transform.position = ikincisira;
                secimsirasi++;
                zombiatandi = !zombiatandi;
                PlayerPrefs.SetInt("zombi", 2);
            }
            else if (secimsirasi < 3)
            {



                zombi.SetActive(true);
                zombi.transform.position = ucuncusira;
                secimsirasi++;
                zombiatandi = !zombiatandi;
                PlayerPrefs.SetInt("zombi", 3);
            }
        }

    }

    public void sonrakisahne()
    {
        SceneManager.LoadScene("TurnBasedTestScene");


    }
    public void oncekisahne()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void silbastan()
    {

        if( zombiatandi || atatandi || havalikornaatandi || madanadrakatandi)
        {
            zombiatandi = false;
            atatandi = false;
            madanadrakatandi = false;
            havalikornaatandi = false;
            at.SetActive(false);
            zombi.SetActive(false);
            madanadrak.SetActive(false);
            havalikorna.SetActive(false);
            devambutonu.SetActive(false);
            secimsirasi = 0;
        }

    }
    void Update()
    {

        if (zombiatandi || atatandi || havalikornaatandi || madanadrakatandi)
        {
           yenidenbutonu.SetActive(true);

        }




        if (secimsirasi == 3 || secimsirasi == 4)
        {
            if (atatandi)
            {
                if (havalikornaatandi)
                {
                    if (madanadrakatandi)
                    {
                        if (zombiatandi)
                        {
                            devambutonu.SetActive(true);




                        }

                        else
                        {
                            zombi.SetActive(true);
                            zombi.transform.position = dorduncusira;
                            PlayerPrefs.SetInt("zombi", 4);
                            devambutonu.SetActive(true);
                        }


                    }
                    else
                    {

                        madanadrak.SetActive(true);
                        madanadrak.transform.position = dorduncusira;
                        PlayerPrefs.SetInt("madanadrak", 4);
                        devambutonu.SetActive(true);
                    }

                }

                else
                {
                    havalikorna.SetActive(true);
                    havalikorna.transform.position = dorduncusira;
                    PlayerPrefs.SetInt("havalikorna", 4);
                    devambutonu.SetActive(true);
                }


            }

            else
            {
                at.SetActive(true);
                at.transform.position = dorduncusira;
                PlayerPrefs.SetInt("atadam", 4);
                devambutonu.SetActive(true);
            }

        }
    }
}
