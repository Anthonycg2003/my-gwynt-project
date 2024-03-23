using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hornA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.parent==GameObject.Find("player horn a zone").transform)
        {
            GameObject affect_zone=GameObject.Find("player a zone");
            for(int i=0;i<affect_zone.transform.childCount;i++)
            {
                carta card=affect_zone.transform.GetChild(i).GetComponent<carta>();
                if(card.unidad=="p"  && card.poder_temp==false)
                {
                    card.poder*=2;
                    card.poder_temp=true;
                }
            }
        }
        
    }
}
