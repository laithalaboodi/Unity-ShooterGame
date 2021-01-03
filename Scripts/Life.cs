using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    //ammount is the health or life
    public float amount;
    public UnityEvent onDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(amount < 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }

    //when going over the trigger box of Healtth we get health back
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Health")
        {
            if (amount >= 100)
            {
                print("Health is Full");
                
            }
            else if(amount >= 90)
            {
                amount = 100;
                print("ADDED FULL HP");
                Destroy(other.gameObject);
            }
            else if (amount < 90)
            {
                amount = amount + 10;
                print("added +10HP");
                Destroy(other.gameObject);
            }

        }
    }
}
