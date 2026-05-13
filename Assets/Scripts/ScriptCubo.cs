using UnityEngine;

public class ScriptCubo : MonoBehaviour
{
	public float vidaMaxima = 100f;
	public float vidaActual;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		vidaActual = vidaMaxima;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RecibirDanio(float cantidad) // El daño se resta de la vida actual
	{
		vidaActual -= cantidad; // Restar el daño a la vida actual

		if (vidaActual <= 0)
		{
			vidaActual = 0;
			Destroy(gameObject); // elimina el cubo

		}
		
	}
}
