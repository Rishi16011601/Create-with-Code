using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 20;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject com;
    [SerializeField] TextMeshProUGUI speedometer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = com.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the Vechicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed* forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed* horizontalInput);
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
        speedometer.SetText("Speed: " + speed + " mph");
    }
}
