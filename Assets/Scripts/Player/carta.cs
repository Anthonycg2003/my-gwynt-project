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

    //en el menu
    public bool IsSelected;
    public bool InMenu;
    //comprobar si es tu turno
    public turncontroler turncontr;

    
    void Start()
    {
        cc=GameObject.Find("player cc zone");
        d=GameObject.Find("player d zone");
        a=GameObject.Find("player a zone");  
        IsSelected=false;  
        InMenu=false;  
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
        if(tipo.Contains("cc"))
        {
            gameObject.transform.SetParent(cc.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo.Contains("d"))
        {
            gameObject.transform.SetParent(d.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
        else if(tipo.Contains("a"))
        {
            gameObject.transform.SetParent(a.transform);
            if(turncontr.play_in_actual_round)
            {
                turncontr.yourturn=false;
            }
        }
    }
}
