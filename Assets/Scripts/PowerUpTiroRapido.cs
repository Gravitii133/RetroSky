using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTiroRapido : MonoBehaviour
{
    public float intervaloTiroAumentado;
    float intervaloTiroInicial;
    public float duracaoPowerUp;


    //Foi necessario alterar de void para IEnumerator para que o yield return que provoca atraso 
    //de execução do codigo fosse implementado
    IEnumerator OnTriggerEnter(Collider objetoColidido) {
        if(objetoColidido.gameObject.tag == "Player") {
            //
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;  
            //Recuperando o valor de intervalo de tiro inicial, para retomar depois do tempo
            intervaloTiroInicial = objetoColidido.GetComponent<PlayerController>().intervaloTiro;
            //aumentando a velocidade do intervalo de tiro
            objetoColidido.GetComponent<PlayerController>().intervaloTiro = intervaloTiroAumentado;
            //realizando o atraso na execução do script
            yield return new WaitForSeconds(duracaoPowerUp);
            //retomada do valor inicial do tiro, neste momento o powerup terminou o efeito
            objetoColidido.GetComponent<PlayerController>().intervaloTiro = intervaloTiroInicial;
            Destroy(gameObject);
        }
    }

}
