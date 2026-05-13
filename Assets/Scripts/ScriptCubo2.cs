using UnityEngine;

public class ScriptCubo2 : MonoBehaviour
{
	public float vidaMaxima = 100f;
	public float vidaActual;
	//public int puntosAlRomper = 10;

    // Referencia al sistema de puntos
    //public SistemaPuntos sistemaPuntos;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		vidaActual = vidaMaxima;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RecibirDanio(float cantidad)
	{
		vidaActual -= cantidad;

		if (vidaActual <= 0)
		{
			vidaActual = 0;
			// Sumar puntos
            //sistemaPuntos.SumarPuntos(puntosAlRomper);

			Destroy(gameObject); // elimina el cubo
		}
	}
}
