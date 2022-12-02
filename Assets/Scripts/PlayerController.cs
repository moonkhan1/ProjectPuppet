using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    float horizontal;
    float vertical;
    float turnSmoothVelocity;
    [SerializeField] float MovementForce = 10f;
    [SerializeField] float SmoothTurnTime = 0.1f;
    Rigidbody rb;
    Vector3 direction;
    Animator anim;
    private bool MoveSwitch = false;
    [SerializeField] private FloatingJoystick _joystick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {


        if (!MoveSwitch)
        {
            horizontal = _joystick.Horizontal;
            vertical = _joystick.Vertical;

            direction = new Vector3(horizontal, 0, vertical);
            anim.SetFloat("Run", direction.magnitude);
            if (direction.magnitude > 0.01f)
            {
                anim.SetBool("isRunning", true);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, SmoothTurnTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0);

                rb.MovePosition(transform.position + (direction * MovementForce * Time.deltaTime));
            }
        }

        else
        {
             horizontal = -_joystick.Horizontal;
            vertical = -_joystick.Vertical;

            direction = new Vector3(horizontal, 0, vertical);
            anim.SetFloat("Run", direction.magnitude);
            if (direction.magnitude > 0.01f)
            {
                anim.SetBool("isRunning", true);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, SmoothTurnTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0);

                rb.MovePosition(transform.position - (direction * MovementForce * Time.deltaTime));
            }
        }

    }


    public void SwitchMove()
    {
        MoveSwitch = !MoveSwitch;
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        
    }
}
