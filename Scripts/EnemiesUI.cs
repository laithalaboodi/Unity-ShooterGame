using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{

    Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        EnemiesManager.instance.onChanged.AddListener(RefreshText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshText()
    {
        text.text = "Remaining Enemies: " + EnemiesManager.instance.enemies.Count;
    }
}
