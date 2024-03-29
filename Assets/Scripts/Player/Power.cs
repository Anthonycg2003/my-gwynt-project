using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Power : MonoBehaviour
{
    public GameObject CC;
    public GameObject D;
    public GameObject A;
    public Text Fuerza_General;
    public Text Fuerza_CC;
    public Text Fuerza_D;
    public Text Fuerza_A;
    public int Fuerza_total;
    void Start()
    {
    }
    void Update()
    { 
        Fuerza_CC.text=Convert.ToString(Get_ChildrenFuerza(CC)); 
        Fuerza_A.text=Convert.ToString(Get_ChildrenFuerza(A));
        Fuerza_D.text=Convert.ToString(Get_ChildrenFuerza(D));
        Fuerza_total=Get_ChildrenFuerza(CC)+Get_ChildrenFuerza(A)+Get_ChildrenFuerza(D);
        Fuerza_General.text=Convert.ToString(Fuerza_total);
    }
    public int Get_ChildrenFuerza(GameObject zone)//funcion para acceder a la fuerza de los hijos de cada zona
    {
        int fuerza_zone=0;
        for(int i=0;i<zone.transform.childCount;i++)
        {
            int fuerza=zone.transform.GetChild(i).GetComponent<carta>().poder;
            fuerza_zone+=fuerza;
        }
        return fuerza_zone;
    }
    
}
