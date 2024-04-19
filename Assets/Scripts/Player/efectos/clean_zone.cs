using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clean_zone : MonoBehaviour
{
    GameObject Occ;
    GameObject Od;
    GameObject Oa;
    GameObject cc;
    GameObject d;
    GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        cc=GameObject.Find("player cc zone");
        d=GameObject.Find("player d zone");
        a=GameObject.Find("player a zone"); 
        Occ=GameObject.Find("O cc zone");
        Od=GameObject.Find("O d zone");
        Oa=GameObject.Find("O a zone");  
    }

    // Update is called once per frame
    void Update()
    {
        int cards_in_cc=cc.transform.childCount;
        int cards_in_d=d.transform.childCount;
        int cards_in_a=a.transform.childCount;
        int cards_in_Occ=Occ.transform.childCount;
        int cards_in_Od=Od.transform.childCount;
        int cards_in_Oa=Oa.transform.childCount;
        
    }
}
