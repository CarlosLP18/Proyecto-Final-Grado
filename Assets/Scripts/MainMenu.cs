using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EscenaReglamento()
    {
        SceneManager.LoadScene("Reglamento");
    }

    public void EscenaEstablecerMano()
    {
        SceneManager.LoadScene("ColectorCartas");
    }

    public void EscenaEjemplos()
    {
        SceneManager.LoadScene("ListaEjemplos");
    }
}
