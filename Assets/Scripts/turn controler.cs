using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class turncontroler : MonoBehaviour
{
    public bool yourturn;
    public bool play_in_actual_round;
    public bool play_O_in_actual_round;
    public TMP_Text turntext;
    void Start()
    {
        StarTurn();
        play_in_actual_round=true;
        play_O_in_actual_round=true;
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
    public void PassTurn()
    {
        yourturn=false;
        play_in_actual_round=false;
    }
    public void PassOTurn()
    {
        yourturn=true;
        play_in_actual_round=false;
    }
}
