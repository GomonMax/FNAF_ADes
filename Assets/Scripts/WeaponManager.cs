using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponSlot
{
    public string name = "AK";
    public GameObject weaponHolder;
    public GameObject pickup;
    public float throwImpulse = 500;

    public void SetActive(bool state)
    {
        weaponHolder.SetActive(state);
    }
}

public class WeaponManager : MonoBehaviour
{
    public WeaponSlot[] weaponSlots;

    public int currentSelectedWeaponID; //{get; private set;}

    private void Awake()
    {
        currentSelectedWeaponID = -1;
        Drop(false);
    }

    public void Pickup(int id)
    {
        if (currentSelectedWeaponID != -1) { Drop(); }
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i == id)
            {
                weaponSlots[i].SetActive(true);
                currentSelectedWeaponID = i;
            }
            else
            {
                weaponSlots[i].SetActive(false);
            }
        }
        Debug.Log( " PickUp " + currentSelectedWeaponID );
    }

    public Shooting GetCurrentWeapon()
    {
        if(currentSelectedWeaponID == -1)
        {
            return null;
        }
        return weaponSlots[currentSelectedWeaponID].weaponHolder.GetComponentInChildren<Shooting>();
    } 

    public void Drop(bool dropWithForce = false)
    {
        if (currentSelectedWeaponID == -1) return;

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            weaponSlots[i].SetActive(false);
        }

        GameObject drop = Instantiate(weaponSlots[currentSelectedWeaponID].pickup, transform.position, transform.rotation);

        if (dropWithForce)
        {
            Rigidbody2D body = drop.GetComponent<Rigidbody2D>();
            body.AddForce(transform.right * weaponSlots[currentSelectedWeaponID].throwImpulse * body.mass, ForceMode2D.Impulse);
            body.angularVelocity = 210;
            currentSelectedWeaponID = -1;
        }
        Debug.Log(" Drop " + currentSelectedWeaponID);
    }
    public bool HasWeapon()
    {
        if(currentSelectedWeaponID == -1)
        {
            return false;
        }
        Debug.Log(" HasWeapon " + currentSelectedWeaponID);
        return true;  
    }
}
