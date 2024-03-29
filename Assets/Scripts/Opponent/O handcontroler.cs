using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohandcontroler : MonoBehaviour
{
    Odeckcontroler Deck;
    public int contador;
    GameObject graveyard;
    void Start()
    {
        Deck=GameObject.Find("mazo O").GetComponent<Odeckcontroler>();
        graveyard=GameObject.Find("O graveyard"); 
        contador=0;   
    }
    void Update()
    {
        if(contador<10)//robar carta
        {
            Deck.deck[0].transform.SetParent(gameObject.transform);//asignarle al primer elemnto del deck el horizontal mano como padre
            Deck.deck.RemoveAt(0);//removerlo de la lista
            contador++;
        }
        if(gameObject.transform.childCount>10)//si hay mas de 10 cartas en la mano 
        {
            gameObject.transform.GetChild(10).SetParent(graveyard.transform);
        }
    }
}
