using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCard : MonoBehaviour
{
    //atributos de unidad
    public int poder;
    public string tipo;
    public string unidad;
    
    //definiendo zonas del campo donde pueden ser invocadas
    GameObject cc;
    GameObject d;
    GameObject a;

    
    void Start()
    {
        cc=GameObject.Find("cc zone");
        d=GameObject.Find("d zone");
        a=GameObject.Find("a zone");        
    }
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<SpriteRenderer>().sprite=gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
