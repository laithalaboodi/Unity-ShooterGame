using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //so i can use the instance in anoter class
    public static PlayerShooting instance;

    public GameObject prefab;
    public GameObject shootPoint;
    public int bulletsAmount;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    Animator animator;

    float lastShootTime;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && bulletsAmount > 0 && Time.timeScale > 0)
        {

            animator.SetBool("Shooting", true);

            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < fireRate)
                return;
            lastShootTime = Time.time;

            //each time we shoot we lower the amount of bullets
            bulletsAmount--;
         
            muzzleEffect.Play();
            shootSound.Play();

            //here we spawning the bullet from player location and rotation
            Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);

        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }

    //when going over the trigger box of ammor we get ammo
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            bulletsAmount = bulletsAmount + 10;
            Destroy(other.gameObject);
        }
    }

}
