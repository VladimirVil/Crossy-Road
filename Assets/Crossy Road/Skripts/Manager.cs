using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour {

    //Git test
    public Text coin = null;
    public Text distance = null;
    public Camera camera = null;
    public GameObject guiGameOver = null;
    public LevelGenerator levelGenerator = null;
    public int levelCount = 45;

    private int currentCoins = 0;
    private int currentDistance = 0;
    private bool canPlay = false;

    private static Manager s_Instance;
    public static Manager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(Manager)) as Manager;
            }
            return s_Instance;
        }
    }

    private void Start()
    {

        for (int i=0; i<levelCount; i++)
        {
            //gonna create 45 instances of prefabs on the play field
            levelGenerator.RandomGenerator();
        }
    }

    public void UpdateCoinCount (int value)
    {
        Debug.Log("Player picked up another coin" + value);
        currentCoins += value;
        coin.text = currentCoins.ToString();
    }

    public void UpdateDistanceCount ()
    {
        Debug.Log("Player moved forward for one point");
        currentDistance += 1;
        distance.text = currentDistance.ToString();
        //everytime the player moves forward, we will generat additional piece of level for better coverage, so the player
        //doesn't get to the end of the screen
        levelGenerator.RandomGenerator();
    }

    public bool CanPlay()
    {
        return canPlay;
    }

    public void StartPlay()
    {
        canPlay = true;
    }

    public void GameOver ()
    {
        //camera.GetComponent<CameraShake>().Shake();
        camera.GetComponent<CameraFollow>().enabled = false;

        GuiGameOver();
    }

    void GuiGameOver ()
    {
        Debug.Log("Game Over!");
        guiGameOver.SetActive(true);
    }

    public void PlayAgain ()
    {
        Scene scene = SceneManager.GetActiveScene();  // will return the currentyl active scene 
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
