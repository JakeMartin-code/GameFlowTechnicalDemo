using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpHeight;
    private Rigidbody2D _rigidBody;
    public GameManager manager;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = Vector2.up * jumpHeight;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.GameOver();
    }
}
