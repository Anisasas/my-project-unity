using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if ((Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W)) TryMove(Vector2.up);
            else if (Input.GetKeyDown(KeyCode.S)) TryMove(Vector2.down);
            else if (Input.GetKeyDown(KeyCode.A)) TryMove(Vector2.left);
            else if (Input.GetKeyDown(KeyCode.D)) TryMove(Vector2.right);
        }
    }

    void TryMove(Vector2 dir)
    {
        Vector2 newPos = targetPos + dir;
        Collider2D hit = Physics2D.OverlapPoint(newPos);
        if (hit == null || !hit.CompareTag("Wall"))
        {
            targetPos = newPos;
        }
    }
}
