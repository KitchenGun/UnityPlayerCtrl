using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public bool Grounded { get; private set; }

    private Rigidbody rigidbody;
    
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();   
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal * 5f, rigidbody.velocity.y, vertical * 5f);
        rigidbody.velocity = transform.TransformDirection(direction);

        if(Input.GetKey(KeyCode.Space)&&Grounded)
        {
            rigidbody.AddForce(transform.up * 5, ForceMode.Impulse);
        }
        if(Physics.SphereCast(transform.position,0.3f,Vector3.down,out RaycastHit hitInfo,1.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }


    private void Update()
    {
        MouseX += Input.GetAxisRaw("Mouse X");
        MouseY -= Input.GetAxisRaw("Mouse Y");

        //Debug.LogFormat("mouseX{0},mouseY{1}", MouseX, MouseY);

        Vector3 eularAngles = new Vector3(0, MouseX, 0);
        transform.localEulerAngles = eularAngles;

        Camera mainCamera = Camera.main;
        mainCamera.transform.localEulerAngles = new Vector3(MouseY, 0, 0);


    }
}
