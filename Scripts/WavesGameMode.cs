using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
   
    [SerializeField] Life playerLife;
    [SerializeField] Life playerBaseLife;

    

    // Start is called before the first frame update
    void Start()
    {
        
        playerLife.onDeath.AddListener(OnPlayerLifeChanged);
        playerBaseLife.onDeath.AddListener(OnPlayerBaseLifeChanged);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondtion);
        WaveManager.instance.onChanged.AddListener(CheckWinCondtion);

    }


    // Update is called once per frame
    void CheckWinCondtion()
    {
        // I decided that the player to win have to keep defeating enimies till time is over
        //I also have fixed the wave manager so if i want to go back to it i can switch to wave manager.
        if (EnemiesManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count ==0 /*||*/ /*WaveManager.instance.timeRemaining < 0*/)
        {
            print("You win!");
            SceneManager.LoadScene("WonScreen");
        }
       
    }

    void Awake()
    {
        /*
        playerLife.onDeath.AddListener(OnPlayerLifeChanged);
        baseLife.onDeath.AddListener(OnBaseLifeChanged);
        */
    }

    void OnPlayerLifeChanged()
    {
        if (playerLife.amount <= 0)
        {
            print("You lose!");
            SceneManager.LoadScene("LoseScreen");
        }

    }

    void OnPlayerBaseLifeChanged()
    {
        if (playerBaseLife.amount <= 0)
        {
            print("You lose!");
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
