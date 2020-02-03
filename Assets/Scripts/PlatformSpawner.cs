using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<GameObject> platforms;
    public int spawnAmount = 6;
    public float spawnDistance = -60f, spawnDistanceAdditional = -64.2f;
    public float maxY = 0.9926329f;
    public GameObject lastPlatform;
    private GameManager gameManager;
    private Vector3 nextLevelStart;
    GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SpawnPlatforms();
    }

    // Update is called once per frame
    private void Update()
    {

    }
    private void SpawnPlatforms()
    {
        spawnAmount = gameManager.GetCurrentSpawnable();
        Debug.LogError("SpawnAmount: " + spawnAmount);
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(platforms[Random.Range(0, platforms.Count)], transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x + spawnDistance, maxY, 0);
        }
        Instantiate(lastPlatform, new Vector3(transform.position.x, maxY, 0), Quaternion.identity);
        SpawnAdditionalPlatform();
    }
    public void SpawnPlatforms(int amount)
    {
        Debug.LogError("SpawnAmount New Level: " + amount);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(platforms[Random.Range(0, platforms.Count)], transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x + spawnDistance, maxY, 0);
        }
        Instantiate(lastPlatform, new Vector3(transform.position.x, maxY, 0), Quaternion.identity);
        SpawnAdditionalPlatform();
    }
    private void SpawnAdditionalPlatform()
    {
        spawnAmount = (int)(gameManager.GetNextLevelSpawnable() * .2);
        transform.position = new Vector3(transform.position.x + spawnDistance * 2, maxY, 0);
        nextLevelStart = transform.position;
        //transform.position = new Vector3(transform.position.x + spawnDistanceAdditional, maxY, 0);
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(platforms[Random.Range(0, platforms.Count)], transform.position, Quaternion.identity);
            transform.position = new Vector3(transform.position.x + spawnDistance, maxY, 0);
        }
    }

    public Vector3 GetNextLevelStart()
    {
        return new Vector3(nextLevelStart.x, 2.05f, nextLevelStart.z);
    }
   
}
