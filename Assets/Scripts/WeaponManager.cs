using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager wm;
    public GameObject blankWeapon;
    public GameObject[] blades, hilts;

    public void GenerateWeapon(Vector2 pos)
    {
        GameObject weapon = Instantiate(blankWeapon, (Vector3)pos, Quaternion.identity);

        GameObject hilt = Instantiate(hilts[Random.Range(0, hilts.Length)], weapon.transform);
        hilt.transform.localPosition = Vector3.zero;
        GameObject blade = Instantiate(blades[Random.Range(0, blades.Length)], weapon.transform);
        blade.transform.localPosition = Vector3.zero;

        weapon.GetComponent<Weapon>().SetParts(hilt, blade);
    }

    /// <summary>
    /// Overloaded to return a reference to the weapon created
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public GameObject GenerateWeapon()
    {


        GameObject weapon = Instantiate(blankWeapon, this.transform.position, Quaternion.identity);

        GameObject hilt = Instantiate(hilts[Random.Range(0, hilts.Length)], weapon.transform);
        hilt.transform.localPosition = Vector3.zero;
        GameObject blade = Instantiate(blades[Random.Range(0, blades.Length)], weapon.transform);
        blade.transform.localPosition = Vector3.zero;

        weapon.GetComponent<Weapon>().SetParts(hilt, blade);

        return weapon;
    }

    void Awake()
    {
        wm = this;
    }

    private void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            GenerateWeapon(new Vector2(i, 0));
        }
        //GenerateWeapon(new Vector2(0, 0));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
