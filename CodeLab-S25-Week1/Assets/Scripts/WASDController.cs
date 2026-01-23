using UnityEngine;
using UnityEngine.InputSystem;
    
public class WASDController : MonoBehaviour
{ 
    Rigidbody rb;

    public float moveForce = 10f;

    public Key keyUp = Key.W;

    Keyboard keyboard = Keyboard.current;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (keyboard[keyUp].isPressed)
        {
            rb.AddForce(Vector3.up * moveForce, ForceMode.Acceleration);
        }
        
        
        // if(Input.GetKey(KeyCode.S))
        // {
        //     rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration);
        // }
    }
}