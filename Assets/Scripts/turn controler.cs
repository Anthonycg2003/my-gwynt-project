
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
    public TMP_Text turntext;
    public int count_pass_round;
    void Awake()
    {
        StarTurn();
        play_in_actual_round=true;
        count_pass_round=0;
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
        PassRound();   
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
        if(yourturn==true)
        {
            yourturn=false;
            play_in_actual_round=false;
            count_pass_round+=1;
        }
        
    }
    public void PassOTurn()
    {
        if(yourturn==false)
        {
            yourturn=true;
            play_in_actual_round=false;
            count_pass_round+=1;
        }
        
    }
    void PassRound()
    {
        if(count_pass_round>=2)
        {
            GameObject.Find("round controler").GetComponent<roundcontroler>().round+=1;
            count_pass_round=0;
        }

    }
}
