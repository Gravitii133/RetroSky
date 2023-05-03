using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void CarregarCena(string nomeDaCena) {
        //Vai carregar a cena
        SceneManager.LoadScene(nomeDaCena);
    }
}
