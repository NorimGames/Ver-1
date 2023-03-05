using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            door.SetTrigger("Open");
        }
    }
}
