using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : Unit
{
    public bool blockRotation = false;
    public bool blockMovement = false;
    public float speed = 8f;
    public float runSpeed = 11.5f;
    [Header("Weapons")]
    public float pickupRadiusRange = 5f;
    public LayerMask gunsLayer;

    private Rigidbody2D rb;
    private WeaponManager weaponManager;
    public int levelToLoad;

    private float currentSpeed;

    void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
        rb = GetComponent<Rigidbody2D>();
        onDeath.AddListener(Death);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (weaponManager.HasWeapon()) { weaponManager.Drop(true); return; }

            RaycastHit2D hit = Physics2D.CircleCast(transform.position, pickupRadiusRange, transform.right, 0f, gunsLayer.value);
            if (hit)
            {
                WeaponDrop drop = hit.transform.gameObject.GetComponent<WeaponDrop>();
                weaponManager.Pickup(drop.id);

                Shooting weapon = weaponManager.weaponSlots[drop.id].weaponHolder.GetComponent<Shooting>();
                /*
                 * Не сувать скріпт Shooting на модель а тільки на сам weaponHolder! 
                 *  Інакше будуть помилки!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                 * 
                 * 
                 * 
                 * 
                 * 
                 */
                if (weapon)
                {
                    weapon.nowAmmo = drop.nowAmmo;
                    weapon.ammo = drop.ammo;
                }

                Destroy(drop.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (!blockRotation)
        {
            var mousePosition = ScreenMouse.instance.GetMousePos();
            float AngleRad = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            rb.rotation = AngleDeg;
        }

        Vector2 input;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

      
        if (!blockMovement)
        {
            rb.MovePosition(rb.position + input.normalized * Time.deltaTime * currentSpeed);
        }

        if (Input.GetButton("Run"))
        {
            currentSpeed = runSpeed;
        }
        else currentSpeed = speed;

    }

    public void Death()
    {
        SceneController.instance.LoadScene(levelToLoad);
    }
}
