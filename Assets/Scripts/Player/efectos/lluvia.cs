using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lluvia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // hace la fuerza de las unidades en la zona de artilleria = 0
    void Update()
    {
        if(gameObject.transform.parent==GameObject.Find("weather zone").transform)
        {
            Set_power(GameObject.Find("player a zone"));
            Set_powerO(GameObject.Find("O a zone"));

        }
        
    }
    void Set_power(GameObject affect_zone)
    {
        for(int i=0;i<affect_zone.transform.childCount;i++)
        {
            carta card=affect_zone.transform.GetChild(i).GetComponent<carta>();
            if(card.unidad=="p")
            {
                card.poder=1;
            }
        }
    }
    void Set_powerO(GameObject affect_zone)
    {
        for(int i=0;i<affect_zone.transform.childCount;i++)
        {
            Ocarta card=affect_zone.transform.GetChild(i).GetComponent<Ocarta>();
            if(card.unidad=="p")
            {
                card.poder=1;
            }
        }
    }
}
