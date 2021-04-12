using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float move = 1.75f; //Distance moved left or right (Meters)
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x > -1.5)
            {
                transform.Translate(-move, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < 1.5)
            {
                transform.Translate(move, 0, 0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("hazard"))
        {
            Debug.Log("yes!");
            manager.GetComponent<menu>().EndGame();
        }
    }



}
