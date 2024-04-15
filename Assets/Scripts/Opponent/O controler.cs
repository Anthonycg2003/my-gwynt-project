using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ocontroler : MonoBehaviour
{
    public turncontroler Trcontrol;
    GameObject cc;
    GameObject d;
    GameObject a;
    GameObject w;
    GameObject Hcc;
    GameObject Hd;
    GameObject Ha;
    GameObject hand;
    int contador;
    bool Is_Summon;
    void Start()
    {
        hand=GameObject.Find("O hand");
        cc=GameObject.Find("O cc zone");
        d=GameObject.Find("O d zone");
        a=GameObject.Find("O a zone");  
        w=GameObject.Find("weather zone");
        Hcc=GameObject.Find("O horn cc zone");
        Hd=GameObject.Find("O horn d zone");
        Ha=GameObject.Find("O horn a zone");
        contador=0;
        Is_Summon=false;   
    }
    void Update()
    {
        if(Trcontrol.yourturn==false && contador<4 && Trcontrol.isActiveAndEnabled && Is_Summon==false && Trcontrol.play_Oin_actual_round)
        {
            Invoke("Summon",2f);
            Is_Summon=true;
        }
        if(contador==4 && Trcontrol.yourturn==false)
        {
            Trcontrol.PassOTurn();
            contador=0;
        }
    }
    void Summon()
    {
        int cards_in_hand=hand.transform.childCount;
        int random=Random.Range(0,cards_in_hand);
        GameObject card=hand.transform.GetChild(random).gameObject;
        Ocarta comp_carta=card.GetComponent<Ocarta>();
        if(comp_carta.tipo=="cc")
        {
            card.transform.SetParent(cc.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        else if(comp_carta.tipo=="d")
        {
            card.transform.SetParent(d.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        else if(comp_carta.tipo=="a")
        {
            card.transform.SetParent(a.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        else if(comp_carta.tipo=="w")
        {
            card.transform.SetParent(w.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        else if(comp_carta.tipo=="Hcc")
        {
            card.transform.SetParent(Hcc.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        else if(comp_carta.tipo=="Hd")
        {
            card.transform.SetParent(Hd.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        else if(comp_carta.tipo=="Ha")
        {
            card.transform.SetParent(Ha.transform);
            if(Trcontrol.play_in_actual_round)
            {
                Trcontrol.yourturn=true;
            }
        }
        Is_Summon=false;
        contador++;
    }
}
