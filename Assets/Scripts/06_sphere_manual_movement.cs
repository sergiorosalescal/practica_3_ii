using UnityEngine;

public class sphere_manual_movement : MonoBehaviour
{
    public Transform objetivoCilindro;
    public GameObject cuboObstaculo;
    public Material nuevoMaterialCubo;

    public float velocidad = 3f;

    private Collider esferaCollider;
    private Collider cuboCollider;
    private Renderer cuboRenderer;
    private bool materialCambiado = false;

    void Start()
    {
        esferaCollider = GetComponent<Collider>();

        if (cuboObstaculo != null)
        {
            cuboCollider = cuboObstaculo.GetComponent<Collider>();
            cuboRenderer = cuboObstaculo.GetComponent<Renderer>();
        }
    }

    void Update()
    {
        if (objetivoCilindro != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                objetivoCilindro.position, 
                velocidad * Time.deltaTime
            );
        }

        if (!materialCambiado && cuboObstaculo != null)
        {
            bool hayInterseccionBounds = esferaCollider.bounds.Intersects(cuboCollider.bounds);
            float distanciaCoordenadas = Vector3.Distance(transform.position, cuboObstaculo.transform.position);
            bool alcanzaCoordenada = distanciaCoordenadas <= 1.0f; 

            if (hayInterseccionBounds || alcanzaCoordenada)
            {
                if (cuboRenderer != null && nuevoMaterialCubo != null)
                {
                    cuboRenderer.material = nuevoMaterialCubo;
                    materialCambiado = true;
                    Debug.Log("¡Intersección de coordenadas detectada! Se cambia el material del cubo.");
                }
            }
        }
    }
}
