using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{

    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        print("Test Start");
    }

    // Update is called once per frame
    void Update()
    {
        print("Speed: "+ speed);
    }
}
