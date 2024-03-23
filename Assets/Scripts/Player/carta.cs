using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class carta : MonoBehaviour
{
    //atributos de unidad
    public int poder;
    public string tipo;
    public string unidad;
    
    //definiendo zonas del campo donde pueden ser invocadas
    GameObject cc;
    GameObject d;
    GameObject a;

    //en el menu
    public bool IsSelected;

    
    void Start()
    {
        cc=GameObject.Find("cc zone");
        d=GameObject.Find("d zone");
        a=GameObject.Find("a zone");  
        IsSelected=false;      
    }
    void Update()
    {
        //si esta seleccionada en el menu cambiar el tamano
        if(IsSelected==true)
        {
            gameObject.transform.localScale=new Vector3(2f,2f,1);
        }
        else if(IsSelected==false)
        {
            gameObject.transform.localScale=new Vector3(1,1,1);
 
        }   
    }
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
    }
    void OnMouseDown()
    {
        if(IsSelected==true)
        {
            IsSelected=false;
        }
        else if(IsSelected==false)
        {
            IsSelected=true;
        }

    }
}
