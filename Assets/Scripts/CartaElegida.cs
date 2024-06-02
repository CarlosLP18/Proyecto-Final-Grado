using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CartaElegida : MonoBehaviour
{
    public Image carta;
    public CartaManager cartaManager;
    public ManoManager mano;
    public GameObject panel;

    public void cartaElegida(Image carta)
    {
        string temporal = carta.transform.GetChild(1).GetComponent<Text>().text;
        int indice = int.Parse(temporal);
        if (mano.CountMano() < 7)
        {
            bool resultado = duplicados(indice);
            if (!resultado)
            {
                mano.AddCarta(cartaManager.cartas[indice]);
            }
        }
        for (int i=0; i < mano.CountMano(); i++)
        {
            panel.transform.GetChild(i + 1).GetComponent<Text>().text = mano.NombreCarta(i);
        }
    }

    public bool duplicados(int indice)
    {
        bool duplicado = false;
        int contador = 0;
        
        for (int i = 0; i < mano.CountMano(); i++)
        {
            if(indice == mano.indiceCarta(i))
            {
                contador++;
            }
        }

        if (indice == 0 || indice == 13 || indice == 28 || indice == 41)
        {
            if (contador >= 1)
            {
                duplicado = true;
            }
        }
        else if (contador == 2)
        {
            duplicado = true;
        }

        return duplicado;
    }

    public void EscenaSelecionarTope()
    {
        if (mano.CountMano() > 0)
        {
            UnityEditor.EditorUtility.SetDirty(mano);
            SceneManager.LoadScene("ColectorTope");
        }
    }

    public void EscenaMainMenu()
    {
        mano.ClearMano();
        SceneManager.LoadScene("MainMenu");
    }
}