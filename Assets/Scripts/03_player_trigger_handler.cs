using UnityEngine;

public class player_trigger_handler : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    public Color colorEnZona = Color.red;
    public Light luzEscena;

    public int dano = 0;

    private Renderer playerRenderer;
    private Color colorOriginal;

    private Vector3 direccionInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            colorOriginal = playerRenderer.material.color;
        }
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        direccionInput = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
    }

    void FixedUpdate()
    {
        if (direccionInput.magnitude > 0.01f)
        {
            Vector3 nuevaPosicion = rb.position + direccionInput.normalized * speed * Time.fixedDeltaTime;
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
