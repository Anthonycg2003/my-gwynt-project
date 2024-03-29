using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tormenta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(gameObject.transform.parent==GameObject.Find("weather zone").transform)
        {
            Set_power(GameObject.Find("player d zone"));
            Set_powerO(GameObject.Find("O d zone"));
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
