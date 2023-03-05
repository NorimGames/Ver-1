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
        //��� ������� ���������������
        foreach (ContactPoint contact in collision.contacts)
        {
            //���� �������������� � �������� � ����� Player
            if (collision.gameObject.tag == "Player")
            {
                //������ �����������, � ������� ��������� ������
                hitDir = contact.normal;
                //��������� ������� ������� � ������� ��������������� ������� ���������������
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
