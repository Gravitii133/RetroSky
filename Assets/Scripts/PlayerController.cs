using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("Configura��o Inicial do Player")]
    public int vida;
    Vector3 direcao;
    [Header("Configura��o de Material")]
  
    Material materialOriginal;
   
    MeshRenderer meshRenderer;
    public float tempoPiscar;
    public float speed = 5.0f; 

    [Header("Configura��o de Tiro")]
   
    public GameObject tiroPrefab;

    
    public GameObject spawnTiro;

    [Tooltip("Tempo entre um disparo e outro")]
    public float intervaloTiro = 1;
    float tiroInicial, proximoTiro;
    public int tempoDestruicaoTiro = 5;


    void Start () {
        vida = 14;
    }

    // Update is called once per frame
    void Update() {
        Mover();
        Atirar();
    }

    void Mover() {
       float x = Input.GetAxis("Horizontal");
       float y = Input.GetAxis("Vertical");
       Vector3 dir = new Vector3(x, 0, y);
      
       transform.position = transform.position + dir * speed * Time.deltaTime;

    }

    void Atirar() {
        
        tiroInicial = tiroInicial + Time.deltaTime;

        if (Input.GetButton("Fire1") && tiroInicial > proximoTiro) {
            
            proximoTiro = tiroInicial + intervaloTiro;

            GameObject tiro = Instantiate(tiroPrefab, spawnTiro.transform.position, spawnTiro.transform.rotation);

            
            proximoTiro = proximoTiro - tiroInicial;
            tiroInicial = 0.2f;
            Destroy(tiro, tempoDestruicaoTiro);
        }
    }
    private IEnumerator OnCollisionEnter(Collision objetoColidido) {
        if(objetoColidido.transform.tag == "Tiro Enemy" || objetoColidido.transform.tag == "Enemy")  {
            Destroy(objetoColidido.gameObject);
            vida -= 1;
            yield return new WaitForSeconds(tempoPiscar);
            if (vida == 0) {
                Destroy(this.gameObject);
               
            }
        }
    }

}
