using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon_in_a : MonoBehaviour
{
    GameObject hand;
    GameObject cc_zone;
    GameObject d_zone;
    GameObject a_zone;
    public turncontroler turncontrol;
    GameObject pass_turn;

    void Start()
    {
        pass_turn=GameObject.Find("pass turn");
        hand=GameObject.Find("player hand"); 
        cc_zone=GameObject.Find("player cc zone");
        d_zone=GameObject.Find("player d zone");
        a_zone=GameObject.Find("player a zone");  
    }
    void OnMouseDown()
    {
        int cards_in_hand=hand.transform.childCount;
        for(int i=0;i<cards_in_hand;i++)
        {
            GameObject card=hand.transform.GetChild(i).gameObject;
            if(card.GetComponent<carta>().Ready_to_a)
            {
                card.transform.SetParent(gameObject.transform);
                card.GetComponent<carta>().InBattle=true;
                cc_zone.GetComponent<Collider2D>().enabled=false;
                d_zone.GetComponent<Collider2D>().enabled=false;
                a_zone.GetComponent<Collider2D>().enabled=false;
                card.GetComponent<carta>().Ready_to_cc=false;
                card.GetComponent<carta>().Ready_to_d=false;
                card.GetComponent<carta>().Ready_to_a=false;
                pass_turn.SetActive(true);
                Destroy(GameObject.FindGameObjectWithTag("block collider"));
                Destroy(GameObject.FindGameObjectWithTag("texto multitipo"));
                if(turncontrol.play_Oin_actual_round)
                {
                    turncontrol.yourturn=false;
                }
                break;
            }
        }
    }
}
