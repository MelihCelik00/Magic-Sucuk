using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimKod : MonoBehaviour
{
    public Animator pink_cloyd, hava_i, kardan, at, zombi;

   
    void Update()
    {
        //hava-i sald˝r˝s˝
        hava_i.SetTrigger("Attack-korna");
        pink_cloyd.SetTrigger("Defans-bulut");

        //hava-i savunma
        hava_i.SetTrigger("Defans-korna");
        pink_cloyd.SetTrigger("Attack-bulut");

        //hava-i Destek
        hava_i.SetTrigger("Support-korna");

        //----
        //atadam sald˝r˝s˝
        at.SetTrigger("Attack-at");
        pink_cloyd.SetTrigger("Defans-bulut");

        //atadam savunma
        at.SetTrigger("Defans-at");
        pink_cloyd.SetTrigger("Attack-bulut");

        //atadam Destek
        at.SetTrigger("Support-at");

        //----
        //kardan sald˝r˝s˝
        kardan.SetTrigger("Attack-snow");
        pink_cloyd.SetTrigger("Defans-bulut");

        //kardan savunma
        kardan.SetTrigger("Defans-snow");
        pink_cloyd.SetTrigger("Attack-bulut");

        //kardan Destek
        kardan.SetTrigger("Support-snow");

        //----
        //zombi sald˝r˝s˝
        zombi.SetTrigger("Attack-z");
        pink_cloyd.SetTrigger("Defans-bulut");

        //zombi savunma
        zombi.SetTrigger("Defans-z");
        pink_cloyd.SetTrigger("Attack-bulut");

        //zombi Destek
        zombi.SetTrigger("Support-z");

        //bulut Destek
        pink_cloyd.SetTrigger("Support-bulut");

    }





}
