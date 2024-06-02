using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mano", menuName = "Mano", order = 52)]
public class ManoManager : ScriptableObject
{
    [SerializeField]
    public List<CartaData> ManoCarta = new List<CartaData>();
    
    public void AddCarta(CartaData carta)
    {
        ManoCarta.Add(carta);
    }

    public void ClearMano()
    {
        ManoCarta.Clear();
    }

    public int CountMano()
    {
        return ManoCarta.Count;
    }

    public int indiceCarta(int i)
    {
        return ManoCarta[i].IdCarta;
    }

    public string NombreCarta(int i)
    {
        return ManoCarta[i].NombreCarta;
    }

    public Sprite SpriteManoCarta(int i)
    {
        return ManoCarta[i].SpriteCarta;
    }

    public string TipoCarta(int i)
    {
        return ManoCarta[i].TipoCarta.ToString();
    }

    public string ValorCarta(int i)
    {
        return ManoCarta[i].ValorCarta;
    }

    public string colorCarta(int i)
    {
        return ManoCarta[i].ColorCarta.ToString();
    }

    public int pesoCarta(int i)
    {
        return ManoCarta[i].PesoCarta;
    }

    public string DescripcionCarta(int i)
    {
        string descripcion = ManoCarta[i].ValorCarta + "  " + ManoCarta[i].ColorCarta.ToString();
        return descripcion;
    }
}
