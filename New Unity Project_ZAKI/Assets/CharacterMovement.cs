using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public float MovementSpeed = 1;
    public float JumpForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(!Mathf.Approximately(0,movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
            rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }
}
