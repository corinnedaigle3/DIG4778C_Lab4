using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject player;

    public Camera cam;

    // The object to orbit around
    public Transform centerObject;
    
    // Radius of the circle
    float radius;

    // Speed of orbit
    public float speed = .3f;
    private float angle = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        radius = Random.Range(5f, 7f);
        Debug.Log(radius);
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        cam = player.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {


        if (player != null)
        {  
            //Rotation around the player
            Rotation();
            //Look at the player
            LookAtPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            cam.Shaking();
           

            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void Rotation()
    {
        // Speed depends on radius
        float orbitSpeed = speed * radius / 2;

        // Calculate the new position
        angle += orbitSpeed * Time.deltaTime;

        float x = player.transform.position.x + Mathf.Cos(angle) * radius;
        float y = player.transform.position.y + Mathf.Sin(angle) * radius;

        // Update the position
        transform.position = new Vector3(x, y, transform.position.z);

    }

    public void LookAtPlayer()
    {
        // Rotate to face the player
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        

        // Adjust the rotation to make the object face the player correctly
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
