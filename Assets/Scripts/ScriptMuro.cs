using UnityEngine;

public class ScriptMuro : MonoBehaviour
{
	public ScriptCubo[] cubos;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

		cubos = GetComponentsInChildren<ScriptCubo>();
		float vidamuro = 100 * cubos.Length; // Vida total del muro, por ejemplo, 100 por cada cubo
		
		
	}

    // Update is called once per frame
    void Update()
    {
        VidaTotal();
		Debug.Log("Vida total del muro: " + VidaTotal());
	}

	public float VidaTotal() // Calcula la vida total del muro sumando la vida de cada cubo
	{
		float total = 0f;

		foreach (ScriptCubo cubo in cubos)
		{
			if (cubo != null)
				total += cubo.vidaActual;
		}

		return total;
	}

	


	


}
