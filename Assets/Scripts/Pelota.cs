using UnityEngine;

public class Pelota : MonoBehaviour
{
    //Otras
    public Vector3 ini;

    //Variables
    public float vo;
    public Vector3 vel0;
    private float ao;
    public float lifespan;
    public float life = 0f;
    private float grav;

    

	
	public void Iniciar(float vo, Vector3 direccion, float lifespan, float grav)
    {
        this.ini = transform.position;
        this.vo = vo;

        this.vel0 = direccion.normalized * vo;

        this.lifespan = lifespan;
        this.grav = grav;
    }

    private void Update()
    {
        life += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
		// Si colisiona con un muro, inflige daño

		ScriptCubo cubo = collision.gameObject.GetComponent<ScriptCubo>(); // Intenta obtener el componente ScriptCubo del objeto con el que colisionó


		if (collision.gameObject.name.StartsWith("Cube"))
        {
            cubo.RecibirDanio(10); // Inflige daño al cubo (deberías definir cuánto daño inflige)
			Destroy(gameObject); // Destruye la pelota al impactar
        }
	}
}
