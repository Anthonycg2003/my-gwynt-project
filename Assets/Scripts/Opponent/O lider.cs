using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Olider : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
    }
}
