using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float MouseX;
    private float MouseY;

    public GameObject Target;

    private void LateUpdate()
    {
        MouseX += Input.GetAxisRaw("Mouse X") * 120f * Time.deltaTime;
        MouseY -= Input.GetAxisRaw("Mouse Y") * 120f * Time.deltaTime;
        MouseY = Mathf.Clamp(MouseY, -25f, 60f);

        transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
        transform.position=(Target.transform.position-transform.rotation*new Vector3(0,0,15));
    }

    
    //void Start()
    //{
    //    player = GameObject.Find("Player");
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    transform.LookAt(player.transform.position);
    //}
}   
