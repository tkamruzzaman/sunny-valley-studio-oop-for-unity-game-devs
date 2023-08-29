using HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeaponSystem;

public class Player : MonoBehaviour
{
    public float speed = 2;

    public Transform playerShip;

    public ScreenBounds screenBounds;

    [SerializeField] private int initialHealthValue = 3;

    [SerializeField]
    private Transform liveImagesUIParent;
    List<Image> lives = new List<Image>();

    Rigidbody2D rb2d;
    Vector2 movementVector = Vector2.zero;

    //public AudioClip hitClip, deathClip;
    //public AudioSource hitSource;

    //public GameObject explosionFX;

    public bool isAlive = true;

    public InGameMenu loseScreen;
    public Button menuButton;

    [SerializeField]
    private Weapon weapon;

    [SerializeField] private Health health;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        foreach (Transform item in liveImagesUIParent)
        {
            lives.Add(item.GetComponent<Image>());
        }
    }

    private void OnEnable()
    {
        if(health == null)
        {
            health = GetComponent<Health>();
            health.InitializeHealth(initialHealthValue);
        }

        health.OnDeath.AddListener(Death);
        health.OnDeath.AddListener(UpdateUI);

        //health.OnHit.AddListener(GetHitFeedback);
        health.OnHit.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Death);
        health.OnDeath.RemoveListener(UpdateUI);

        //health.OnHit.RemoveListener(GetHitFeedback);
        health.OnHit.RemoveListener(UpdateUI);
    }

    void Update()
    {
        //get input and move
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        movementVector = speed * input;

        if (!isAlive) { return; }

        //shooting
        if (Input.GetKey(KeyCode.Space))
        {
            weapon.PerformAttack();
        }

        //weapon swap
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            weapon.SwapWeapon();
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb2d.position + movementVector * Time.fixedDeltaTime;
        if (screenBounds.AmIOutOfBounds(newPosition) == false)
        {
            rb2d.MovePosition(newPosition);
        }
    }


    public void ReduceLives()
    {
        health.GetHit(1, gameObject);
 
    }

    private void Death()
    {
        isAlive = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        StartCoroutine(DestroyCoroutine());
    }

    private void UpdateUI()
    {
        for (int i = 0; i < lives.Count; i++)
        {
            if (i >= health.CurrentHealth)
            {
                lives[i].color = Color.black;
            }
            else
            {
                lives[i].color = Color.white;
            }
        }
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        loseScreen.Toggle();
        menuButton.interactable = false;
    }
}
