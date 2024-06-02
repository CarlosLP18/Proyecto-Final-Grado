using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CartaManager cartaManager;
    public GameObject[] cartaSlots;

    public int page;
    public Text pageText;

    public Dropdown dropColor;
    public Dropdown dropTipo;

    [SerializeField] private bool isSearch;
    [SerializeField] private int total;
    [SerializeField] private bool SearchColor;
    [SerializeField] private bool SearchTipo;

    [SerializeField] private int indiceColor;
    [SerializeField] private int indiceTipo;
    [SerializeField] private string busquedaColor;
    [SerializeField] private string busquedaTipo;

    void Start()
    {
        DisplayCartas();

        dropColor.onValueChanged.AddListener(delegate
        {
            OnClickColor(dropColor);
        });

        dropTipo.onValueChanged.AddListener(delegate
        {
            OnClickTipo(dropTipo);
        });
    }

    public void DisplayCartas()
    {
        for (int i = 0; i < cartaManager.cartas.Count; i++)
        {
            if (i >= page * 6 && i < (page + 1) * 6)
            {
                cartaSlots[i].gameObject.SetActive(true);
                cartaSlots[i].transform.GetComponent<Image>().sprite = cartaManager.cartas[i].SpriteCarta;
                cartaSlots[i].transform.GetChild(1).GetComponent<Text>().text = cartaManager.cartas[i].IdCarta.ToString();
            }
            else
            {
                cartaSlots[i].gameObject.SetActive(false);
            }
        }
    }

    public void DisplayCartasBusqueda()
    {
        List<CartaData> cartas = new List<CartaData>();
        
        if (SearchColor)
        {
            cartas = ReturnCartaColor(busquedaColor);
        }
        if (SearchTipo)
        {
            cartas = ReturnCartaTipo(busquedaTipo);
        }
        if (SearchTipo && SearchColor)
        {
            cartas = ReturnColorTipo(busquedaColor, busquedaTipo);
        }

        for (int i = 0; i < cartaSlots.Length; i++)
        {
            cartaSlots[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < cartas.Count; i++)
        {
            if (i >= page * 6 && i < (page + 1) * 6)
            {
                cartaSlots[i].gameObject.SetActive(true);
                cartaSlots[i].transform.GetComponent<Image>().sprite = cartas[i].SpriteCarta;
                cartaSlots[i].transform.GetChild(1).GetComponent<Text>().text = cartas[i].IdCarta.ToString();
            }
        }
    }

    void Update()
    {
        UpdatePage();
        TurnPage();

        if (!isSearch)
        {
            total = 0;
        }
    }

    private void UpdatePage()
    {
        if (!isSearch)
        {
            pageText.text = (page + 1) + "/" + (Mathf.Ceil(cartaSlots.Length / 6)).ToString();
        }
        else
        {
            pageText.text = (page + 1) + "/" + (Mathf.Ceil(total / 6) + 1).ToString();
        }
    }

    private void TurnPage()
    {
        if (!isSearch)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (page >= Mathf.Floor((cartaManager.cartas.Count - 1) / 6))
                {
                    page = 0;
                }
                else
                {
                    page++;
                }
                DisplayCartas();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (page <= 0)
                {
                    page = Mathf.FloorToInt((cartaManager.cartas.Count - 1) / 6);
                }
                else
                {
                    page--;
                }
                DisplayCartas();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (page >= Mathf.FloorToInt(total / 6))
                {
                    page = 0;
                }
                else
                {
                    page++;
                }
                DisplayCartasBusqueda();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (page <= 0)
                {
                    page = Mathf.FloorToInt(total / 6);
                }
                else
                {
                    page--;
                }
                DisplayCartasBusqueda();
            }
        }
    }

    public void OnClickColor(Dropdown dropColor)
    {
        busquedaColor = dropColor.options[dropColor.value].text;
        indiceColor = dropColor.value;
    }

    public void OnClickTipo(Dropdown dropTipo)
    {
        busquedaTipo = dropTipo.options[dropTipo.value].text;
        indiceTipo = dropTipo.value;
    }

    public void OnDrop()
    {
        if (indiceColor == 0 && indiceTipo == 0)
        {
            page = 0;
            isSearch = false;
            DisplayCartas();
        }
        else if (indiceColor == 0 && indiceTipo != 0)
        {   
            BuscarTipo(busquedaTipo);
        }
        else if (indiceColor != 0 && indiceTipo == 0)
        {
            BuscarColor(busquedaColor);
        }
        else
        {
            Buscar(busquedaColor, busquedaTipo);
        }
    }

    public void BuscarColor(string color)
    {
        isSearch = true;
        total = 0;
        page = 0;
        busquedaColor = color;
        SearchColor = true;
        SearchTipo = false;

        List<CartaData> ColorCarta = new List<CartaData>();
        ColorCarta = ReturnCartaColor(busquedaColor);
        total = ColorCarta.Count;

        for (int i = 0; i < cartaSlots.Length; i++)
        {
            cartaSlots[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i < ColorCarta.Count; i++)
        {
            if (i >= page * 6 && i < (page + 1) * 6)
            {
                cartaSlots[i].gameObject.SetActive(true);
                cartaSlots[i].transform.GetComponent<Image>().sprite = ColorCarta[i].SpriteCarta;
                cartaSlots[i].transform.GetChild(1).GetComponent<Text>().text = ColorCarta[i].IdCarta.ToString();
            }
        }
    }

    public void BuscarTipo(string tipo)
    {
        isSearch = true;
        total = 0;
        page = 0;
        busquedaTipo = tipo;
        SearchColor = false;
        SearchTipo = true;

        List<CartaData> TipoCarta = new List<CartaData>();
        TipoCarta = ReturnCartaTipo(busquedaTipo);
        total = TipoCarta.Count;

        for (int i = 0; i < cartaSlots.Length; i++)
        {
            cartaSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < TipoCarta.Count; i++)
        {
            if (i >= page * 6 && i < (page + 1) * 6)
            {
                cartaSlots[i].gameObject.SetActive(true);
                cartaSlots[i].transform.GetComponent<Image>().sprite = TipoCarta[i].SpriteCarta;
                cartaSlots[i].transform.GetChild(1).GetComponent<Text>().text = TipoCarta[i].IdCarta.ToString();
            }
        }
    }

    public void Buscar(string color, string tipo)
    {
        isSearch = true;
        total = 0;
        page = 0;
        busquedaColor = color;
        busquedaTipo = tipo;
        SearchColor = true;
        SearchTipo = true;

        List<CartaData> ColorCarta = new List<CartaData>();
        ColorCarta = ReturnColorTipo(busquedaColor, busquedaTipo);
        total = ColorCarta.Count;

        for (int i = 0; i < cartaSlots.Length; i++)
        {
            cartaSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < ColorCarta.Count; i++)
        {
            if (i >= page * 6 && i < (page + 1) * 6)
            {
                cartaSlots[i].gameObject.SetActive(true);
                cartaSlots[i].transform.GetComponent<Image>().sprite = ColorCarta[i].SpriteCarta;
                cartaSlots[i].transform.GetChild(1).GetComponent<Text>().text = ColorCarta[i].IdCarta.ToString();
            }
        }
    }

    public List<CartaData> ReturnCartaColor (string color)
    {
        List<CartaData> CartaColor = new List<CartaData>();

        for (int i = 0; i < cartaManager.cartas.Count; i++)
        {
            CartaData carta;
            if (string.Equals(cartaManager.cartas[i].ColorCarta.ToString(), color))
            {
                carta = cartaManager.cartas[i];
                CartaColor.Add(carta);
            }
        }

        return CartaColor;
    }

    public List<CartaData> ReturnCartaTipo(string tipo)
    {
        List<CartaData> CartaTipo = new List<CartaData>();

        for (int i = 0; i < cartaManager.cartas.Count; i++)
        {
            CartaData carta;
            if (string.Equals(cartaManager.cartas[i].TipoCarta.ToString(), tipo))
            {
                carta = cartaManager.cartas[i];
                CartaTipo.Add(carta);
            }
        }

        return CartaTipo;
    }

    public List<CartaData> ReturnColorTipo(string color, string tipo)
    {
        List<CartaData> ColorTipo = new List<CartaData>();

        for (int i = 0; i < cartaManager.cartas.Count; i++)
        {
            CartaData carta;
            if (string.Equals(cartaManager.cartas[i].ColorCarta.ToString(), color))
            {
                if (string.Equals(cartaManager.cartas[i].TipoCarta.ToString(), tipo))
                {
                    carta = cartaManager.cartas[i];
                    ColorTipo.Add(carta);
                }
            }
        }
        return ColorTipo;
    }
}