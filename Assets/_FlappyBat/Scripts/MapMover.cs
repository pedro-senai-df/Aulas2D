using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class MapMover : MonoBehaviour
{
    private readonly WaitForFixedUpdate wait = new WaitForFixedUpdate();

    public GameObject obstaclePrefab;
    public int finalDificultyScore = 50;

    [Space]

    public float mapSpeed = 2f;
    public float startSpawnRate = 5f;
    public float maxSpawnRate = 1.5f;

    [Space]

    public float minHeight = -2f;
    public float maxHeight = 2f;

    [Space]

    public float spawnAtX = 10f;
    public float destroyAtX = -10f;


    private List<GameObject> obstaclePool_ = new List<GameObject>();

    private void Start()
    {
        BatBehaviour.Instance.onDeath += StopAllCoroutines;
        BatBehaviour.Instance.onFirstInput += () => StartCoroutine(SpawnRate());
    }

    private IEnumerator SpawnRate()
    {
        while (true)
        {
            StartCoroutine(ObstacleLifeCycle());

            float t = Mathf.InverseLerp(0, finalDificultyScore, ScoreBehaviour.Instance.currentScore);
            float rate = Mathf.Lerp(startSpawnRate, maxSpawnRate, t);

            yield return new WaitForSeconds(rate);
        }
    }


    private IEnumerator ObstacleLifeCycle()
    {
        Vector3 position = new Vector3(spawnAtX, Random.Range(minHeight, maxHeight), 0f);
        Vector3 endPos = position;
        endPos.x = destroyAtX;

        GameObject obstacle = obstaclePool_.Find(o => !o.activeInHierarchy);

        if (obstacle == null)
        {
            obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
            obstaclePool_.Add(obstacle);
        }
        else
        {
            obstacle.transform.position = position;
            obstacle.SetActive(true);
        }

        float moveTime = (Mathf.Abs(spawnAtX) + Mathf.Abs(destroyAtX)) / mapSpeed;

        for (float timer = 0f; timer < moveTime; timer += Time.fixedDeltaTime)
        {
            obstacle.transform.position = Vector3.Lerp(position, endPos, timer / moveTime);
            yield return wait;
        }

        obstacle.SetActive(false);
        yield break;
    }
}
