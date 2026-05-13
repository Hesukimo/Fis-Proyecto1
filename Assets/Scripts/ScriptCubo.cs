using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ScriptCubo : MonoBehaviour
{
	public float vidaMaxima = 100f;
	public float vidaActual;

	private MeshRenderer meshRenderer;
	private Material materialGrieta;

	private bool roto = false;
	private bool muerto = false;
	private bool posIniciada = false;

	private Vector3 posInicial;
	private float distanciaJoints = 3;
	private float distanciaRomper = 7;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		posInicial = transform.position;
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
		//Bajar vida al caer
		float distancia = Vector3.Distance(transform.position, posInicial);

		//Dañar al alejarse
		if (posIniciada)
		{
			if (distancia > distanciaRomper)
			{
				RecibirDanio(vidaMaxima);
            }
			else if (distancia > distanciaJoints && !roto)
			{
				RecibirDanio(vidaMaxima / 2);
			}
		}


		//Romper joints cuando tengamos menos de la mitad de la vida
		if (vidaActual / vidaMaxima <= 0.5 && !roto)
		{
			roto = true;
			Joint[] joints = GetComponents<Joint>();
			foreach (Joint joint in joints)
			{
				Destroy(joint);
			}
		}

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

		if (vidaActual <= 0 && !muerto)
		{
			vidaActual = 0;
			GameManager.instance.RemoveBlock();
			Destroy(gameObject); // elimina el cubo
			muerto = true;
		}
	}

	IEnumerator IniciarPosicion()
	{
		yield return new WaitForSeconds(2f);
        posInicial = transform.position;
        posIniciada = true;
    }
}
