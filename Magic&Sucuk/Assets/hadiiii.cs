using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hadiiii : MonoBehaviour
{
    public GameObject at;
    public GameObject havalikorna;
    public GameObject madanadrak;
    public GameObject zombi;
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
        birincisira = new Vector3(-650, -250, 0);
        ikincisira = new Vector3(-200, -250, 0);
        ucuncusira = new Vector3(300, -250, 0);
        dorduncusira = new Vector3(750, -250, 0);
    }
    public void atsirasi()
    {

        

        if (secimsirasi < 1)
        {



            at.SetActive(true);
            at.transform.position = birincisira;
            secimsirasi++;
            atatandi = !atatandi;
        }
        else if ( secimsirasi <2)
        {

            
       
            at.SetActive(true);
            at.transform.position = ikincisira;
            secimsirasi++;
            atatandi = !atatandi;
        }
        else if (secimsirasi < 3)
        {



            at.SetActive(true);
            at.transform.position = ucuncusira;
            secimsirasi++;
            atatandi = !atatandi;
        }

      
    }
    public void havalikornasirasi()
    {



        if (secimsirasi < 1)
        {



            havalikorna.SetActive(true);
            havalikorna.transform.position = birincisira;
            secimsirasi++;
            havalikornaatandi = !havalikornaatandi;
        }
        else if (secimsirasi < 2)
        {



            havalikorna.SetActive(true);
            havalikorna.transform.position = ikincisira;
            secimsirasi++;
            havalikornaatandi = !havalikornaatandi;
        }
        else if (secimsirasi < 3)
        {



            havalikorna.SetActive(true);
            havalikorna.transform.position = ucuncusira;
            secimsirasi++;
            havalikornaatandi = !havalikornaatandi;
        }


    }
    public void madanadraksirasi()
    {



        if (secimsirasi < 1)
        {



            madanadrak.SetActive(true);
            madanadrak.transform.position = birincisira;
            secimsirasi++;
            madanadrakatandi = !madanadrakatandi;
        }
        else if (secimsirasi < 2)
        {



            madanadrak.SetActive(true);
            madanadrak.transform.position = ikincisira;
            secimsirasi++;
            madanadrakatandi = !madanadrakatandi;
        }
        else if (secimsirasi < 3)
        {



            madanadrak.SetActive(true);
            madanadrak.transform.position = ucuncusira;
            secimsirasi++;
            madanadrakatandi = !madanadrakatandi;
        }


    }
    public void zombisirasi()
    {



        if (secimsirasi < 1)
        {



            zombi.SetActive(true);
            zombi.transform.position = birincisira;
            secimsirasi++;
            zombiatandi = !zombiatandi;
        }
        else if (secimsirasi < 2)
        {



            zombi.SetActive(true);
            zombi.transform.position = ikincisira;
            secimsirasi++;
            zombiatandi = !zombiatandi;
        }
        else if (secimsirasi < 3)
        {



            zombi.SetActive(true);
            zombi.transform.position = ucuncusira;
            secimsirasi++;
            zombiatandi = !zombiatandi;
        }


    }
    void Update()
    {
        if (secimsirasi == 3)
        {
            if (atatandi)
            {
                if (havalikornaatandi)
                {
                    if (madanadrakatandi)
                    {
                        if (zombiatandi)
                        {
                            //sonraki sahneye geçme komutu




                        }

                        else
                        {
                            zombi.SetActive(true);
                            zombi.transform.position= dorduncusira;
                        }


                    }
                    else
                    {

                        madanadrak.SetActive(true);
                        madanadrak.transform.position = dorduncusira;
                    }

                }

                else
                {
                    havalikorna.SetActive(true);
                    havalikorna.transform.position = dorduncusira;
                }


            }

            else
            {
                at.SetActive(true);
                at.transform.position = dorduncusira;

            }

        }
    }
}
