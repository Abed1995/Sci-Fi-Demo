using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;

    float horizontalInput;
    float verticalInput;
    float gravity = 9.81f;
    [SerializeField]
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontalInput, 0, verticalInput) * speed;
        velocity.y -= gravity;

        // translate the local direction to global directiom 
        velocity = transform.transform.TransformDirection(velocity);

        controller.Move(velocity * Time.deltaTime);
    }
}
