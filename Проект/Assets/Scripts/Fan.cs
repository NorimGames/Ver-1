using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] Vector3 windDirection;
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(windDirection, ForceMode.Acceleration);
    }
}
