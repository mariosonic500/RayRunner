using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject terrain;
    public GameObject player;
    public GameObject obstacleSpawn;
    public GameObject titleScreen;
    public GameObject gameOver;

    public GameObject[] obstacles;

    public Vector3[] obstaclePositions;

    public bool gameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        terrain.GetComponent<Animator>().Play("TerrainRotate");
        player.GetComponent<Animator>().Play("Run");
        titleScreen.SetActive(false);
        gameActive = true;

        InvokeRepeating("SpawnObstacle", 2, 1);
    }
    
    public void EndGame()
    {
        terrain.GetComponent<Animator>().Play("TerrainIdle");
        player.GetComponent<Animator>().Play("Die");
        gameActive = false;
        gameOver.SetActive(true);
    }

    public void SpawnObstacle()
    {
        if (gameActive == true)
        {
            var newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], obstaclePositions[Random.Range(0, 3)], obstacleSpawn.transform.rotation);
            newObstacle.transform.parent = terrain.transform;
        }
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
