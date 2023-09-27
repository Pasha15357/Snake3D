using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Ссылка на трансформ головы змейки
    public Vector3 offset;  // Смещение камеры относительно головы змейки

    private void LateUpdate()
    {
        // Перемещаем камеру на позицию головы змейки с учетом смещения
        transform.position = target.position + offset;

        // Поворачиваем камеру так, чтобы она всегда смотрела на голову змейки
        transform.LookAt(target);
    }
}
