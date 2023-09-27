using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCollision : MonoBehaviour
{
    public float bonusDuration = 1f; // ������������ ������ � ��������
    private bool isBonusActive = false; // ����, �����������, ������� �� �����
    public float speedIncreaseAmount = 2f;


    
    private void OnCollisionEnter(Collision collision)
    {
        SnakeController snakeController = collision.gameObject.GetComponent<SnakeController>();
        if (snakeController != null && !isBonusActive)
        {
            snakeController.IncreaseSpeed(speedIncreaseAmount);
            snakeController.SpeedBonus();
            snakeController.SpawnPill();
            Destroy(gameObject);
        }
    }

}
