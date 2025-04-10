using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float rotateSpeed;

    private float inputH;
    private float inputV;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(inputH, 0f, inputV).normalized;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if(direction != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotateSpeed * Time.deltaTime);
        }
    }
}
