using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    public float pipeMoveSpeed;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        transform.position += Vector3.left * pipeMoveSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {

            Destroy(gameObject);
        }
    }
}
