using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestorEjemplo : MonoBehaviour
{
    public ManoManager manoEjemplo;
    public ManoManager topeEjemplo;
    public CartaManager cartaManager;

    public void volver()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Ejemplo1()
    {
        manoEjemplo.AddCarta(cartaManager.cartas[2]);
        manoEjemplo.AddCarta(cartaManager.cartas[10]);
        manoEjemplo.AddCarta(cartaManager.cartas[22]);
        manoEjemplo.AddCarta(cartaManager.cartas[40]);
        manoEjemplo.AddCarta(cartaManager.cartas[35]);

        SceneManager.LoadScene("SimulacionEjemplo");
    }

    public void Ejemplo2()
    {
        manoEjemplo.AddCarta(cartaManager.cartas[8]);
        manoEjemplo.AddCarta(cartaManager.cartas[18]);
        manoEjemplo.AddCarta(cartaManager.cartas[34]);
        manoEjemplo.AddCarta(cartaManager.cartas[46]);
        manoEjemplo.AddCarta(cartaManager.cartas[25]);

        topeEjemplo.AddCarta(cartaManager.cartas[53]);

        SceneManager.LoadScene("SimulacionEjemplo");
    }

    public void Ejemplo3()
    {
        manoEjemplo.AddCarta(cartaManager.cartas[4]);
        manoEjemplo.AddCarta(cartaManager.cartas[15]);
        manoEjemplo.AddCarta(cartaManager.cartas[41]);
        manoEjemplo.AddCarta(cartaManager.cartas[21]);
        manoEjemplo.AddCarta(cartaManager.cartas[12]);

        topeEjemplo.AddCarta(cartaManager.cartas[27]);

        SceneManager.LoadScene("SimulacionEjemplo");
    }
}
