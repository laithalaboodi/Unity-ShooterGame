using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + ScoreManager.instance.amount;
    }

    void Awake()
    {
        text = GetComponent<Text>();
    }
}
