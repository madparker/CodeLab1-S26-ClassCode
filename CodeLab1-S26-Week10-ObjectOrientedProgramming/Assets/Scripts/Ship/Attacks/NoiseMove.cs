using UnityEngine;

public class NoiseMove : MonoBehaviour
{
    Rigidbody2D rb;
    
    public float amplitude = 2;
    public float frequency = 0.1f;

    public void InitVel(Vector2 vel)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.linearVelocity;
        
        velocity.x += Mathf.PerlinNoise(transform.position.x * frequency, transform.position.y * frequency) * amplitude - amplitude/2;
        
        rb.linearVelocity = velocity;
    }
}
