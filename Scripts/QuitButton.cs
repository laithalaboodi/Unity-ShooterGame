using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {

        button = GetComponent<Button>();
        button.onClick.AddListener(Quit);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Quit()
    {
        print("Quitting!");
        Application.Quit();
    }
}
