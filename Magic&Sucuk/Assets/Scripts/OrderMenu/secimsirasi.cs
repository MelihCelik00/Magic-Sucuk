using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secimsirasi : MonoBehaviour
{
    int sira = 1;
    public GameObject birinci, ikinci, ücüncü, dördüncü;
    
    void Update()
    {
        if (sira == 1)
        {
            secim1();
        }
    }

    public void secim1()
    {
        birinci = this.gameObject;
        birinci.transform.position = new Vector3(300, -250, 0);
        sira++;
    }
}
