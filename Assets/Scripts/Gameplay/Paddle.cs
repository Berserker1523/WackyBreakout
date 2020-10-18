using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the Paddle Game Object
/// </summary>
public class Paddle : MonoBehaviour
{

    Rigidbody2D rb;

    BoxCollider2D boxCollider2D;
    float halfColliderWidth;
    float halfColliderHeight;

    const float BounceAngleHalfRange = 60f * Mathf.Deg2Rad;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        halfColliderWidth = boxCollider2D.size.x / 2;
        halfColliderHeight = boxCollider2D.size.y / 2;

    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        if(horizontalAxis != 0)
        {
            Vector2 rbPostition = rb.position;
            rbPostition.x += horizontalAxis * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            rbPostition.x = CalculateClampedX(rbPostition.x);
            rb.MovePosition(rbPostition);
        }
    }

    float CalculateClampedX(float x)
    {
        if(x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            return ScreenUtils.ScreenRight - halfColliderWidth;
        }
        else if(x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            return ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else
        {
            return x;
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && IsTopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool IsTopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        float point1Y = coll.GetContact(0).point.y;
        float point2Y = coll.GetContact(1).point.y;

        return Mathf.Abs(point1Y - point2Y) < tolerance;
    }
}
