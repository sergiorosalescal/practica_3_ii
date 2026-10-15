using UnityEngine;

public class collectible_trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Recolectable detectado por: " + other.gameObject.name);
    }
}
