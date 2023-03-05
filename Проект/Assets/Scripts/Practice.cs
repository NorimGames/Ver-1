using UnityEngine;
public class Practice : MonoBehaviour
{    
    void Start()
    {
        Greet();
    }
    private void Greet()
    {
        print("Hello, my friend!");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Greet();
        }
    }
}
