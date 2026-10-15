using UnityEngine;

public class enemy_contact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("El enemigo ha colisionado físicamente con: " + collision.gameObject.name);
    }
}
