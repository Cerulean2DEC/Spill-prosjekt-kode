using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed = 50f; // Definerer speed som vi skal bruke til � endre farten
    public Rigidbody2D body; // Lager selve karakteren

    Vector2 movement; // Lager en liste over bevegelsene

    //bool er true eller false

    bool right = true; // Definerer at variabelen right er true
    bool currentD = true; // Definere at variabelen currentD er true (currentD = right)


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Registrerer om knappene for � g� til h�yre og venstre blir trykket
        movement.y = Input.GetAxisRaw("Vertical"); // Registrerer om knappene for � g� opp og ned blir trykket

        if(movement.x < 0) // Forandrer variabelen right til false n�r knappen "a" blir trykket
        {
            right = false;
        }

        if(movement.x > 0) // Forandrer variabelen right til true n�r knappen "d" blir trykket
        {
            right = true;
        }

        if(right != currentD) // Flipper karakteren n�r man g�r til venstre / n�r right = false
        {
            flip();
            currentD = right;
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + speed * movement * Time.fixedDeltaTime); //Gj�r det mulig � flytte karakteren og ikke la den resete til samme plass
        Debug.Log("DeltaTime = " + Time.fixedDeltaTime);
        Debug.Log("movement" + movement);
    }

    void flip()
    {
        gameObject.transform.Rotate(0f, 180f, 0f); // Hvordan karakteren skal se ut n�r den flipper (Snur karakteren 180 grader n�r man g�r til venstre)
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
