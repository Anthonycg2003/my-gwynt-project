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
            GameObject affect_zone=GameObject.Find("player a zone");
            for(int i=0;i<affect_zone.transform.childCount;i++)
            {
                carta card=affect_zone.transform.GetChild(i).GetComponent<carta>();
                if(card.unidad=="p")
                {
                    card.poder=1;
                }
            }
        }
        
    }
}
