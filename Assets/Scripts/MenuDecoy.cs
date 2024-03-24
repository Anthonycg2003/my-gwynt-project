using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MenuDecoy : MonoBehaviour
{
    GameObject mostrar_cartas1;
    GameObject mostrar_cartas2;
    GameObject mostrar_cartas3;
    GameObject cc;
    GameObject d;
    GameObject a;
    void Start()
    {
        mostrar_cartas1=GameObject.Find("m1");
        mostrar_cartas2=GameObject.Find("m2");
        mostrar_cartas3=GameObject.Find("m3");
        cc=GameObject.Find("player cc zone");
        d=GameObject.Find("player d zone");
        a=GameObject.Find("player a zone");
        Carry_To_menu(cc,mostrar_cartas1);
        Carry_To_menu(d,mostrar_cartas2);
        Carry_To_menu(a,mostrar_cartas3);
    }
    void Update()
    {
        if(mostrar_cartas1 !=null && mostrar_cartas2 !=null && mostrar_cartas3!=null)
        {
           Invoke("Only_1_cardSelect",1f);
        } 
        
    }
    void Carry_To_menu(GameObject zone,GameObject menu_zone)
    {
        int x=zone.transform.childCount;
        for(int i=0;i<x;i++)
        {
            //pasando la primera carta del campo al menu
            Transform card=zone.transform.GetChild(0);
            card.gameObject.GetComponent<carta>().InMenu=true;
            card.SetParent(menu_zone.transform);
        }

    }
    public void Only_1_cardSelect()//verifica que siempre haya 1 carta seleccionada 
    {
        if(mostrar_cartas1!=null && mostrar_cartas2!=null && mostrar_cartas3!=null)//necesario para que cuando se destruya el menu no se intente acceder a el
        {
            int contador=0;
            for(int i=0;i<mostrar_cartas1.transform.childCount;i++)
            {
                GameObject card=mostrar_cartas1.transform.GetChild(i).gameObject;//accede a las 5 primeras cartas del menu
                bool selected=card.GetComponent<carta>().IsSelected;
                if(selected==true && contador<1)
                {
                    contador++;
                }
                else if(selected==true && contador==1)//si esta seleccionada y el contador =2 la descelecciona
                {
                    card.GetComponent<carta>().IsSelected=false;
                }
            }
            for(int i=0;i<mostrar_cartas2.transform.childCount;i++)
            {
                GameObject card=mostrar_cartas2.transform.GetChild(i).gameObject;//accede a las 5 primeras cartas del menu
                bool selected=card.GetComponent<carta>().IsSelected;
                if(selected==true && contador<1)
                {
                    contador++;
                }
                else if(selected==true && contador==1)//si esta seleccionada y el contador =2 la descelecciona
                {
                    card.GetComponent<carta>().IsSelected=false;
                }
            }
            for(int i=0;i<mostrar_cartas3.transform.childCount;i++)
            {
                GameObject card=mostrar_cartas3.transform.GetChild(i).gameObject;//accede a las 5 primeras cartas del menu
                bool selected=card.GetComponent<carta>().IsSelected;
                if(selected==true && contador<1)
                {
                    contador++;
                }
                else if(selected==true && contador==1)//si esta seleccionada y el contador =2 la descelecciona
                {
                    card.GetComponent<carta>().IsSelected=false;
                }
            }
        }        
    }
    public void Select_card()
    {
        if(Seach_Select(mostrar_cartas1) || Seach_Select(mostrar_cartas2) || Seach_Select(mostrar_cartas3))
        {
            Carry_To_game(cc,mostrar_cartas1);
            Carry_To_game(d,mostrar_cartas2);
            Carry_To_game(a,mostrar_cartas3);
            DestroyImmediate(gameObject);
        }
        else
        {
            Debug.Log("Tienes que seleccionar una carta");
        }
        
    } 
    bool Seach_Select(GameObject m)
    {
        int x=m.transform.childCount;
        for(int i=0;i<x;i++)
        {
            if(m.transform.GetChild(i).gameObject.GetComponent<carta>().IsSelected)
            {
                return true;
            }
        }
        return false;

    }
    void Carry_To_game(GameObject zone,GameObject menu_zone)//pasando cartas del menu al campo
    {
        int x=menu_zone.transform.childCount;
        for(int i=0;i<x;i++)
        {
            Transform card=menu_zone.transform.GetChild(0);
            if(card.gameObject.GetComponent<carta>().IsSelected)
            {
                card.gameObject.GetComponent<carta>().InMenu=false;
                card.gameObject.GetComponent<carta>().InBattle=false;
                card.SetParent(GameObject.Find("player hand").transform);
                card.gameObject.GetComponent<carta>().IsSelected=false;
                GameObject.Find("decoy").transform.SetParent(zone.transform);
            }
            else
            {
                card.gameObject.GetComponent<carta>().InMenu=false;
                card.SetParent(zone.transform);
            }
            
        }

    }
}
