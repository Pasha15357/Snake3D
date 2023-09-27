using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SnakeController snakeController = collision.gameObject.GetComponent<SnakeController>();
        if (snakeController != null)
        {
            snakeController.ShowGameOverScreen();
            return;
        }
    }
}
