using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class something : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D body;
     Transform me;

    // Update is called once per frame
    void Update()
    {
     
    }

    void FixedUpdate()
    {
        me = GameObject.Find("Player").transform; // Definerer "me" som spiller karakteren

        Vector3 name = me.position - transform.position;
        name.Normalize();
        

        body.MovePosition(transform.position + name * speed * Time.fixedDeltaTime); // Makes enemy follow "name"
    }
}
