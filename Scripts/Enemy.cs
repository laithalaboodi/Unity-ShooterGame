using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject ammoPrefab;
    public GameObject healthPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesManager.instance.AddEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //when Enemy die we spawn ammo
    void OnDestroy()
    {
        EnemiesManager.instance.RemoveEnemy(this);
        //here we have enemy dropping something so far health/ammo
        var number = Random.Range(0, 3);
        print(number);
        if (number == 0)
        {
            SpawnAmmo();
        }
        if (number == 1)
        {
            SpawnHealth();
        }

    }

    void SpawnAmmo()
    {
        Instantiate(ammoPrefab, transform.position, transform.rotation);
    }

    void SpawnHealth()
    {
        Instantiate(healthPrefab, transform.position, transform.rotation);
    }
}
