using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mothership : MonoBehaviour
{
    public Transform[] location;
    public GameObject[] enemies;
    float spawnrate = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnrate) // Setter hvor ofte og hvor fiendene kommer til å dukke opp
        {
            spawnrate += 2.5f;
            int randomnummber = Random.Range(0, location.Length);
            int randomnumber = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomnumber], location[randomnummber].position, transform.rotation);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    }
