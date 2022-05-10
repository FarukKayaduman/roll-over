using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private Touch touch;

    public GameManager gameManager;

    public float limitX = 7.25f;

    public float forwardForce = 27f;

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
                    Mathf.Clamp(transform.position.x + touch.deltaPosition.x * sidewaysMove, -limitX, limitX),
                    transform.position.y, 
                    transform.position.z);
            }
        }

        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * sidewaysMove * 13.5f, -limitX, limitX),
                    transform.position.y,
                    transform.position.z);

        if (rb.position.y < -1f)
        {
            gameManager.TryAgain();
        }
    }
}
