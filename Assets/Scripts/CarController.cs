using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody rb;
    public float movementSpeed;
    private int points = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.position += Vector3.back * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.position += Vector3.right * Time.deltaTime * movementSpeed;
        }

    }

    //on Collision for the car hitting objects
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            points -= 10;
            movementSpeed = movementSpeed / 2;
            Debug.Log("Hit Barrier");
        }

        if (other.gameObject.tag == "Coin") {
            points += 10;
            Destroy(other.gameObject);
            Debug.Log("points: " + points);
            Debug.Log("Hit Coin");
        }

        if (other.gameObject.tag == "Gas") {
            movementSpeed = movementSpeed * 2;
            Destroy(other.gameObject);
            Debug.Log("Hit Gas");
        }
    }


}
