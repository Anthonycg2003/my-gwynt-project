using System.Collections;
using System.Collections.Generic;
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
    //menu para decoy
    public GameObject menuDecoy;

    
    void Start()
    {
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
        else if(turncontr.yourturn)
        {
            Summon();
        }
        else
        {
            Debug.Log("no puedes invocar una carta en el turno de tu oponente");            
        }
    }
    void Summon()
    {
        //verifica que sea tu turno y el tipo de la carta para asignarle un horizontal como padre 
        if(tipo=="cc")
        {
            gameObject.transform.SetParent(cc.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="d")
        {
            gameObject.transform.SetParent(d.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="a")
        {
            gameObject.transform.SetParent(a.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="w")
        {
            gameObject.transform.SetParent(w.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="despeje")
        {
            gameObject.transform.SetParent(graveyard.transform);
            int a=w.transform.childCount;
            for(int i=0;i<a;i++)
            {
                w.transform.GetChild(0).SetParent(graveyard.transform);
            }   
        }
        else if(tipo=="Hcc")
        {
            gameObject.transform.SetParent(Hcc.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="Hd")
        {
            gameObject.transform.SetParent(Hd.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="Ha")
        {
            gameObject.transform.SetParent(Ha.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo=="s")
        {
            Instantiate(menuDecoy).transform.SetParent(GameObject.Find("Canvas").transform);  
        }
    }
}
