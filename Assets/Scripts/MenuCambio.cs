using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCambio : MonoBehaviour
{
    public GameObject menu;
    public GameObject hand;
    public GameObject mostrar_cartas1;
    public GameObject mostrar_cartas2;
    public GameObject deck;
    void Start()
    {
        hand.GetComponent<handcontroler>().DrawTen+=Active_menu;
    }
    void Update()
    {
        if(mostrar_cartas1!=null && mostrar_cartas2!=null && menu.activeInHierarchy)
        {
           Only_2_cardsSelect();
        } 
    }
    #region activar menu
     public void Active_menu(object sender, EventArgs e)
    {
        //activando el menu
        menu.SetActive(true);    
        for(int i=0;i<10;i++)
        {
            //pasando la primera carta de la mano al menu
            Transform card=hand.transform.GetChild(0);
            if(i<5)
            {
                //pasando los 5 primeros elementos de la mano al primer horizontal del menu
                card.SetParent(mostrar_cartas1.transform);
            }
            else
            {
                //pasando los otros 5 al otro horizontal
                card.SetParent(mostrar_cartas2.transform);
            }
        }
    }
    #endregion

    #region cerrar menu
    public void SelectCards()//funcion cuando se aprieta el boton
    {
        for(int i=0;i<5;i++)
        {
            Transform card=mostrar_cartas1.transform.GetChild(0);//accediendo al primer elemento del horizontal 1 del menu
            carta c1=card.GetComponent<carta>();
            if(c1.IsSelected==false)//si la carta no esta seleccionada mandarla a la mano
            {
                c1.transform.SetParent(hand.transform);
            }
            else if(c1.IsSelected==true)//si esta seleccionada mandarla al deck
            {
                c1.transform.SetParent(deck.transform);//haciendola hija de deck para que no se vea
                deck.GetComponent<deckcontroler>().deck.Add(c1.gameObject);//agregandola a la lista del deck
                c1.IsSelected=false;//conservar tamano
                hand.GetComponent<handcontroler>().contador++;//robar una carta
            }
        }
        for(int i=0;i<5;i++)//haciendo lo mismo con el otro horizontal
        {
            Transform card2=mostrar_cartas2.transform.GetChild(0);
            carta c2=card2.GetComponent<carta>();
            if(c2.IsSelected==false)
            {
                c2.transform.SetParent(hand.transform);
            }
            else if(c2.IsSelected==true)
            {
                c2.transform.SetParent(deck.transform);
                deck.GetComponent<deckcontroler>().deck.Add(c2.gameObject);
                c2.IsSelected=false;
                hand.GetComponent<handcontroler>().contador++;
            }
            
        }
        deck.GetComponent<deckcontroler>().Shuffle();//al finalizar barajear el deck
        DestroyImmediate(menu);//destruir el menu
    }
    #endregion

    #region inMenu
    public void Only_2_cardsSelect()//verifica que siempre hayan solo 2 cartas seleccionadas
    {
        if(mostrar_cartas1!=null && mostrar_cartas2!=null)//necesario para que cuando se destruya el menu no se intente acceder a el
        {
            int contador=0;
            for(int i=0;i<5;i++)
            {
                GameObject card=mostrar_cartas1.transform.GetChild(i).gameObject;//accede a las 5 primeras cartas del menu
                bool selected=card.GetComponent<carta>().IsSelected;
                if(selected==true && contador<2)
                {
                    contador++;
                }
                else if(selected==true && contador==2)//si esta seleccionada y el contador =2 la descelecciona
                {
                    card.GetComponent<carta>().IsSelected=false;
                }
            }
            for(int i=0;i<5;i++)//lo mismo para las otras 5
            {
                GameObject card=mostrar_cartas2.transform.GetChild(i).gameObject;//accede a las 5 primeras cartas del menu
                bool selected=card.GetComponent<carta>().IsSelected;
                if(selected==true && contador<2)
                {
                    contador++;
                }
                else if(selected==true && contador==2)
                {
                    card.GetComponent<carta>().IsSelected=false;
                }
            }
        }
    }
    #endregion
}
