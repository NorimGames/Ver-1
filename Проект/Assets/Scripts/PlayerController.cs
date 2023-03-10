using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Text HpText;
    int health;
    [SerializeField] GameObject gameOver;
    [SerializeField] Animator gun;
    [SerializeField] GameObject pauseUI;
    bool pause;

    public void ChangeHealth(int count)
    {
        health = health + count;
        if (health >= 0)
        {           
            HpText.text = health.ToString();
        }
        if(health <= 0)
        {
            gameOver.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public int GetHealth()
    {
        return health;
    }
    void Start()
    {       
        if (PlayerPrefs.HasKey("playerX"))
        {
            float x = PlayerPrefs.GetFloat("playerX");
            float y = PlayerPrefs.GetFloat("playerY");
            float z = PlayerPrefs.GetFloat("playerZ");
            //transform.position = new Vector3(x, y, z);
            ChangeHealth(PlayerPrefs.GetInt("health"));
        }
        else
        {
            ChangeHealth(100);
        }
    }
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                pause = false;
                GetComponent<PlayerLook>().enabled = true;
                GetComponent<PlayerMove>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                pauseUI.SetActive(false);
            }
            else
            {
                pause = true;
                GetComponent<PlayerLook>().enabled = false;
                GetComponent<PlayerMove>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                pauseUI.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Health")
        {
            print("health");
            Destroy(collider.gameObject);
            ChangeHealth(50);
        }
    }
}