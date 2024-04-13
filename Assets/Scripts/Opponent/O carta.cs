using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ocarta : MonoBehaviour
{
    public int poder;
    public string tipo;
    public string unidad;
    //cuando se activa el senuelo
    public bool Is_Decoy_activate;
    GameObject hand;
    GameObject Ohand;
    GameObject Occ;
    GameObject Od;
    GameObject Oa;
    GameObject cc;
    GameObject d;
    GameObject a;
    GameObject pass_turn;
    GameObject pass_Oturn;
    void Start()
    {
        Is_Decoy_activate=false;
        hand=GameObject.Find("player hand");
        Ohand=GameObject.Find("O hand");
        pass_turn=GameObject.Find("pass turn");
        pass_Oturn=GameObject.Find("pass O turn");
        cc=GameObject.Find("player cc zone");
        d=GameObject.Find("player d zone");
        a=GameObject.Find("player a zone");
        Occ=GameObject.Find("O cc zone");
        Od=GameObject.Find("O d zone");
        Oa=GameObject.Find("O a zone");
    }
    void OnMouseEnter()
    {
        GameObject.Find("lupa de cartas").GetComponent<Image>().sprite=gameObject.GetComponent<Image>().sprite;
    }
    void OnMouseDown()
    {
        if(Is_Decoy_activate)
        {
            for(int i=0;i<hand.transform.childCount;i++)
            {
                if(hand.transform.GetChild(i).GetComponent<carta>().tipo=="s")
                {
                    hand.transform.GetChild(i).SetParent(gameObject.transform.parent);
                    break;
                }
            }
            Destroy(GameObject.FindGameObjectWithTag("block collider"));
            Destroy(GameObject.FindGameObjectWithTag("texto decoy"));
            Disable_decoy_mark(cc);
            Disable_decoy_mark(d);
            Disable_decoy_mark(a);
            Disable_Odecoy_mark(Occ);
            Disable_Odecoy_mark(Od);
            Disable_Odecoy_mark(Oa);
            pass_Oturn.SetActive(true);
            pass_turn.SetActive(true);
            gameObject.transform.SetParent(Ohand.transform);
            if(GameObject.Find("turn controler").GetComponent<turncontroler>().play_Oin_actual_round)
            {
                GameObject.Find("turn controler").GetComponent<turncontroler>().yourturn=false;
            }
        }
        
    }
    void Disable_decoy_mark(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            zone.transform.GetChild(i).gameObject.GetComponent<carta>().Is_Decoy_activate=false;
        }
    }
    void Disable_Odecoy_mark(GameObject zone)
    {
        int count_child=zone.transform.childCount;
        for(int i=0;i<count_child;i++)
        {
            zone.transform.GetChild(i).gameObject.GetComponent<Ocarta>().Is_Decoy_activate=false;
        }
    }
}
