using UnityEngine;
using TMPro;

public class SistemaPuntos : MonoBehaviour
{
    //Añadir empty a la escena y asignarle este script
    
    public int puntos = 0;

    public TextMeshProUGUI textoPuntos;

    void Start()
    {
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;

        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntos.text = "Puntos: " + puntos;
    }
}