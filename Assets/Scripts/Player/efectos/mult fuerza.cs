using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multfuerza : MonoBehaviour
{
    GameObject cc;
    GameObject d;
    GameObject a;
    void Start()
    {
        cc=GameObject.Find("player cc zone");
        d=GameObject.Find("player d zone");
        a=GameObject.Find("player a zone");
    }
    void Update()
    {
       if(gameObject.GetComponent<carta>().InBattle)
       {
            Check_tigri_cards_in_field();
       } 
    }
    void Check_tigri_cards_in_field()
            {
                int contador=0;
                int fuerza_temp=2;
                for(int i=0;i<cc.transform.childCount;i++)
                {
                    if(cc.transform.GetChild(i).gameObject.GetComponent<carta>().tigri_mark)
                    {
                        contador+=1;
                    } 
                }
                for(int i=0;i<d.transform.childCount;i++)
                {
                    if(d.transform.GetChild(i).gameObject.GetComponent<carta>().tigri_mark)
                    {
                        contador+=1;
                    } 
                }
                for(int i=0;i<a.transform.childCount;i++)
                {
                    if(a.transform.GetChild(i).gameObject.GetComponent<carta>().tigri_mark)
                    {
                        contador+=1;
                    } 
                }
                fuerza_temp*=contador;
                gameObject.GetComponent<carta>().poder=fuerza_temp;
            }
}
