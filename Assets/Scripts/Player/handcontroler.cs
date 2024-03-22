using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handcontroler : MonoBehaviour
{
    deckcontroler Deck;
    GameObject hand;
    int contador;
    void Start()
    {
        Deck=GameObject.Find("mazo player").GetComponent<deckcontroler>();  
        hand=GameObject.Find("player hand");  
        contador=0;    
    }
    void Update()
    {
        if(contador<10)
        {
            StartCoroutine("Draw");
        }
        
    }
    IEnumerator Draw()
    {
        if(Deck.deck.Count > 0)//si el mazo tiene mas de un elemento
        {
            Deck.deck[0].transform.SetParent(hand.transform);//asignarle al primer elemnto del deck el horizontal mano como padre
            Deck.deck.RemoveAt(0);//removerlo de la lista
            contador++;
            yield return null;
        } 
        else
        {
            Debug.Log("No quedan cartas en el mazo");
            yield return null;
        }    
    }
}
