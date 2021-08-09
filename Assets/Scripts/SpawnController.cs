using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private Transform obstacleContainer;

    public static Queue<GameObject> Obstacles;

    [SerializeField] private int poolSize = 50;
    [SerializeField] private float spawnInterval = 0.25f;
    [SerializeField] private float minHeight, maxHeight;

    private void Awake()
    {
        FillPool();
    }

    private void Start()
    {
        StartCoroutine(StartSpawning(spawnPoints[0]));
        StartCoroutine(StartSpawning(spawnPoints[1]));
    }

    private void FillPool()
    {
        Obstacles = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(obstaclePrefab, spawnPoints[0].transform.position, Quaternion.identity, obstacleContainer);
            go.SetActive(false);
            Obstacles.Enqueue(go);
        }
    }

    private GameObject GetObstacle(GameObject spawnPoint)
    {
        GameObject go = Obstacles.Dequeue();
        go.transform.position = spawnPoint.transform.position;
        return go;
    }

    private IEnumerator StartSpawning(GameObject spawnPoint)
    {
        while (true)
        {
            GameObject go = GetObstacle(spawnPoint);
            Vector2 goScale = new Vector3(go.transform.localScale.x, Random.Range(minHeight, maxHeight));
            go.transform.localScale = goScale;
            yield return new WaitForSeconds(spawnInterval);
            go.SetActive(true);
        }
    }
}
