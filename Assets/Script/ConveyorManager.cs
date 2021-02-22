using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public GameObject cake_1;
    public float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "cake_1")
        {
            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x + 3, -6, 6),rigidbody.velocity.y);
        }
    }
}
