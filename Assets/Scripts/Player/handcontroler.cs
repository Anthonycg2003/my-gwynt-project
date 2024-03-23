using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handcontroler : MonoBehaviour
{
    deckcontroler Deck;
    public int contador;
    GameObject graveyard;
    void Start()
    {
        Deck=GameObject.Find("mazo player").GetComponent<deckcontroler>();
        graveyard=GameObject.Find("player graveyard"); 
        contador=0;
        StartCoroutine(Draw(10));   
    }
    void Update()
    {
        if(contador>10)//robar carta
        {
            Deck.deck[0].transform.SetParent(gameObject.transform);//asignarle al primer elemnto del deck el horizontal mano como padre
            Deck.deck.RemoveAt(0);//removerlo de la lista
            contador--;
        }
        if(gameObject.transform.childCount>10)//si hay mas de 10 cartas en la mano 
        {
            gameObject.transform.GetChild(10).SetParent(graveyard.transform);
        }
    }
    public IEnumerator Draw(int n)
    {
        for(int i=0;i<n;i++)
        {
            Deck.deck[0].transform.SetParent(gameObject.transform);//asignarle al primer elemnto del deck el horizontal mano como padre
            Deck.deck.RemoveAt(0);//removerlo de la lista
            contador++;
            yield return new WaitForSeconds(0.3f);
        } 
        DrawTen?.Invoke(this,EventArgs.Empty);//activando evento cuando se ejecuta la funcion
    }
    public event EventHandler DrawTen;//evento cuando terminas de robar al inicio
}
