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
    public float minZ = 0;
    public float maxZ = 0;
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
        //If they press the left key the move diagonally to the left
        float zPos = rb.position.z;
        float zLimit = Mathf.Clamp(zPos, minZ, maxZ);
        transform.position = new Vector3(rb.position.x, rb.position.y, zLimit);
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
        if (other.gameObject.tag == "Goal")
        {
            FindObjectOfType<Game_Manager>().endTutorial();
        }

    }

    IEnumerator HitCone()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        movementSpeed = 1;
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
        movementSpeed = 14;
        yield return new WaitForSeconds(3);
        movementSpeed = 7;
    }
}
