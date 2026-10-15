using UnityEngine;

public class move_capsule_rigid_body : MonoBehaviour
{
    public float movement_speed = 5f;
    private Rigidbody rb_component;
    private Vector3 movement_direction;

    void Start()
    {
        rb_component = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");

        movement_direction = new Vector3(horizontal_input, 0f, vertical_input);
    }

    void FixedUpdate()
    {
        if (movement_direction.magnitude > 0.01f)
        {
            Vector3 target_position = rb_component.position + movement_direction.normalized * movement_speed * Time.fixedDeltaTime;
            rb_component.MovePosition(target_position);
        }
    }
}
