using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{
    public int qtdeVidaRecuperavel;

    void OnTriggerEnter(Collider objetoColidido) {
        if (objetoColidido.gameObject.tag == "Player" ) {
            GameManager.instancia.AdicionarVida(qtdeVidaRecuperavel);
            gameObject.SetActive(false);
        }
        
    }
}
