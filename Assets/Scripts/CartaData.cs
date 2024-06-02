using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colorCarta
{
    Amarillo,
    Azul,
    Negro,
    Rojo,
    Verde
}

public enum tipoCarta
{
    Numerico,
    Especial
}

[CreateAssetMenu(fileName ="New CartaData", menuName ="Datos Carta", order =51)]
public class CartaData : ScriptableObject
{
    [SerializeField]
    public int idCarta;
    [SerializeField]
    public string nombreCarta;
    [SerializeField]
    public Sprite spriteCarta;
    [SerializeField]
    public colorCarta colorCarta;
    [SerializeField]
    public tipoCarta tipoCarta;
    [SerializeField]
    public string valor;
    [SerializeField]
    public int peso;

    public int IdCarta
    {
        get
        {
            return idCarta;
        }
    }

    public string NombreCarta
    {
        get
        {
            return nombreCarta;
        }
    }

    public Sprite SpriteCarta
    {
        get
        {
            return spriteCarta;
        }
    }

    public colorCarta ColorCarta
    {
        get
        {
            return colorCarta;
        }
    }

    public tipoCarta TipoCarta
    {
        get
        {
            return tipoCarta;
        }
    }

    public string ValorCarta
    {
        get
        {
            return valor;
        }
    }

    public int PesoCarta
    {
        get
        {
            return peso;
        }
    }
}
