using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    public GameObject leftPaddle;

    public GameObject rightPaddle;

    private Rigidbody leftRBody;

    private Rigidbody rightRBody;

    public float paddleMoveSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        leftRBody = leftPaddle.GetComponent<Rigidbody>();
        rightRBody = rightPaddle.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float leftControl = Input.GetAxis("LeftControl");
        float rightControl = Input.GetAxis("RightControl");
        
        
        leftPaddle.transform.position += Vector3.up * leftControl * paddleMoveSpeed * Time.deltaTime;
        rightPaddle.transform.position += Vector3.up * rightControl * paddleMoveSpeed * Time.deltaTime;
        
    }
}
