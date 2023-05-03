using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Parametros Iniciais do Jogador")]
    public float vidaAtual;
    public float vidaMaxima;

    public static GameManager instancia;

    public Transform gameOver;

    public Text UIPontos;
    int auxPontuacao;

    public GameObject waveAnim;
    bool waveAcionada = false;
    //int contWave = 1;

    void Awake() {
        if(instancia == null) {
            instancia = this;
        }
    }

    void Start() {
        //A vida inicial que o jogador vai começar, será a vida maxima permitida
        vidaAtual = vidaMaxima;
        //waveAnim = GetComponent<Animator>();
    }

    void Update() {
        //So vai limpar se apertar tecla T
        LimparSave();
        AtualizarHUD();
        VerificarInimigos();
    }

    public void RecarregarLevel() {
        //Recarrega a cena ativa com o nome da cena recuperado atraves da função GetActiveScene()
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RemoverVida(int dano) {
        vidaAtual = vidaAtual - dano;
        if(vidaAtual <= 0) {
            GameOver();
        }
    }

    public void AdicionarVida(int quantidade) {
        //Verificando se a quantidade de vida recuperada é superior 
        //a vidaMaxima permitida, se for, vidaAtual vai receber
        //a vidaMaxima, para que jogador não tenha uma quantidade de vida
        //superior a permitida
        if (vidaAtual + quantidade >= vidaMaxima) {
            vidaAtual = vidaMaxima;
        //senão a vidaAtual recebe vidaAtual + a quantidade passada por 
        //por parametro 
        } else {
            vidaAtual = vidaAtual + quantidade;
        }
    }

    public void GameOver() {
        //Verificando se o inimigo perdeu todas as vidas
        gameObject.SetActive(false);

        // Parando o tempo quando o jogador é derrotado
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
        Debug.Log("Game Over");
    }

    public void adicionarPontos(int pontos) {
        // Verificando se existe uma chave na preferencia do jogador chamada pontuação
        if (PlayerPrefs.HasKey("pontuacao")) {
            //se a chave pontuação existir, pontuação vai receber o valor que esta
            //dentro da pontuação + pontos passado pelo parametro
            auxPontuacao = PlayerPrefs.GetInt("pontuacao") + pontos;
            // Realizando o armazenamento da pontuação somada e guardando na preferencia 
            // do jogador
            PlayerPrefs.SetInt("pontuacao", auxPontuacao);
        } else { // caso não exista nenhuma chave com o nome pontuação
            // Realizando o armazenamento dos pontos iniciais na chave pontuacao
            PlayerPrefs.SetInt("pontuacao", pontos);
        }

        // Exibindo a pontuação salva na interface do usuario
        UIPontos.text = PlayerPrefs.GetInt("pontuacao").ToString();
    }

    void AtualizarHUD() {
        //Verificando se a pontuação existe, para que seja atualizado logo no inicio
        if (PlayerPrefs.HasKey("pontuacao")) {
            UIPontos.text = PlayerPrefs.GetInt("pontuacao").ToString();
        } else {
            UIPontos.text = "0";
        }

    }

    void LimparSave() {
        if (Input.GetKeyDown(KeyCode.T)) {
            PlayerPrefs.DeleteKey("pontuacao");
        }
    }

    void VerificarInimigos() {
        if(GameObject.FindGameObjectsWithTag("Inimigo").Length == 0 && !waveAcionada) {
            Debug.Log("Inimigos Destruidos");
            waveAnim.GetComponent<Animator>().SetTrigger("Acionar");
            waveAcionada = true;
        }
    }
}
