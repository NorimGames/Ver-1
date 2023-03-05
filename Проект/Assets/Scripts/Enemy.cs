using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int damage; 
    protected int health;
    protected GameObject player;
    bool dead = false; 

    public virtual void Move() 
    {

    }
    public virtual void Attack() 
    {

    }
    public void OnDeath() 
    {
        dead = true;
        GetComponent<Animator>().SetBool("death", true); 
        GetComponent<CharacterController>().enabled = false; 
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update() 
    {
        if (!dead)
        {
            Move();
            Attack();
        }
    }
}
