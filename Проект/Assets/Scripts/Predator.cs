using UnityEngine;

public class Predator : Enemy
{    
    public override void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 100) //100 - радиус обнаружения
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
        }
    }
    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3) //3 - радиус атаки
        {
            player.GetComponent<PlayerController>().ChangeHealth(-100);
        }
    }
}
