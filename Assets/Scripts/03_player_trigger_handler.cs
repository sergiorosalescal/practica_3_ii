using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    public Color colorEnZona = Color.red;
    public Light luzEscena;

    public int dano = 0;

    private Renderer playerRenderer;
    private Color colorOriginal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            colorOriginal = playerRenderer.material.color;
        }
    }

    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        if (direccion.magnitude > 0.01f)
        {
            Vector3 nuevaPosicion = rb.position + direccion.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(nuevaPosicion);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaColor"))
        {
            if (playerRenderer != null)
            {
                playerRenderer.material.color = colorEnZona;
            }

            if (luzEscena != null)
            {
                luzEscena.enabled = !luzEscena.enabled; 
            }
        }
        else if (other.CompareTag("ZonaDano"))
        {
            dano += 10;
            Debug.Log("¡Daño recibido! Daño actual: " + dano);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaColor"))
        {
            if (playerRenderer != null)
            {
                playerRenderer.material.color = colorOriginal;
            }

            if (luzEscena != null)
            {
                luzEscena.enabled = !luzEscena.enabled; 
            }
        }
    }
}