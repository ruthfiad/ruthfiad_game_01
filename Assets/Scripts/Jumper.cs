using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float forceMagnitude = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Jumper hit the ball " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This function is called when another object collides with this one
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            Debug.Log("🎯 Bumper hit the ball!");

            // Add force to the ball in the direction of the bumper's local Y axis
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = Vector3.up; // замінив transform.up → м’яч летить строго вгору
            float forceMagnitude = 100f; // зробив силу більшу, щоб ефект було видно
            ballRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }
}
