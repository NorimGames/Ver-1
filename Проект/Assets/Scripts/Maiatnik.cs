using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maiatnik : MonoBehaviour
{
    [SerializeField] float limit = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Угол будет изменяться по синусоиде
        float angle = limit * Mathf.Sin(Time.time);
        //Изменяем угол нашего маятника   
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
