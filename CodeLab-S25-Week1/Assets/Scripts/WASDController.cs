using UnityEngine;
using UnityEngine.InputSystem;
    
public class WASDController : MonoBehaviour
{ 
    public Rigidbody rb;

    [Header("Movement")]
    public float moveForce = 10f;
    public float maxSpeed = 5f;

    [Header("Input (new Input System - keys)")]
    public Key keyUp = Key.W;
    public Key keyDown = Key.S;
    public Key keyLeft = Key.A;
    public Key keyRight = Key.D;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 input = ReadKeys();
        MoveRigidbody(input);
    }

    Vector2 ReadKeys()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return Vector2.zero;

        float x = 0f;
        float z = 0f;
        if (keyboard[keyUp].isPressed) z += 1f;
        if (keyboard[keyDown].isPressed) z -= 1f;
        if (keyboard[keyLeft].isPressed) x -= 1f;
        if (keyboard[keyRight].isPressed) x += 1f;

        Vector2 v = new Vector2(x, z);
        if (v.sqrMagnitude > 1f) v.Normalize();
        return v;
    }

    void MoveRigidbody(Vector2 input)
    {
        Vector3 moveDir = new Vector3(input.x, input.y);
        if (moveDir.sqrMagnitude > 0f)
        {
            rb.AddForce(moveDir * moveForce, ForceMode.Acceleration);
        }

        Vector3 horizontalVel = rb.linearVelocity;
        horizontalVel.y = 0f;
        float speed = horizontalVel.magnitude;
        if (speed > maxSpeed)
        {
            horizontalVel = horizontalVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(horizontalVel.x, rb.linearVelocity.y, horizontalVel.z);
        }
    }
}