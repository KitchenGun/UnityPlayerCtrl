using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    private float MouseX = 0f;
    private Vector3 InputVector = Vector3.zero;
    private float MoveSpeed = 5f;
    private float YSpeed = 0f;
    [SerializeField]
    private CharacterController character;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        //character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //회전
        MouseX += Input.GetAxisRaw("Mouse X") * 120f * Time.deltaTime;
        Quaternion q = Quaternion.Euler(0, MouseX, 0);
        transform.rotation = q;
        //이동
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        InputVector = new Vector3(horizontal, 0, vertical)*MoveSpeed;

        if(character.isGrounded==false)
        {
            YSpeed -= 0.05f;
        }

        InputVector.y = YSpeed;
        character.Move(transform.TransformVector(InputVector) * Time.deltaTime);

        animator.SetBool("Grounded", character.isGrounded);
        animator.SetInteger("Vspeed", (int)InputVector.z);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Running", true);
            MoveSpeed = 10;
        }
        else if(0<InputVector.z)
        {
            animator.SetBool("Running", false);
            MoveSpeed = 5;
        }
        //점프
        if(Input.GetButton("Jump")&&character.isGrounded)
        {
            YSpeed = 5f;
        }
    }
}
