
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class turncontroler : MonoBehaviour
{
    public bool? yourturn;
    public bool play_in_actual_round;
    public bool play_Oin_actual_round;
    public TMP_Text turntext;
    public TMP_Text pass_turn_text;
    public TMP_Text pass_o_turn_text;
    public int count_pass_round;
    public GameObject coin;
    void Awake()
    {
        Invoke("StarTurn",0.2f);
        play_in_actual_round=true;
        play_Oin_actual_round=true;
        count_pass_round=0;
        Destroy(coin,3f);
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
        coin.GetComponent<Animator>().enabled=false;
        int x=Random.Range(0,2);
        if(x==0)
        {
            yourturn=true;
            coin.transform.rotation=Quaternion.Euler(0,0,0);
        }
        else
        {
            yourturn=false;
            coin.transform.rotation=Quaternion.Euler(359,0,0);
        }
    }
    public void PassTurn()
    {
        if(yourturn==true)
        {
            yourturn=false;
            play_in_actual_round=false;
            Invoke("Count_pass_round",2f);
            Instantiate(pass_turn_text,GameObject.Find("Canvas").transform);
        }
        
    }
    public void PassOTurn()
    {
        if(yourturn==false)
        {
            yourturn=true;
            play_Oin_actual_round=false;
            Invoke("Count_pass_round",2f);
            Instantiate(pass_o_turn_text,GameObject.Find("Canvas").transform);
        }    
    }
    void PassRound()
    {
        if(count_pass_round>=2)
        {
            GameObject.Find("round controler").GetComponent<roundcontroler>().round+=1;
            count_pass_round=0;
            play_in_actual_round=true;
            play_Oin_actual_round=true;
        }
    }
    void Count_pass_round()
    {
        count_pass_round+=1;
    }
}
