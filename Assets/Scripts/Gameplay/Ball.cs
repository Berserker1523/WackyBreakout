using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{


    Rigidbody2D rb;
    Timer lifeTimeTimer;
    float startMovingSeconds = 1f;

    bool retrySpawn = false;

    BallSpawner ballSpawner;

    private void Start()
    {
        ballSpawner = Camera.main.GetComponent<BallSpawner>();

        lifeTimeTimer = gameObject.AddComponent<Timer>();
        rb = GetComponent<Rigidbody2D>();
     
        StartCoroutine(StartMoving());
    }

    private void Update()
    {
        if (retrySpawn || lifeTimeTimer.Finished)
        {
            SpawnBall();
        }
    }

    public void SetDirection(Vector2 direction)
    {
        float speed = rb.velocity.magnitude;
        rb.velocity = speed * direction;
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startMovingSeconds);
        rb.AddForce(-Vector2.up * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
        RunLifeTimeTimer();
    }

    private void RunLifeTimeTimer()
    {
        lifeTimeTimer.Duration = ConfigurationUtils.BallLifeTime;
        lifeTimeTimer.Run();
    }

    private void OnBecameInvisible()
    {
        if(transform.position.y < ScreenUtils.ScreenBottom)
        {
            HUD.SubtractBallsLeft();
            SpawnBall();
        } 
    }

    private void SpawnBall()
    {
        // make sure we don't spawn into a collision
        if (Physics2D.OverlapArea(ballSpawner.SpawnLocationMin, ballSpawner.SpawnLocationMax) == null)
        {
            retrySpawn = false;
            ballSpawner.SpawnBall();
            Destroy(gameObject);
        }
        else
        {
            retrySpawn = true;
        }     
    }
}
