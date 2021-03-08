using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager wm;
    public PlayerMovement pc;
    public GameObject playerWeapon;
    public GameObject blankWeapon;
    public GameObject[] modifiers, effects;
    public GameObject[] swordBlades, swordHilts;
    public GameObject[] hammerHeads, hammerHandles;

    public void GenerateSword(Vector2 pos)
    {
        DestroyWeapon();
        GameObject weapon = playerWeapon;
        GameObject hilt = Instantiate(swordHilts[Random.Range(0, swordHilts.Length)], weapon.transform);
        hilt.name = hilt.name.Replace("(Clone)", "");
        hilt.transform.localPosition = Vector3.zero;
        GameObject blade = Instantiate(swordBlades[Random.Range(0, swordBlades.Length)], weapon.transform);
        blade.name = blade.name.Replace("(Clone)", "");
        blade.transform.localPosition = Vector3.zero;
        GameObject modifier = Instantiate(modifiers[Random.Range(0, modifiers.Length)], weapon.transform);
        modifier.name = modifier.name.Replace("(Clone)", "");
        modifier.transform.localPosition = Vector3.zero;
        GameObject effect = Instantiate(effects[Random.Range(0, effects.Length)], weapon.transform);
        effect.name = effect.name.Replace("(Clone)", "");
        effect.transform.localPosition = Vector3.zero;

        weapon.gameObject.tag = "Sword";
        weapon.transform.localPosition = new Vector3(0, 0.65f, 0);
        weapon.GetComponent<Weapon>().SetParts(hilt, blade, effect, modifier);
    }

    public void GenerateHammer()
    {
        DestroyWeapon();
        GameObject weapon = playerWeapon;
        GameObject handle = Instantiate(hammerHandles[Random.Range(0, hammerHandles.Length)], weapon.transform);
        handle.name = handle.name.Replace("(Clone)", "");
        handle.transform.localPosition = Vector3.zero;
        GameObject head = Instantiate(hammerHeads[Random.Range(0, hammerHeads.Length)], weapon.transform);
        head.name = head.name.Replace("(Clone)", "");
        head.transform.localPosition = Vector3.zero;
        GameObject modifier = Instantiate(modifiers[Random.Range(0, modifiers.Length)], weapon.transform);
        modifier.name = modifier.name.Replace("(Clone)", "");
        modifier.transform.localPosition = Vector3.zero;
        GameObject effect = Instantiate(effects[Random.Range(0, effects.Length)], weapon.transform);
        effect.name = effect.name.Replace("(Clone)", "");
        effect.transform.localPosition = Vector3.zero;

        weapon.gameObject.tag = "Hammer";
        weapon.transform.localPosition = new Vector3(0, 1.9f, 0);
        weapon.GetComponent<Weapon>().SetParts(handle, head, effect, modifier);
    }

    public void GiveWeapon(Weapon targetWeapon)
    {
        //FOR SWORD ONLY
        //TODO: Add more weapon types



        GameObject hilt = Instantiate(swordHilts[Random.Range(0, swordHilts.Length)], targetWeapon.transform);
        hilt.name = hilt.name.Replace("(Clone)", "");
        hilt.transform.localPosition = Vector3.zero;
        GameObject blade = Instantiate(swordBlades[Random.Range(0, swordBlades.Length)], targetWeapon.transform);
        blade.name = blade.name.Replace("(Clone)", "");
        blade.transform.localPosition = Vector3.zero;
        GameObject modifier = Instantiate(modifiers[Random.Range(0, modifiers.Length)], targetWeapon.transform);
        modifier.name = modifier.name.Replace("(Clone)", "");
        modifier.transform.localPosition = Vector3.zero;
        GameObject effect = Instantiate(effects[Random.Range(0, effects.Length)], targetWeapon.transform);
        effect.name = effect.name.Replace("(Clone)", "");
        effect.transform.localPosition = Vector3.zero;



        targetWeapon.gameObject.tag = "Sword";
        targetWeapon.transform.localPosition = new Vector3(0, 0.65f, 0);
        targetWeapon.GetComponent<Weapon>().SetParts(hilt, blade, effect, modifier);





    }

    public void DestroyWeapon()
    {
        foreach (Transform child in playerWeapon.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void Awake()
    {
        pc = GameObject.FindObjectOfType<PlayerMovement>();
        wm = this;
    }

    private void Start()
    {
        ChooseWeaponType();
    }

    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    ChooseWeaponType();
        //}
    }

    public void ChooseWeaponType()
    {
        int randWeapon = Random.Range(0, 2);
        if (randWeapon == 0)
        {
            GenerateSword(new Vector2(0, 0));
        }
        else if (randWeapon == 1)
        {
            GenerateHammer();
        }
    }
}
