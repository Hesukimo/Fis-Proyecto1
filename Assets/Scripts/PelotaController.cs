using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Transform rotateLocation;

    [SerializeField] private float vo;
    [SerializeField] private float lifespan;
    [SerializeField] private float grav = 9.8f;

    private Vector3 direccion;

    [SerializeField] private GameObject[] pelota;
    private int indicePelota = 0;
    private List<GameObject> pelotas = new List<GameObject>();

    private LineRenderer lr;
    [SerializeField] private int resolution = 30;
    [SerializeField] private float timeStep = 0.1f;

    private float rotacionVertical = 0f;
    private float rotacionHorizontal = 0f;

    public float velocidadRotacion = 50f;

    private Renderer renderizador;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        renderizador = GetComponent<Renderer>();
        renderizador.material = pelota[indicePelota].GetComponent<Renderer>().sharedMaterial;
    }

    void Update()
    {
        // Dirección siempre sigue al cañón
        direccion = transform.forward;

        // Dibujar trayectoria en tiempo real
        DrawLine();

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DispararBola();
        }

        // Movimiento cañón
        rotacionVertical = 0f;
        rotacionHorizontal = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) { rotacionHorizontal = 1; }
        if (Input.GetKey(KeyCode.RightArrow)) { rotacionHorizontal = -1; }

        if (Input.GetKey(KeyCode.UpArrow)) { rotacionVertical = 1; }
        if (Input.GetKey(KeyCode.DownArrow)) { rotacionVertical = -1; }

        transform.RotateAround(rotateLocation.transform.position, new Vector3(0, 1 * rotacionHorizontal, 0), velocidadRotacion * Time.deltaTime);
        transform.Rotate(velocidadRotacion * Time.deltaTime * rotacionVertical, 0, 0);

        // Limpiar nulls
        pelotas.RemoveAll(p => p == null);

        // Actualizar pelotas
        foreach (GameObject pel in pelotas)
        {
            var script = pel.GetComponent<Pelota>();
            UpdatePelotaPosition(script, script.life);
        }
    }

    void DispararBola()
    {
        if (GameManager.instance.ballAmount > 0) {
            //Instanciamos la pelota, le asignamos los valores y lo añadimos a nuestra lista de pelotas
            var part = Instantiate(pelota[indicePelota], spawnLocation.position, Quaternion.identity);
            part.GetComponent<Pelota>().Iniciar(vo, direccion, lifespan, grav);
            pelotas.Add(part);

            GameManager.instance.ballAmount--;
            GameManager.instance.UpdateBulletText();
        }
    }

    void UpdatePelotaPosition(Pelota p, float time)
    {
        // Actualizar posición
        p.transform.position = new Vector3(p.ini.x + p.vel0.x * time, p.ini.y + p.vel0.y * time - (grav * time * time) / 2, p.ini.z + p.vel0.z * time);

        if (p.life > p.lifespan)
        {
            Destroy(p.gameObject);
        }
    }

    void DrawLine()
    {
        lr.positionCount = resolution;

        Vector3 start = spawnLocation.position;
        Vector3 vel = direccion * vo;

        for (int i = 0; i < resolution; i++)
        {
            float t = i * timeStep;
            Vector3 point = new Vector3(start.x + vel.x * t, start.y + vel.y * t - (grav * t * t) / 2, start.z + vel.z * t);
            lr.SetPosition(i, point);
        }
    }

    public void ChangeAmmo()
    {
        //Cambiar entre municiones
        indicePelota++;
        if (indicePelota >= pelota.Length)
        {
            indicePelota = 0;
        }
        renderizador.material = pelota[indicePelota].GetComponent<Renderer>().sharedMaterial;
    }
}