using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    Transform player;
    public Vector3 randomname;


    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform; // Putter midten av kameraet p� spilleren    
        transform.position = new Vector3(player.position.x - randomname.x, player.position.y - randomname.y, player.position.z - randomname.z); // F�r kameraet til � f�lge spilleren
    }
}
