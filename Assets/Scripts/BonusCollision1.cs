using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCollision1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SnakeController snakeController = collision.gameObject.GetComponent<SnakeController>();
        if (snakeController != null)
        {
            snakeController.SpawnPill1(); // �������� ������� ��� �������� ������ ������
            snakeController.GrowSnake(); // �������� ������� ��� �������� ������ ������
            snakeController.GrowSnake(); // �������� ������� ��� �������� ������ ������
            snakeController.GrowSnake(); // �������� ������� ��� �������� ������ ������
            Destroy(gameObject); // ������� ������� �����
        }
    }
}
