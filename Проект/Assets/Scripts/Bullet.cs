using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20;
    int damage = 20;
    Vector3 direction;
    public void MakeSniper()
    {
        speed = 50;
        damage = 50;
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().OnDeath();
            FindObjectOfType<Switch>().LevelUp();
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}