using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordermenumainscript : MonoBehaviour
{
    bool onetotwo = false ;
    bool twotothree = false;
    bool threetofour = false;

    public Transform first;
    public Transform second;
    public Transform third;
    public Transform fourth;

    private void Start()
    {
        first = GameObject.Find("first").GetComponent<Transform>();
        second = GameObject.Find("second").GetComponent<Transform>();
        third = GameObject.Find("third").GetComponent<Transform>();
        fourth = GameObject.Find("fourth").GetComponent<Transform>();

    }

    
   
    public void change_one()
    {
    onetotwo = !onetotwo;

    }
    public void change_two()
    {
            
    twotothree = !twotothree;



    }
    public void change_three()
    {
                
    threetofour = !threetofour;

    }


    void Update()
    {

        if (onetotwo == true)
        {
            first = second;
            second = first;
            onetotwo = !onetotwo;
        }

        if (twotothree == true)
        {
            second = third;
            third = second;
            twotothree = !twotothree;
        }

        if (threetofour == true)
        {
            third = fourth;
            fourth = third;
            threetofour = !threetofour;
        }
    }
}