using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lider : MonoBehaviour
{
    roundcontroler round_control;
    handcontroler hand_control;
    public turncontroler turncontr;
    
    bool efect_activate;
    void Start()
    {
        round_control=GameObject.Find("round controler").GetComponent<roundcontroler>();
        hand_control=GameObject.Find("player hand").GetComponent<handcontroler>(); 
        efect_activate=false;
    }
   void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
    }
    void OnMouseDown()
    {
        if(round_control.round==2 && efect_activate==false)
        {
            hand_control.contador++;
            efect_activate=true;
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
    }
}
