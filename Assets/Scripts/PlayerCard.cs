using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<SpriteRenderer>().sprite=gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
