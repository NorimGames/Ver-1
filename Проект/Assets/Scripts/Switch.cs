using UnityEngine;
public class Switch : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;
    int level = 1;
    public enum Weapon { Pistol, Shotgun, Rifle }
    Weapon weapon;
    void Start()
    {
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapon.Shotgun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            default:
                print("");
                break;
        }
    }
    void Update()
    {        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapon.Shotgun);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapon.Rifle);
        }              
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    break;
            }
        }
    }   
    public void LevelUp()
    {
        level += 1;
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapon.Shotgun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            default:
                print("");
                break;
        }
    }   
    public void ChooseWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            case Weapon.Pistol:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }
}
