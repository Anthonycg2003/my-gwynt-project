using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class turncontroler : MonoBehaviour
{
    public bool yourturn;
    public TMP_Text turntext;
    void Start()
    {
        StarTurn();
    }
    void Update()
    {  
        if(yourturn==true)
        {
            turntext.text="Tu turno";
        }
        else
        {
            turntext.text="Turno del oponente";
        }     
    }
    void StarTurn()
    {
        int x=Random.Range(0,2);
        if(x==0)
        {
            yourturn=true;
        }
        else
        {
            yourturn=false;
        }
    }
}
