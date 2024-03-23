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
            GameObject affect_zone=GameObject.Find("player d zone");
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
