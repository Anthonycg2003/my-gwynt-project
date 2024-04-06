using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ocarta : MonoBehaviour
{
    public int poder;
    public string tipo;
    public string unidad;
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
    }
}
