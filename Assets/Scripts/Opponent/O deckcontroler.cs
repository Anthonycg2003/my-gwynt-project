using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odeckcontroler : MonoBehaviour
{
   public List<GameObject> deck;
    void Start()
    {
        //agregando a la lista todas las cartas que sean hijas de mazo
        for(int i=0;i<gameObject.transform.childCount;i++)
        {
            deck.Add(gameObject.transform.GetChild(i).gameObject);
        }  
        Shuffle();
    }
    void Update()
    {
        
    }
    public void Shuffle()
    {
        for(int i=0;i<deck.Count;i++)//acc a cada carta del deck
        {
            GameObject temp;
            temp=deck[i];
            int random=Random.Range(0,deck.Count);//num aleatorio desde 0 hasta las cartas-1
            deck[i]=deck[random];//esta carta sera igual a otra aleatoria
            deck[random]=temp;//y la carta aleatoria sera igual a esta carta
        }
    }
}
