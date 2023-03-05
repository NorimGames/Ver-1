using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    float x = 493.9f;
    float y = 6.05f;
    float z = 522f;
    [SerializeField] string message = "Come in! Come in";
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = 10f;
    [SerializeField] int crystal;
    [SerializeField] Text ScoreText;    
    [SerializeField] Text TimeText;
    [SerializeField] GameObject win;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject particle;
    Vector3 direction;
    float time = 0;

    

    string sos = "Come in, come in!";
    
    void Start()
    {
        print($"{sos}\n{x}\n{y}\n{z}\n{message}");       
        //transform.position = new Vector3(x, y, z);
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (crystal < 5) 
        {
            time += Time.deltaTime;
            TimeText.text = time.ToString();            
        }
        else
        {
            win.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50;
        }
        else speed = 20;

        if(controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
        }
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {            
            crystal += 1;
            Instantiate(particle, other.transform.position, particle.transform.rotation); 
            Destroy(other.gameObject);
            ScoreText.text = crystal.ToString();
            GetComponent<AudioSource>().Play();            
        }
        if (other.tag == "GameOver")
        {
            gameOver.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }    
}
