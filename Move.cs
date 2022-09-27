using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed = 50f; // Definerer speed som vi skal bruke til å endre farten
    public Rigidbody2D body; // Lager selve karakteren

    Vector2 movement; // Lager en liste over bevegelsene

    //bool er true eller false

    bool right = true; // Definerer at variabelen right er true
    bool currentD = true; // Definere at variabelen currentD er true (currentD = right)


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Registrerer om knappene for å gå til høyre og venstre blir trykket
        movement.y = Input.GetAxisRaw("Vertical"); // Registrerer om knappene for å gå opp og ned blir trykket

        if(movement.x < 0) // Forandrer variabelen right til false når knappen "a" blir trykket
        {
            right = false;
        }

        if(movement.x > 0) // Forandrer variabelen right til true når knappen "d" blir trykket
        {
            right = true;
        }

        if(right != currentD) // Flipper karakteren når man går til venstre / når right = false
        {
            flip();
            currentD = right;
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + speed * movement * Time.fixedDeltaTime); //Gjør det mulig å flytte karakteren og ikke la den resete til samme plass
        Debug.Log("DeltaTime = " + Time.fixedDeltaTime);
        Debug.Log("movement" + movement);
    }

    void flip()
    {
        gameObject.transform.Rotate(0f, 180f, 0f); // Hvordan karakteren skal se ut når den flipper (Snur karakteren 180 grader når man går til venstre)
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
