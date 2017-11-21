using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private Controller controller;
    public int ScoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            controller = gameControllerObject.GetComponent <Controller>();
        } else
        {
            Debug.Log("gameControllerObject bot found");
        }
    }

    // Use this for initialization
    void OnTriggerEnter (Collider other) {
        Debug.Log(other.name);
        if(!other.tag.Equals("Boundry"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (other.tag.Equals("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                controller.GameOver();
            }
            controller.AddScore(ScoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
		
	}
}
