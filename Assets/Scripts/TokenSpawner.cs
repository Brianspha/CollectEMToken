using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public List<GameObject> tokens;
    public Transform spawnerLocationEnd, sideL, sideR;
    public float subtractFactor = .55f;
    public float startY = 3.29f, maxSpawnLocation = 7.57f;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnToken();
    }

    private void SpawnToken()
    {
        GameObject token = tokens[Random.Range(0, tokens.Count)];
        Instantiate(token, new Vector3(Random.Range(transform.position.x, spawnerLocationEnd.position.x), transform.position.y, Random.Range(-maxSpawnLocation, maxSpawnLocation)), token.transform.rotation);
    }
}
