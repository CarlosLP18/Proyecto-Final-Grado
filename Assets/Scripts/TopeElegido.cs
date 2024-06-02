using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopeElegido : MonoBehaviour
{
    public Image carta;
    public CartaManager cartaManager;
    public ManoManager tope;
    public GameObject panel;

    public void cartaTopeElegido(Image carta)
    {
        string temporal = carta.transform.GetChild(1).GetComponent<Text>().text;
        int indice = int.Parse(temporal);
        if (tope.CountMano() < 1)
        {
            tope.AddCarta(cartaManager.cartas[indice]);
        }
        for (int i = 0; i < tope.CountMano(); i++)
        {
            panel.transform.GetChild(i + 1).GetComponent<Text>().text = tope.NombreCarta(i);
        }
    }

    public void siguiente()
    {
        UnityEditor.EditorUtility.SetDirty(tope);
        SceneManager.LoadScene("SimulacionMano");
    }

    public void EscenaAnterior()
    {
        SceneManager.LoadScene("ColectorCartas");
    }
}