using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileForce = 20;
    public UnityEvent onShooting;
    [Header("Rates")]
    public float fireRate = 600;
    public bool semiMode = false;
    [Header("Ammo")]
    public bool UseAmmoSystem = false;
    public int ammo;
    public int maxAmmo = 30;
    [Header("Reload")]
    public bool useAutoReload = true;
    public float reloadTime = 2f;
    public UnityEvent onReloading;

    [Header("External")]
    public bool useExternalInput = false;

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
    //Condition
    private bool IsReloading;
    private bool HasAmmo => ammo > 0;

    private float fireRatePerSeconds;
    private float lastShootTime;

    private float reloadTimer;

    private bool shootInput;
    private bool reloadInput;

    private void Start()
    {
        //ammo = maxAmmo;
    }


    void Update()
    {
        fireRatePerSeconds = 1 / (fireRate / 60);

        if (!useExternalInput)
        {
            shootInput = Input.GetButton("Fire1");
            reloadInput = Input.GetKeyDown(KeyCode.R);
        }

        if (shootInput)
        {
            Shoot();
        }
        if (reloadInput)
        {
           Reload();
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
                ammo = maxAmmo;
                reloadTimer = 0;
                IsReloading = false;
                onReloading?.Invoke();
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
            //Dont forget to rotate object
            lastShootTime = Time.time;
            onShooting?.Invoke(); //onShooting += YourFunction;

            if (UseAmmoSystem)
                ammo--;
        }
    }
    private void Reload()
    {
        IsReloading = true;     
    }
}