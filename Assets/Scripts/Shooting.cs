using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// [System.Serializable]
// public class Weapon
// {
//     public string name = "AK";
//     public GameObject weaponPickUp;
//     public void SetActive(bool state)
//     {
//         weaponPickUp.SetActive(state);
//     }
// }
public class Shooting : MonoBehaviour
{


    public Transform firePoint;
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileForce = 20;
    public UnityEvent onShooting;
    public WeaponManager WM;

    [Header("Rates")]
    public float fireRate = 600;
    public bool semiMode = false;

    [Header("Ammo")]
    public bool UseAmmoSystem = false;
    public int ammo;
    public int maxAmmo = 30;
    public int nowAmmo = 30;

    [Header("Reload")]
    public bool useAutoReload = true;
    public float reloadTime = 2f;
    public UnityEvent onReloading;

    [Header("External")]
    public bool useExternalInput = false;

    private float fireRatePerSeconds;
    private float lastShootTime;

    private float reloadTimer;

    private bool shootInput;
    private bool reloadInput;
    private bool IsReloading;
    private bool HasAmmo => ammo > 0;



    public bool SetShootInput
    {
        get => shootInput;
        set => shootInput = value;
    }
    public bool SetReloadInput
    {
        get => reloadInput;
        set => reloadInput = value;
    }



    void Update()
    {
        fireRatePerSeconds = 1 / (fireRate / 60);

        if (!useExternalInput)
        {
            shootInput = Input.GetButton("Fire1");
            //reloadInput = Input.GetKeyDown(KeyCode.R);
        }
        
        if (shootInput)
        {
            Shoot();
        }
        if (useAutoReload && !HasAmmo)
        {
            Reload();
        }

        if (IsReloading)
        {
            reloadTimer += Time.deltaTime;
            if(reloadTimer > reloadTime)
            {
               if(nowAmmo > 0)
               {
                   nowAmmo = nowAmmo - (maxAmmo - ammo);
                   ammo = maxAmmo;
                   reloadTimer = 0;
                   IsReloading = false;
                   onReloading?.Invoke();
               }
               else if(nowAmmo <= 0)
               {
                   ammo = ammo;
               }
            }
        }
    }   
    public void Shoot()
    {
        if (IsReloading) return;
        if (!HasAmmo) return;


        if (Time.time > fireRatePerSeconds + lastShootTime)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
            lastShootTime = Time.time;
            onShooting?.Invoke();
            if (UseAmmoSystem)
                ammo--;
        }
    }
    private void Reload()
    {
        if(nowAmmo > 0)
        {
            IsReloading = true;  
        }  
    }
    
}