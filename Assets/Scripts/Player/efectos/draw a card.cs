using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawacard : MonoBehaviour
{
    bool effect_activate;
    GameObject hand;
    void Start()
    {
        effect_activate=false; 
        hand=GameObject.Find("player hand"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(effect_activate==false && gameObject.GetComponent<carta>().InBattle)
        {
            hand.GetComponent<handcontroler>().contador+=1;
            effect_activate=true;
        }
        
    }
}
