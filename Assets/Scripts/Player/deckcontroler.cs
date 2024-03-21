using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deckcontroler : MonoBehaviour
{
    // Definiendo lista de cartas
    public List<GameObject> deck;
    void Start()
    {
        //agregando a la lista todas las cartas que sean hijas de mazo
        for(int i=0;i<gameObject.transform.childCount;i++)
        {
            deck.Add(gameObject.transform.GetChild(i).gameObject);
        }  
    }
    void Update()
    {
        
    }
}
