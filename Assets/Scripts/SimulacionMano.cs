using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimulacionMano : MonoBehaviour
{
    public CartaManager cartaManager;
    public GameObject[] cartaSlots;
    public GameObject cartaSlotsTope;
    public ManoManager mano;
    public ManoManager tope;
    public Text TextColor;
    public Text TextResultado;
    public Button btnResultado;

    void Start()
    {
        DisplayCartas();
        DisplayTope();
    }

    public void DisplayCartas()
    {
        for (int i = 0; i < cartaSlots.Length; i++)
        {
            if (i < mano.CountMano())
            {
                cartaSlots[i].gameObject.SetActive(true);
                cartaSlots[i].transform.GetComponent<Image>().sprite = mano.SpriteManoCarta(i);
            }
            else
            {
                cartaSlots[i].gameObject.SetActive(false);
            }
        }
    }

    public void DisplayTope()
    {
        if (tope.CountMano() == 1)
        {
            cartaSlotsTope.gameObject.SetActive(true);
            cartaSlotsTope.transform.GetComponent<Image>().sprite = tope.SpriteManoCarta(0);
        }
        else
        {
            cartaSlotsTope.gameObject.SetActive(false);
        }
    }

    public void volver()
    {
        mano.ClearMano();
        tope.ClearMano();
        SceneManager.LoadScene("ColectorCartas");
    }

    public void volverEjemplo()
    {
        mano.ClearMano();
        tope.ClearMano();
        SceneManager.LoadScene("ListaEjemplos");
    }

    public string CambioColor()
    {
        System.Random rnd = new System.Random();
        var Listacolor = new List<string> {"Amarillo", "Azul", "Rojo", "Verde"};
        int index = rnd.Next(Listacolor.Count);
        string valorColor = Listacolor[index];
        return valorColor;
    }

    public bool duplicados(int indice)
    {
        bool duplicado = false;
        int contador = 0;

        for (int i = 0; i < mano.CountMano(); i++)
        {
            if (indice == mano.indiceCarta(i))
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

    public void AddCarta(int add)
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i< add; i++)
        {
            Debug.Log(cartaManager.cartas.Count);
            int indice = rnd.Next(cartaManager.cartas.Count);
            bool resultado = duplicados(indice);
            if (!resultado)
            {
                mano.AddCarta(cartaManager.cartas[indice]);
            }
        }
    }

    public void Simulacion()
    {
        revisarTope();
        btnResultado.interactable = false;
    }

    public void revisarTope()
    {
        string resultado;
        string resultado_add;
        if (tope.CountMano() == 1)
        {
            string colorTope;
            if (string.Equals(tope.TipoCarta(0), "Especial"))
            {
                string color;
                switch (tope.ValorCarta(0))
                {
                    case "Saltar":
                        TextResultado.text = "Por efecto de la Carta Saltar, no puedes jugar este turno";
                        break;
                    case "Revertir":
                        TextResultado.text = "Por efecto de la Revertir, se cambio el orden de juego, no puedes jugar este turno";
                        break;
                    case "Cambio":
                        color = CambioColor();
                        TextColor.text = "El color a jugar es: " + color;
                        resultado = getCartaColor(color);
                        if (Equals(resultado, ""))
                        {
                            AddCarta(1);
                            DisplayCartas();
                            resultado_add = getCartaColor(color);
                            if (Equals(resultado_add, ""))
                            {
                                TextResultado.text = "No hay Jugadas disponible este turno";
                            }
                            else
                            {
                                TextResultado.text = "El resultado es: " + resultado_add;
                            }
                        }
                        else
                        {
                            TextResultado.text = "El resultado es: " + resultado;
                        }
                        break;
                    case "Mas 2":
                        AddCarta(2);
                        DisplayCartas();
                        TextResultado.text = "Por efecto de la Carta Mas 2, se añadio dos cartas y se pierde el turno";
                        break;
                    case "Cambio Color + 4":
                        color = CambioColor();
                        AddCarta(4);
                        DisplayCartas();
                        TextColor.text = "El color a jugar es: " + color;
                        TextResultado.text = "Por efecto de la Carta Cambio Color + 4, se añadio cuatro cartas y se pierde el turno";
                        break;
                }
            }
            else
            {
                colorTope = tope.colorCarta(0);
                string valorCarta = tope.ValorCarta(0);
                resultado = getCartaColorNumero(colorTope, valorCarta);
                if (Equals(resultado, ""))
                {
                    AddCarta(1);
                    DisplayCartas();
                    resultado_add = getCartaColorNumero(colorTope, valorCarta);
                    if (Equals(resultado_add, ""))
                    {
                        TextResultado.text = "No hay Jugadas disponible este turno";
                    }
                    else
                    {
                        TextResultado.text = "El resultado es: " + resultado_add;
                    }
                }
                else
                {
                    TextResultado.text = "El resultado es: " + resultado;
                }
            }
        }
        //Elegir la carta de mayor valor
        else
        {
            resultado = getcartamano();
            TextResultado.text = "El resultado es: " + resultado + ", y no hay cartas en el tope";
        }
    }

    public string getcartamano()
    {
        string respuesta = "";
        int aux = 0;
        for (int i = 0; i < mano.CountMano(); i++)
        {
            if (mano.pesoCarta(i) > aux)
            {
                aux = mano.pesoCarta(i);
                respuesta = mano.DescripcionCarta(i);
            }
        }
        return respuesta;
    }

    public string getCartaColor(string color)
    {
        string respuesta = "";
        int aux = 0;
        for (int i = 0; i < mano.CountMano(); i++)
        {
            if(Equals(mano.colorCarta(i), color) || Equals(mano.colorCarta(i), "Negro"))
            {
                if (mano.pesoCarta(i) > aux)
                {
                    aux = mano.pesoCarta(i);
                    respuesta = mano.DescripcionCarta(i);
                }
            }
        }
        return respuesta;
    }

    public string getCartaColorNumero(string color, string valor)
    {
        string respuesta = "";
        int aux = 0;
        for (int i = 0; i < mano.CountMano(); i++)
        {
            if (Equals(mano.colorCarta(i), color) || Equals(mano.colorCarta(i), "Negro") || Equals(mano.ValorCarta(i), valor))
            {
                if (mano.pesoCarta(i) > aux)
                {
                    aux = mano.pesoCarta(i);
                    respuesta = mano.DescripcionCarta(i);
                }
            }
        }
        return respuesta;
    }
}
