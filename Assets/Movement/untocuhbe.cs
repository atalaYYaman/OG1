using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class untocuhbe : MonoBehaviour
{
    private BoxCollider box;
    Rigidbody rb;
    public bool duvar = false;
    public GameObject oyuncu;
    public GameObject solKutu;

     void Start()
    {
        //Rigidbody Bileþenini tanýmlama ve Deðiþkene Atama
        rb = oyuncu.GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
    }
    private void skill_unTouchable()
    {
        if (duvar)
        {
            solKutu.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            solKutu.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
