using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButtonManager : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid2D;
    private int hp_up;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cake_1");
        this.rigid2D = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnClick()
    {
        
    }
}
