using UnityEngine;

public class ScriptMuro : MonoBehaviour
{
	public ScriptCubo[] cubos;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		cubos = GetComponentsInChildren<ScriptCubo>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public float VidaTotal()
	{
		float total = 0f;

		foreach (ScriptCubo cubo in cubos)
		{
			if (cubo != null)
				total += cubo.vidaActual;
		}

		return total;
	}

	public void RecibirDanio(float cantidad)
	{
		if (cubos.Length == 0) return;

		float danioPorCubo = cantidad / cubos.Length;

		foreach (ScriptCubo cubo in cubos)
		{
			if (cubo != null)
				cubo.RecibirDanio(danioPorCubo);
		}
	}


}
