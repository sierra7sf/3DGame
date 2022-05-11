using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody rb;
    public float movementSpeed;
    private static int points = 0;

    public GasBar gasBar;
    public SpawnManager spawnManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Player is always moving
        rb.position += Vector3.right * Time.deltaTime * movementSpeed;
        
        //If they press the left key the move diagonally to the left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * movementSpeed;
        } 

        //If they press the right key the move diagonally to the right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += (Vector3.back + Vector3.right) * Time.deltaTime * movementSpeed;
        }

    }

    //on Collision for the car hitting objects
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cone")
        {
            points -= 10;
            StartCoroutine(HitCone());
            Debug.Log("Hit Cone");
        }

    }

    IEnumerator HitCone()
    {
        movementSpeed = movementSpeed / 2;
        yield return new WaitForSeconds(1);
        movementSpeed = 7;
    }


    //added by ramiro for the gas bar 
    public int get_points()
    {
        return points;
    }

    public int reset_points()
    {
        points = 0;
        return points;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            points += 10;
            Destroy(other.gameObject);
            Debug.Log("points: " + points);
            Debug.Log("Hit Coin");
        }

        if (other.gameObject.tag == "Gas")
        {
            StartCoroutine(IncreaseSpeed());

            //added by ramiro for gas bar
            gasBar.increaseGas();


            Destroy(other.gameObject);
            Debug.Log("Hit Gas");
        }
        if(other.gameObject.tag == "SpawnTrigger")
        {
            spawnManager.SpawnRoadTriggerEnter();
        }
        if (other.gameObject.tag == "ObjectSpawnTrigger")
        {
            Debug.Log("hit Object spawn trigger");
            spawnManager.SpawnObjectsTriggerEnter();
        }

    }

    IEnumerator IncreaseSpeed()
    {
        movementSpeed = movementSpeed * 2;
        yield return new WaitForSeconds(3);
        movementSpeed = 7;
    }
}
