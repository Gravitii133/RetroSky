using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    Image barraSaude;

    // Start is called before the first frame update
    void Start()
    {
        barraSaude = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update(){
        //Atualização com o calculo para barra de vida do jogador
        barraSaude.fillAmount = GameManager.instancia.vidaAtual / GameManager.instancia.vidaMaxima;
    }
}
