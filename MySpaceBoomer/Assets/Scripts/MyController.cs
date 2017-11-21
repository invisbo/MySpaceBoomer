using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class MyController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float fireRate;

    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    

    private float nextFire;


    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        //boundry = new Boundry();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0.0f, vertical);
        GetComponent<Rigidbody>().velocity = move * speed;
        GetComponent<Rigidbody>().position = new Vector3 (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
           0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f,0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
