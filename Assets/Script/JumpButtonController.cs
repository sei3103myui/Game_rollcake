using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonController: MonoBehaviour
{
    public LayerMask conveyorLayer;
    Rigidbody2D rigid2D;
    GameObject player;
    private float jumpForce = 680.0f;
    private bool can_jump = false;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cake_1");
        this.rigid2D = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (can_jump)
        {
            this.rigid2D.AddForce(Vector2.up * this.jumpForce);
            can_jump = false;
        }
    }

    public void OnClick()
    {
        can_jump = Physics2D.Linecast(this.player.transform.position -(this.player.transform.right * 0.3f),
            this.player.transform.position -(this.player.transform.up * 0.1f),conveyorLayer) ||
            Physics2D.Linecast(this.player.transform.position - (this.player.transform.right * 0.3f),
            this.player.transform.position - (this.player.transform.up * 0.1f),conveyorLayer);
    }
}
