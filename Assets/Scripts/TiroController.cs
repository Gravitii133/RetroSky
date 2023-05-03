using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    //Velocidade deslocamento do tiro
    public int velocidade;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * velocidade;
    }
}
