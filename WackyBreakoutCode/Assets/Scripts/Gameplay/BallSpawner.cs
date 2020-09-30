using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    Timer spawnTimer;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    public Vector2 SpawnLocationMin
    {
        get { return spawnLocationMin; }
    }

    public Vector2 SpawnLocationMax
    {
        get { return spawnLocationMax; }
    }

    private void Start()
    {
        SetSpawnLocationSquare();
        spawnTimer = gameObject.AddComponent<Timer>();
        SpawnBall();
    }

    private void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        Instantiate(ballPrefab);
        RunSpawnTimer();
    }

    private void RunSpawnTimer()
    {
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinBallSpawnSeconds, ConfigurationUtils.MaxBallSpawnSeconds);
        spawnTimer.Run();
    }

    private void SetSpawnLocationSquare()
    {
        GameObject tempBall = Instantiate(ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }
}
