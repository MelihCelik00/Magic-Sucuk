using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASADÖNGÜSÜ : MonoBehaviour
{
    public Animator masa_anim;
    public int tur_sayisi = 0;
    //Tur_sayisi diğer kodlara bağlanıcak.

    void Update()

    {
        if ( tur_sayisi > 5)
        {
            tur_sayisi = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            tur_sayisi = tur_sayisi + 1;
            masa_anim.SetInteger("Tur_sayisi", tur_sayisi);
        }

        if(tur_sayisi >= 2 && tur_sayisi != 5)
        {
            tersinedöngü();
            // Zırhların değişmesi
        }
    }

    void tersinedöngü()
    {
        Debug.Log("Durum tersine döndü");
    }
}
