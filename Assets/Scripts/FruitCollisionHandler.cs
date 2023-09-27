using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        SnakeController snakeController = collision.gameObject.GetComponent<SnakeController>();
        if (snakeController != null)
        {
            snakeController.SpawnFruit();
            snakeController.GrowSnake(); // Вызываем функцию для создания нового фрукта
            Destroy(gameObject); // Удаляем текущий фрукт
            
        }
    }

}
