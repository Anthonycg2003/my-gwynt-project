using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class roundcontroler : MonoBehaviour
{
    public int round;
    public GameObject cc;
    public GameObject d;
    public GameObject a;
    public GameObject Occ;
    public GameObject Od;
    public GameObject Oa;
    public GameObject w;
    public GameObject Graveyard;
    public GameObject GraveyardO;
    public GameObject hornA;
    public GameObject hornCc;
    public GameObject hornD;
    GameObject TotalPower;
    GameObject totalOPower;
    public GameObject hand;
    GameObject O_hand;
    public turncontroler Turncontroler;

   //bool para mandar solo una vez al cementerio
   public bool pass_1st_round;//ronda 2
   public bool pass_2nd_round;//ronda 3
   public TMP_Text round_win;
   public TMP_Text round_lose;
   public TMP_Text round_draw;
   public int player_round_wins;
   public int O_round_wins;
   bool finish_game;
   
    // Start is called before the first frame update
    void Start()
    {
        round=1;
        pass_1st_round=false;
        pass_2nd_round=false;
        TotalPower=GameObject.Find("player power");
        totalOPower=GameObject.Find("O power");
        O_hand=GameObject.Find("O hand");
        finish_game=false;
    }

    // Update is called once per frame
    void Update()
    {
        int player_power=TotalPower.GetComponent<Power>().Fuerza_total;
        int O_power=totalOPower.GetComponent<OPower>().Fuerza_total;
        if(round==2 && pass_1st_round==false)
        {
            if(player_power>O_power)
            {
                player_round_wins++;
                Destroy(GameObject.Find("O life 1"));
                Turncontroler.yourturn=true;
                Instantiate(round_win,GameObject.Find("Canvas").transform);
            }
            else if(O_power>player_power)
            {
                O_round_wins++;
                Destroy(GameObject.Find("player life 1"));
                Turncontroler.yourturn=false;
                Instantiate(round_lose,GameObject.Find("Canvas").transform);
            }
            else
            {
                O_round_wins++;
                player_round_wins++;
                Destroy(GameObject.Find("O life 1"));
                Destroy(GameObject.Find("player life 1"));
                Instantiate(round_draw,GameObject.Find("Canvas").transform);
            }
            Send_graveyard(w);
            Send_graveyard(a);
            Send_graveyard(cc);
            Send_graveyard(d);
            Send_graveyard(hornD);
            Send_graveyard(hornA);
            Send_graveyard(hornCc);
            Send_graveyardO(Oa);
            Send_graveyardO(Occ);
            Send_graveyardO(Od);
            hand.GetComponent<handcontroler>().contador+=2;
            O_hand.GetComponent<Ohandcontroler>().contador-=2;//para robar 2 cartas al finalizar la ronda
            pass_1st_round=true;
        }
        if(round==3 && pass_2nd_round==false)
        {
            if(player_power>O_power)
            {
                player_round_wins++;
                Destroy(GameObject.Find("O life 2"));
                Turncontroler.yourturn=true;
                Instantiate(round_win,GameObject.Find("Canvas").transform);
            }
            else if(O_power>player_power)
            {
                O_round_wins++;
                Destroy(GameObject.Find("player life 2"));
                Turncontroler.yourturn=false;
                Instantiate(round_lose,GameObject.Find("Canvas").transform);
            }
            else
            {
                O_round_wins++;
                player_round_wins++;
                Destroy(GameObject.Find("O life 2"));
                Destroy(GameObject.Find("player life 2"));
                Instantiate(round_draw,GameObject.Find("Canvas").transform);
            }
            Send_graveyard(w);
            Send_graveyard(a);
            Send_graveyard(cc);
            Send_graveyard(d);
            Send_graveyard(hornD);
            Send_graveyard(hornA);
            Send_graveyard(hornCc);
            Send_graveyardO(Oa);
            Send_graveyardO(Occ);
            Send_graveyardO(Od);
            hand.GetComponent<handcontroler>().contador+=2;//para robar 2 cartas al finalizar la ronda
            pass_2nd_round=true;
            O_hand.GetComponent<Ohandcontroler>().contador-=2;
        }
        if(round==4 && finish_game==false)
        {
            if(player_power>O_power)
            {
                player_round_wins++;
                Instantiate(round_win,GameObject.Find("Canvas").transform);
            }
            else if(O_power>player_power)
            {
                O_round_wins++;
                Instantiate(round_lose,GameObject.Find("Canvas").transform);
            }
            else if(O_power==player_power)
            {
                O_round_wins++;
                player_round_wins++;
                Instantiate(round_draw,GameObject.Find("Canvas").transform);
            }
            Send_graveyard(w);
            Send_graveyard(a);
            Send_graveyard(cc);
            Send_graveyard(d);
            Send_graveyard(hornD);
            Send_graveyard(hornA);
            Send_graveyard(hornCc);
            Send_graveyardO(Oa);
            Send_graveyardO(Occ);
            Send_graveyardO(Od);
            finish_game=true;
        }
    }
    void Send_graveyard(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            zone.transform.GetChild(0).SetParent(Graveyard.transform);
        }
    }
    void Send_graveyardO(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            zone.transform.GetChild(0).SetParent(GraveyardO.transform);
        }
    }

}
