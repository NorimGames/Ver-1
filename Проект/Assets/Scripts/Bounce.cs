using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float force = 100f;
    private Vector3 hitDir;
    // Stavrt is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //для каждого соприкосновения
        foreach (ContactPoint contact in collision.contacts)
        {
            //Если соприкоснулись с объектом с тэгом Player
            if (collision.gameObject.tag == "Player")
            {
                //задаем направление, в котором оттолкнем объект
                hitDir = contact.normal;
                //добавляем импульс объекту в сторону противоположную стороне соприкосновения
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
                return;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
