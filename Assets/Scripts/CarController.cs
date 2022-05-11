using System;
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
    public float[] snapLocations = {5.5f, 7.4f, 9.3f, 11.2f, 13.1f, 15.0f};
    public float[] distanceToSnapLocations = new float[6];
    public float smallestDistanceToSnap = 100.0f;
    public float smallestDistanceToSnapAbs = 100.0f;
    public bool movingLeft = false;
    public bool movingRight = false;
    public bool movingForward = false;

    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Player is always moving
        rb.position += Vector3.right * Time.deltaTime * movementSpeed;
        movingForward = true;
        float zPos = rb.position.z;
        float maxZ = Mathf.Clamp(zPos, -4.0f, 4.0f);
        transform.position = new Vector3(rb.position.x, rb.position.y, maxZ);

        //If they press the left key the move diagonally to the left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * movementSpeed;
            movingForward = false;
            movingLeft = true;
            movingRight = false;
        }

        //If they press the right key the move diagonally to the right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += (Vector3.back + Vector3.right) * Time.deltaTime * movementSpeed;
            movingForward = false;
            movingLeft = false;
            movingRight = true;
        }
        /*
        if (!movingLeft && !movingRight)
        {
            float zPos = rb.position.z;
            float maxZ = Mathf.Clamp(zPos, 6.0f, 14.5f);
            transform.position = new Vector3(rb.position.x, rb.position.y, maxZ);
        }
        
        if (rb.position.z <= 8.1) 
        {
            float zPos1 = rb.position.z;
            float maxZ1 = Mathf.Clamp(zPos1, 6.0f, 8.1f);
            transform.position = new Vector3(rb.position.x, rb.position.y, maxZ1);
        }
        else if (rb.position.z <= 10.2) 
        {
            float zPos2 = rb.position.z;
            float maxZ2 = Mathf.Clamp(zPos2, 8.1f, 10.2f);
            transform.position = new Vector3(rb.position.x, rb.position.y, maxZ2);
        }
        else if (rb.position.z <= 12.4) 
        {
            float zPos3 = rb.position.z;
            float maxZ3 = Mathf.Clamp(zPos3, 10.2f, 12.4f);
            transform.position = new Vector3(rb.position.x, rb.position.y, maxZ3);
        }
        else
        {
            float zPos4 = rb.position.z;
            float maxZ4 = Mathf.Clamp(zPos4, 12.4f, 14.5f);
            transform.position = new Vector3(rb.position.x, rb.position.y, maxZ4);
        }
        */


        /*
        if (!Array.Exists(snapLocations, item => item == rb.position.z))
        {
            Debug.Log("correcting");
            if (movingLeft)
            {
                Debug.Log("correcting left");
                transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * movementSpeed;
            }
            else
            {
                Debug.Log("correcting right");
                transform.position += (Vector3.back + Vector3.right) * Time.deltaTime * movementSpeed;
            }
            if (Array.Exists(snapLocations, item => item == rb.position.z)) {
                rb.position += Vector3.right * Time.deltaTime * movementSpeed;
                movingLeft = false;
                movingRight = false;
            }
        }

        if (movingLeft && !Input.GetKey(KeyCode.LeftArrow))
        {
            movingForward = false;
            transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * movementSpeed;
            movingRight = false;
        }
        else if (movingRight && !Input.GetKey(KeyCode.RightArrow))
        {
            movingForward = false;
            movingLeft = false;
            transform.position += (Vector3.back + Vector3.right) * Time.deltaTime * movementSpeed;
        }

        if (movingForward)
        {
            rb.position += Vector3.right * Time.deltaTime * movementSpeed;
            movingLeft = false;
            movingRight = false;
        }
    */
    }
    void resetPosition()
    {
        //find the distances the distnaces to the snap locaitons
        float currentDistance = 0;
        for (int i = 0; i < 6; i++)
        {
            //Add all the distances to distance array
            distanceToSnapLocations[i] = snapLocations[i] - rb.position.z;
            currentDistance = Math.Abs(snapLocations[i] - rb.position.z);
            Debug.Log("smallestDistanceToSnap: " + smallestDistanceToSnap);
            Debug.Log("smallestDistanceToSnapAbs: " + smallestDistanceToSnapAbs);
            Debug.Log("currentDistance: " + currentDistance);
            //If we find a smaller one by abslute value, we make it the smallest distance
            if (currentDistance < smallestDistanceToSnapAbs)
            {
                smallestDistanceToSnap = distanceToSnapLocations[i];
                smallestDistanceToSnapAbs = currentDistance; 
            }
        }

        foreach (var item in distanceToSnapLocations)
        {
            //Debug.Log(item);
        }

        int smallestDistIndex = Array.IndexOf(distanceToSnapLocations, smallestDistanceToSnap);
        //Debug.Log(smallestDistIndex);
        //Debug.Log(smallestDistanceToSnap);
        //Debug.Log(smallestDistanceToSnapAbs);
        
        smallestDistanceToSnap = -0.5f; //set to -0.5 for testing

        //figure out which way to adjust
        if (smallestDistanceToSnap < 0)
        {
            transform.position += (Vector3.back + Vector3.right) * Time.deltaTime * movementSpeed;
            //Stop adjusting when the disired z coordinate is reached
            if (rb.position.z == 5.5f)
            {
                Debug.Log("Here");
                rb.position += Vector3.right * Time.deltaTime * movementSpeed;
            }
        }

        else
        {
            transform.position += (Vector3.forward + Vector3.right) * Time.deltaTime * movementSpeed;
            //Stop adjusting when the disired z coordinate is reached
            if (rb.position.z == snapLocations[smallestDistIndex])
            {
                rb.position += Vector3.right * Time.deltaTime * movementSpeed;
            }
        }
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
            //Debug.Log("points: " + points);
            //Debug.Log("Hit Coin");
        }

        if (other.gameObject.tag == "Gas")
        {
            StartCoroutine(IncreaseSpeed());

            //added by ramiro for gas bar
            gasBar.increaseGas();


            Destroy(other.gameObject);
            //Debug.Log("Hit Gas");
        }
        if (other.gameObject.tag == "Cone")
        {
            points -= 10;
            gasBar.LightDecreaseGas();
            StartCoroutine(HitCone());
            Destroy(other.gameObject);
            Debug.Log("Hit Cone");
        }

    }

    IEnumerator HitCone()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        movementSpeed = movementSpeed / 2;
        yield return new WaitForSeconds(1);
        movementSpeed = 7;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
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
