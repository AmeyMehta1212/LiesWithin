using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform orientation;

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent tipping over
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * z + orientation.right * x;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
