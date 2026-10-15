using UnityEngine;

public class collision_changing_color : MonoBehaviour
{
    private Renderer object_renderer;

    void Start()
    {
        object_renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);
        object_renderer.material.color = Random.ColorHSV();
    }
}
