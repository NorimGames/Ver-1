using UnityEngine;

public class FallGuysMove : MonoBehaviour
{
    bool slide;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    Animator anim;
    Rigidbody rb; 
    Vector3 direction;     
    bool isGrounded;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        if(transform.position.y < -10)
        {
            transform.position = startPosition;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }        
        if (direction.magnitude > 0)
        {
            anim.SetBool("Run", true);
        }
        else anim.SetBool("Run", false);
        if (slide)
        {
            rb.AddForce(direction * 0.15f, ForceMode.VelocityChange);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
        }
        if (other.gameObject.CompareTag("Slide"))
        {
            //то 
            slide = true;
        }
        else slide = false;
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
        anim.SetBool("Jump", true); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plate"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("CheckPoint"))
        {
            startPosition = transform.position;
        }
    }
}
