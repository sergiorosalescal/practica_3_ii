using UnityEngine;

public class launch_on_key_x : MonoBehaviour
{
    public Vector3 direccion_fuerza = new Vector3(0f, 3f, 8f); 
    public float intensidad_fuerza = 8f;
    public ForceMode modo_fuerza = ForceMode.Impulse;

    private Rigidbody rb;
    private bool debe_lanzar = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            debe_lanzar = true;
        }
    }

    void FixedUpdate()
    {
        if (debe_lanzar)
        {
            rb.AddForce(direccion_fuerza.normalized * intensidad_fuerza, modo_fuerza);
            debe_lanzar = false;
        }
    }
}
