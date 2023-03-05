using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void StartGame()
    {
        SceneManager.LoadScene(1); 
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Authors()
    {
        SceneManager.LoadScene(2);
    }
    public void Save()
    {
        Vector3 vector = player.transform.position;
        int health = player.GetComponent<PlayerController>().GetHealth();
        if (health > 0)
        {
            PlayerPrefs.SetFloat("playerX", vector.x);
            PlayerPrefs.SetFloat("playerY", vector.y);
            PlayerPrefs.SetFloat("playerZ", vector.z);
            PlayerPrefs.SetInt("health", health);
            PlayerPrefs.Save();
        }
    }
    public void ResetGame()
    {        
        PlayerPrefs.SetFloat("playerX", 493.9f);
        PlayerPrefs.SetFloat("playerY", 6.05f);
        PlayerPrefs.SetFloat("playerZ", 522f);
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.Save();
    }    
}
