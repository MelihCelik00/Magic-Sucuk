using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenüAnim : MonoBehaviour
{
    public Text Play_text, Credits_text, Quit_text;
    float x;

    private void FixedUpdate()
    {
        x += -0.5f;
        Play_text.transform.eulerAngles = new Vector3(0, 0, x);
    }
    private void OnMouseOver()
    {
        Play_text.fontSize = 150;
        Play_text.transform.eulerAngles = new Vector3(0, 0, 180);
    }
    private void OnMouseExit()
    {
        Play_text.fontSize = 100;
        Play_text.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
