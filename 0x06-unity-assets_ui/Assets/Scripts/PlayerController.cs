using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    public float moveSpeed;
    public float jumpPower;

    // The starting point.
    private Vector3 startingPoint = new Vector3(0, 1.25f, 0);

    private bool grounded = true;
    // Initial Setup.
    void Start()
    {
        //Getting the player's Rigidbody
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Rotating
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }

        if (player.transform.position.y <= -30)
        {
            playerReset();
        }
    }

    // Controlling the player's movement
    private void FixedUpdate()
    {
        //X and Z movement
        Vector3 movement = Vector3.zero;
        float strafe = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float walk = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        movement.x = strafe;
        movement.z = walk;

        transform.Translate(movement);

        if (Input.GetButton("Jump") && grounded)
        {
            Debug.Log("Tried to Jump");
            player.AddForce(0, jumpPower, 0, ForceMode.Impulse);
        }
    }

    // Reset the player if he falls of the game.
    private void playerReset()
    {
        player.transform.position = startingPoint;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    // Used to avoid mid-air jumping.
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }
}
