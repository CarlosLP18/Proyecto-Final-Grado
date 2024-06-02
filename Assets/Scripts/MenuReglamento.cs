using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReglamento : MonoBehaviour
{
    public void EscenaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EscenaReglamentoCartas()
    {
        SceneManager.LoadScene("ReglamentoCartas");
    }
}
