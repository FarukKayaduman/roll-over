using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    public GameManager gameManager;

    public int numberOfStarTriggered = 0;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "UnsafeObject")
        {
            movement.enabled = false;
            gameManager.TryAgain();
        }
    }

    private void OnTriggerEnter(Collider triggerInfo)
    {
        if (triggerInfo.tag == "BonusPoint")
        {
            Destroy(triggerInfo.gameObject); // Destroy the object player hit

            numberOfStarTriggered++;
        }


    }
}
