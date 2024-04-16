using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class carta : MonoBehaviour
{
    //atributos de unidad
    public int poder;
    public string tipo;
    public string unidad;
    
    //definiendo zonas del campo donde pueden ser invocadas
    GameObject cc;
    GameObject d;
    GameObject a;
    GameObject w;
    GameObject Hcc;
    GameObject Hd;
    GameObject Ha;

    //en el menu
    public bool IsSelected;
    public bool InMenu;
    //comprobar si es tu turno
    public turncontroler turncontr;
    //cementerio
    public GameObject graveyard;
    //fuerza temporal para cartas de aumento
    public bool poder_temp;
    //comprobar si esta en el campo
    public bool InBattle;
    //cartas que tienen mas de un tipo
    public bool Ready_to_cc;
    public bool Ready_to_d;
    public bool Ready_to_a;
    public GameObject block_hand;
    GameObject pass_turn;
    public TMP_Text texto_multitipo;
    //cuando se activa el senuelo
    public bool Is_Decoy_activate;
    GameObject hand;
    GameObject Occ;
    GameObject Od;
    GameObject Oa;
    public TMP_Text texto_decoy;
    
    void Start()
    {
        pass_turn=GameObject.Find("pass turn");
        cc=GameObject.Find("player cc zone");
        d=GameObject.Find("player d zone");
        a=GameObject.Find("player a zone");  
        w=GameObject.Find("weather zone");
        Hcc=GameObject.Find("player horn cc zone");
        Hd=GameObject.Find("player horn d zone");
        Ha=GameObject.Find("player horn a zone");
        graveyard=GameObject.Find("player graveyard");
        IsSelected=false;  
        InMenu=false;  
        poder_temp=false;
        InBattle=false;
        Ready_to_cc=false;
        Ready_to_a=false;
        Ready_to_d=false;
        Is_Decoy_activate=false;
        hand=GameObject.Find("player hand");
        Occ=GameObject.Find("O cc zone");
        Od=GameObject.Find("O d zone");
        Oa=GameObject.Find("O a zone");
    }
    void Update()
    {
        //si esta seleccionada en el menu cambiar el tamano
        if(IsSelected==true)
        {
            gameObject.transform.localScale=new Vector3(2f,2f,1);
        }
        else if(IsSelected==false)
        {
            gameObject.transform.localScale=new Vector3(1,1,1);
        }  
    }
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
    }
    void OnMouseDown()
    {
        if(InMenu)
        {
            if(IsSelected==true)
            {
                IsSelected=false;
            }
            else if(IsSelected==false)
            {
                IsSelected=true;
            }
        }
        else if(Is_Decoy_activate)
        {
            for(int i=0;i<hand.transform.childCount;i++)
            {
                if(hand.transform.GetChild(i).GetComponent<carta>().tipo=="s")
                {
                    hand.transform.GetChild(i).SetParent(gameObject.transform.parent);
                    break;
                }
            }
            Destroy(GameObject.FindGameObjectWithTag("block collider"));
            Destroy(GameObject.FindGameObjectWithTag("texto decoy"));
            Disable_decoy_mark(cc);
            Disable_decoy_mark(d);
            Disable_decoy_mark(a);
            Disable_Odecoy_mark(Occ);
            Disable_Odecoy_mark(Od);
            Disable_Odecoy_mark(Oa);
            pass_turn.SetActive(true);
            InBattle=false;
            gameObject.transform.SetParent(hand.transform);
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(turncontr.yourturn==true)
        {
            if(InBattle==false)
            {
                Summon();
            } 
        }
        else
        {
            Debug.Log("no puedes invocar una carta en el turno de tu oponente");            
        }
    }
    void Summon()
    {
        //verifica que puedas jugar en tu turno y el tipo de la carta para asignarle un horizontal como padre 
        if(tipo=="cc" && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(cc.transform);
            InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="d" && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(d.transform);
             InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="a" && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(a.transform);
             InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="w" && w.transform.childCount<3 && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(w.transform);
            InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="despeje" && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(graveyard.transform);
            InBattle=true;
            int a=w.transform.childCount;
            for(int i=0;i<a;i++)
            {
                w.transform.GetChild(0).SetParent(graveyard.transform);
            }  
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            } 
        }
        else if(tipo=="Hcc"&& Hcc.transform.childCount<1 && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(Hcc.transform);
             InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="Hd" && Hd.transform.childCount<1 && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(Hd.transform);
             InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="Ha"&& Ha.transform.childCount<1 && turncontr.play_in_actual_round)
        {
            gameObject.transform.SetParent(Ha.transform);
            InBattle=true;
            if(turncontr.play_Oin_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="s" && turncontr.play_in_actual_round)
        {
            if(cc.transform.childCount!=0 || d.transform.childCount!=0 || a.transform.childCount!=0 || Occ.transform.childCount!=0 || Od.transform.childCount!=0 || Oa.transform.childCount!=0)
            {
                pass_turn.SetActive(false);
                InBattle=true;
                Activate_decoy_mark(cc);
                Activate_decoy_mark(d);
                Activate_decoy_mark(a);
                Activate_Odecoy_mark(Occ);
                Activate_Odecoy_mark(Od);
                Activate_Odecoy_mark(Oa);
                Instantiate(block_hand,GameObject.Find("Canvas").transform);
                Instantiate(texto_decoy,GameObject.Find("Canvas").transform);   
            }
            else
            {
                Debug.Log("No hay cartas en el campo para devolver a la mano");
            }
              
        }
        else if(tipo=="cc y d" && turncontr.play_in_actual_round)
        {
            Ready_to_cc=true;
            Ready_to_d=true;
            cc.GetComponent<Collider2D>().enabled=true;
            d.GetComponent<Collider2D>().enabled=true; 
            Instantiate(block_hand,GameObject.Find("Canvas").transform);
            pass_turn.SetActive(false);
            Instantiate(texto_multitipo,GameObject.Find("Canvas").transform);
        }
        else if(tipo=="a y d" && turncontr.play_in_actual_round)
        {
            Ready_to_a=true;
            Ready_to_d=true;
            a.GetComponent<Collider2D>().enabled=true;
            d.GetComponent<Collider2D>().enabled=true; 
            Instantiate(block_hand,GameObject.Find("Canvas").transform);
            pass_turn.SetActive(false);
            Instantiate(texto_multitipo,GameObject.Find("Canvas").transform);
        }
    }
    void Activate_decoy_mark(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            if(zone.transform.GetChild(i).gameObject.GetComponent<carta>().unidad=="p")
            {
                zone.transform.GetChild(i).gameObject.GetComponent<carta>().Is_Decoy_activate=true;
            }
        }
    }
    void Activate_Odecoy_mark(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            if(zone.transform.GetChild(i).gameObject.GetComponent<Ocarta>().unidad=="p")
            {
                zone.transform.GetChild(i).gameObject.GetComponent<Ocarta>().Is_Decoy_activate=true;
            }
        }
    }
    void Disable_decoy_mark(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            zone.transform.GetChild(i).gameObject.GetComponent<carta>().Is_Decoy_activate=false;
        }
    }
    void Disable_Odecoy_mark(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            zone.transform.GetChild(i).gameObject.GetComponent<Ocarta>().Is_Decoy_activate=false;
        }
    }
}
