using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public Text NombreCarta;
    public Text DescripcionCarta;
    public Image image;
    public Sprite[] spriteArray;

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Carta Numerica");
        items.Add("Carta Doble");
        items.Add("Carta Reversa");
        items.Add("Carta Saltar");
        items.Add("Carta Cambio de Color");
        items.Add("Carta Cambio de Color + 4");

        foreach(var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;

        NombreCarta.text = dropdown.options[index].text;

        if (index == 0)
        {
            DescripcionCarta.text = "Son Cartas que tienen como valor los numeros del 0 al 9. Todas las cartas se encuentran en pares en el juego excepto el numero 0.";
            image.sprite = spriteArray[0];
        }
        else if (index == 1)
        {
            DescripcionCarta.text = "Cuando se juega esta carta la siguiente persona en jugar deberá levantar 2 cartas del mazo y pierde su turno. Esta carta solo se puede descartar sobre una carta del mismo color o sobre otra carta Doble";
            image.sprite = spriteArray[1];
        }
        else if (index == 2)
        {
            DescripcionCarta.text = "Esta carta cambiará la dirección de la ronda del Juego. Si le tocara jugar al jugador de la izquierda de quien tira la carta, este jugador pierde su turno, en su lugar jugará la persona de la derecha, y el sentido se cambiará hacia la derecha.";
            image.sprite = spriteArray[2];
        }
        else if (index == 3)
        {
            DescripcionCarta.text = "Cuando una persona en la ronda juega esta carta, la siguiente es “Salteada” y pierde su turno.";
            image.sprite = spriteArray[3];
        }
        else if (index == 4)
        {
            DescripcionCarta.text = "Cuando esta se juega esta carta la persona que le haya tirado posee la ventaja de cambiar de color las tiradas de las cartas.";
            image.sprite = spriteArray[4];
        }
        else if (index == 5)
        {
            DescripcionCarta.text = "El jugador que tire esta carta tiene permitido cambiar de color y le otorgara cuatro (4) cartas al jugador que sigue en la ronda y pierda su turno.";
            image.sprite = spriteArray[5];
        }
    }

}
