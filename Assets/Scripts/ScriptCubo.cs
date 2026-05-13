using UnityEngine;

public class ScriptCubo : MonoBehaviour
{
	public float vidaMaxima = 100f;
	public float vidaActual;

	private MeshRenderer meshRenderer;
	private Material materialGrieta;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
		vidaActual = vidaMaxima;

		meshRenderer = GetComponent<MeshRenderer>();

		// Material 1 = grietas
		materialGrieta = meshRenderer.materials[1];

		ActualizarOpacidad();
	}

	// Update is called once per frame
	void Update()
	{
		float opacidad = vidaMaxima - vidaActual;

		
	}

	void ActualizarOpacidad()
	{
		// valor entre 0 y 1
		float opacidad = 1f - (vidaActual / vidaMaxima);

		

		Color color = materialGrieta.color;

		color.a = opacidad;

		materialGrieta.color = color;
	}

	public void RecibirDanio(float cantidad) // El daño se resta de la vida actual
	{
		vidaActual -= cantidad; // Restar el daño a la vida actual

		ActualizarOpacidad();

		if (vidaActual <= 0)
		{
			vidaActual = 0;
			Destroy(gameObject); // elimina el cubo

		}
		
	}



}
