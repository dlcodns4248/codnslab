using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float Speed = 3f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))  
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))  
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }
}
