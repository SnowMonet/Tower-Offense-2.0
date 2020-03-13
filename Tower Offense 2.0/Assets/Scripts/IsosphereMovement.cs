using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsosphereMovement : MonoBehaviour
{
    public float rotateXSpeed;
    public float rotateYSpeed;
    public float rotateZSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateXSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotateYSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotateZSpeed * Time.deltaTime);
    }
}
