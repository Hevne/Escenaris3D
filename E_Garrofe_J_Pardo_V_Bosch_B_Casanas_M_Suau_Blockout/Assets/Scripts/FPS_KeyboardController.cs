using UnityEngine;

public class FPS_KeyboardController : MonoBehaviour
{

    [Header("Movement Settings")]
    public Vector3 movementSpeed;
    public float speedLimits;
    Rigidbody rb_body;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb_body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(rb_body.velocity.magnitude <= speedLimits || !isGrounded)
        {
            //Forward movement
            if (Input.GetKey(KeyCode.W))
            {
                rb_body.velocity += transform.forward * movementSpeed.x * Time.deltaTime;
            }

            //Backwards movement
            if (Input.GetKey(KeyCode.S))
            {
                rb_body.velocity += (transform.forward * -1) * movementSpeed.x * Time.deltaTime;
            }

            //Right movement
            if (Input.GetKey(KeyCode.D))
            {
                rb_body.velocity += transform.right * movementSpeed.z * Time.deltaTime;
            }

            //Left movement
            if (Input.GetKey(KeyCode.A))
            {
                rb_body.velocity += (transform.right * -1) * movementSpeed.z * Time.deltaTime;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isGrounded = false;
        }
    }

}
