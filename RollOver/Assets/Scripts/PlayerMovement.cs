using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private Touch touch;

    public GameManager gameManager;

    public float forwardForce = 2000f;

    public float sidewaysMove = 0.01f;

    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * sidewaysMove,
                    transform.position.y, 
                    transform.position.z);
            }
        }

        if(rb.position.y < -1f)
        {
            gameManager.TryAgain();
        }
    }
}
