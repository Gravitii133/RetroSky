using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class InimigoController : MonoBehaviour
{
    [Header("Configura��o Inicial do Inimigo")]
    // Iniciando a variavel com o valor de 3
    // Na medida que o inimigo for tomando dano, esse valor vai ser decrementado
    public int vida = 3;
    public Text valorPontos;
    
    [Header("Configura��o de Material")]
    //Material que ser� alterado quando o inimigo receber dano
    public Material materialDano;
    //Variavel auxiliar responsavel por guardar o material inicial do inimigo
    Material materialOriginal;
    // Componente responsavel por aplicar o material no objeto Inimigo
    MeshRenderer meshRenderer;
    //Tempo do intervalo da troca de material quando o inimigo sofrer dano
    public float tempoPiscar;


    [Header("Configura��o de Disparo do Inimigo")]
    public GameObject prefabTiroInimigo;
    public float tempoTiroInimigo;
    public Transform spawnTiroInimigo;
    public bool ativarTiro;

    private void Start() {
        //Realizando a associa��o da variavel meshRenderer do script com o componente MeshRenderer do objeto
        meshRenderer = GetComponent<MeshRenderer>();
        //Armazenando o valor original do material do objeto, na variavel materialOriginal
        materialOriginal = meshRenderer.material;
        //Controlador auxiliar para ativar tiro
        if (ativarTiro) {
            //Invocando a fun��o de atirar, depois de 2 segundos, e repetindo a cada 0.5 segundos
            InvokeRepeating("Atirar", 2, 1.3f);
        }
    }

    private void Update() {
    }

    //Foi necessario trocar o void por IEnumerator para utilizar a fun��o de
    //yield return (fun��o que pausa o codigo durante um tempo pre determinado)
    private IEnumerator OnCollisionEnter(Collision objetoColidido) {
        if(objetoColidido.transform.tag == "TiroPlayer" || objetoColidido.transform.tag == "Player") {
            //Destroy(objetoColidido.gameObject);
            //gameObject.SetActive(false);
            vida -= 1;
            // Trocando o material do inimigo quando sofre dano pelo material de dano
            meshRenderer.material = materialDano;
            // Aguardar 1 segundo antes de voltar o material inicial
            yield return new WaitForSeconds(tempoPiscar);
            // Reatribuindo o material do inimigo, para o material inicial que estava antes
            meshRenderer.material = materialOriginal;

            if (vida == 0) {
                int auxPontos = int.Parse(valorPontos.text);
                auxPontos = auxPontos + 200;
                valorPontos.text = auxPontos.ToString();
                //Destruindo o inimigo
                Destroy(this.gameObject);
            }
        }
    }

    void Atirar() {
        var cloneTiro = Instantiate(prefabTiroInimigo, spawnTiroInimigo.transform.position, spawnTiroInimigo.transform.rotation);
        Destroy(cloneTiro, tempoTiroInimigo);
    }
}
    