using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    [Header("Spraying")]
    public bool useSpraying;
    public float angle = 45f;
    public int bulletPerShot = 5;

    [Header("External")]
    public bool useExternalInput = false;

    private float fireRatePerSeconds;
    private float lastShootTime;

    private float reloadTimer;

    private bool shootInput;
    private bool reloadInput;
    private bool IsReloading;
    private bool HasAmmo => ammo > 0;
    public bool hasHit = false;



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



    void FixedUpdate()
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
            hasHit = false;
        }

        if (IsReloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer > reloadTime)
            {
                if (nowAmmo > 0)
                {
                    nowAmmo = nowAmmo - (maxAmmo - ammo);
                    ammo = maxAmmo;
                    reloadTimer = 0;
                    IsReloading = false;
                    onReloading?.Invoke();
                }
                else if (nowAmmo <= 0)
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
            if (useSpraying) ShootMultiple();
            else ShootSingle();

            hasHit = true;
            lastShootTime = Time.time;

            onShooting?.Invoke();

            if (UseAmmoSystem)
                ammo--;
        }
        else
        hasHit = false;
    }

    private void ShootSingle()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
    }
    private void ShootMultiple()
    {
        for (int i = 0; i < bulletPerShot; i++)
        {
            float spread = Random.Range(-angle, angle);

            Vector2 dir = firePoint.up;

            float angleLook = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angleLook + spread));
            
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, bulletRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(Vector2.up * projectileForce, ForceMode2D.Impulse);
        }
    }

    private void Reload()
    {
        if (nowAmmo > 0)
        {
            IsReloading = true;
        }
    }


#if UNITY_EDITOR //��������� �������� � Dizmos
    private void OnDrawGizmos()
    {
        if (!useSpraying) return;
        Gizmos.color = Color.white;

        Vector3 angle01 = Utils.DirectionFromAngle(-transform.eulerAngles.z + 90, -angle);
        Vector3 angle02 = Utils.DirectionFromAngle(-transform.eulerAngles.z + 90, angle);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * 5f);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * 5f);
    }


#endif

}