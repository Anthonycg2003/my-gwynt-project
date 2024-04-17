using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroler : MonoBehaviour
{
    public roundcontroler RoundControler;
    public Image player_win;
    public Image player_lose;
    public Image draw;
    bool finished_game;
    void Start()
    {
        finished_game=false;
    }
    void Update()
    {
        if(RoundControler.player_round_wins==2 || RoundControler.O_round_wins==2)
        {
            if(RoundControler.player_round_wins>RoundControler.O_round_wins && finished_game==false)
            {
                Instantiate(player_win,GameObject.Find("Canvas").transform);
                finished_game=true;
            }
            else if(RoundControler.player_round_wins<RoundControler.O_round_wins && finished_game==false)
            {
                Instantiate(player_lose,GameObject.Find("Canvas").transform);
                finished_game=true;
            }
            else if(RoundControler.player_round_wins==RoundControler.O_round_wins && finished_game==false)
            {
                Instantiate(draw,GameObject.Find("Canvas").transform);
                finished_game=true;
            }
            Time.timeScale=0f;
        }
    
        
    }
}
