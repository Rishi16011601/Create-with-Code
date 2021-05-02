using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPower;
    private float powerStrength = 15.0f;
    public GameObject powerIndicator;

    // Start is called before the first frame update
    void Start()
    {


        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10)
        {
            Debug.Log("Game Over");
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPower = true;
            Destroy(other.gameObject);
            powerIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
        
        if ( collision.gameObject.CompareTag("Enemy") && hasPower)
        {
            Debug.Log("Player Collided with" + collision.gameObject + "with power set to " + hasPower);
            enemyRigidBody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(4);
        hasPower = false;
        powerIndicator.gameObject.SetActive(false);

    }
}
