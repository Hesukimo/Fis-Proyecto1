using UnityEngine;

public class ScriptMuro : MonoBehaviour
{
	public ScriptCubo[] cubos;

    private void Awake()
    {
        cubos = GetComponentsInChildren<ScriptCubo>();
        //float vidamuro = 100 * cubos.Length; // Vida total del muro, por ejemplo, 100 por cada cubo
    }

    // Update is called once per frame
    void Update()
    {
	}

	public int VidaTotal() // Calcula la vida total del muro sumando la cantidad de cubos
	{
		return cubos.Length;
	}

	


	


}
