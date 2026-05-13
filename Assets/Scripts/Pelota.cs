using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Pelota : MonoBehaviour
{
    //Otras
    public Vector3 ini;
    public int danio;

    //Variables
    public float vo;
    public Vector3 vel0;
    private float ao;
    public float lifespan;
    public float life = 0f;
    private float grav;

    //Explosión
    public float radioExplosion = 5f;
    public float fuerzaExplosion = 2000f;

    private Rigidbody rb;

    public void Iniciar(float vo, Vector3 direccion, float lifespan, float grav)
    {
        this.ini = transform.position;
        this.vo = vo;

        this.vel0 = direccion.normalized * vo;

        this.lifespan = lifespan;
        this.grav = grav;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            cubo.RecibirDanio(danio); // Inflige daño al cubo
            Explotar();
            StartCoroutine(DestruirDespues());
        }

        if (collision.gameObject.name == ("Suelo"))
        {
            Explotar();
        }

        if (collision.gameObject.name == ("Caballero"))
        {
            Debug.Log("caballero hit");
            GameManager.instance.Finish();
        }
    }

    private void Explotar()
    {
        // Detecta colliders dentro del radio
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider objeto in colliders)
        {
            Rigidbody rbObjeto = objeto.GetComponent<Rigidbody>();
            if (rbObjeto != null)
            {
                rbObjeto.AddExplosionForce(fuerzaExplosion, transform.position, radioExplosion); // Afectamos los cubos en motor de físicas de Unity
                Debug.Log("Golpeado a " + rbObjeto.gameObject.name);
            }
        }
    }

    IEnumerator DestruirDespues()
    {
        yield return new WaitForFixedUpdate();
        Destroy(gameObject);
    }

}
