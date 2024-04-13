using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class coinflip : MonoBehaviour
{
    public Sprite front;
    public Sprite back;
    public float rotation;
    void Update()
    {
        rotation=gameObject.transform.rotation.x;
        if(rotation<=0f)
        {
            gameObject.GetComponent<Image>().sprite=front;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite=back;
        }
    }
}
