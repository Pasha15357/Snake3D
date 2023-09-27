using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SnakeController : MonoBehaviour
{

    public float MoveSpeed = 5;
    public float speedBonus;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 40;

    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    private List<Transform> tail = new List<Transform>();  // Список трансформов блоков тела змейки

    public Vector3 tailPosition;

    public GameObject fruitPrefab;  // Префаб фрукта
    public GameObject pillPrefab;  // Префаб фрукта
    public GameObject pillPrefab1;  // Префаб фрукта
    public float respawnTime = 3f;  // Время между появлениями фруктов
    public Vector3 spawnBoundsMin;  // Минимальные координаты для появления фрукта
    public Vector3 spawnBoundsMax;  // Максимальные координаты для появления фрукта

    private GameObject fruit;  // Экземпляр фрукта

    private GameObject pill;  // Экземпляр таблетки
    private GameObject pill1;  // Экземпляр таблетки

    private float SpeedStart;

    public GameObject gameOverScreen;

    public float timerSpeed;
    public float timerSpeedMax;


    public float magnetRange = 5f; // Дальность действия магнита
    public float magnetForce = 7f; // Сила притяжения магнита

    public Text cubeCounterText; // Ссылка на компонент текста



    // Start is called before the first frame update
    void Start()
    {
        

        SpawnFruit();  // Создаем фрукт при запуске игры
        SpeedStart = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        

        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        PositionsHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * (Gap + 1), PositionsHistory.Count - 1)];
            Vector3 MoveDirection = point - body.transform.position;
            body.transform.position += MoveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

        if (timerSpeed > 0)
        {
            MoveSpeed = speedBonus;
            timerSpeed--;
        }
        else
        {
            MoveSpeed = SpeedStart;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, magnetRange);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Bonus") || collider.CompareTag("Fruit"))
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = transform.position - rb.transform.position;
                    rb.AddForce(direction.normalized * magnetForce);
                }
            }
        }
        if (BodyParts.Count > 14 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (BodyParts.Count > 19 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (BodyParts.Count > 24 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
        }

        cubeCounterText.text = BodyParts.Count.ToString();
    }

    internal void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
        tail.Add(body.transform); // Добавляем трансформ блока тела в список tail
    }

    internal void EatFruit()
    {
        GrowSnake();
    }

    internal void SpawnFruit()
    {
        // Генерируем случайные координаты для появления фрукта
        float randomX = Random.Range(spawnBoundsMin.x, spawnBoundsMax.x);
        float randomY = Random.Range(spawnBoundsMin.y, spawnBoundsMax.y);
        float randomZ = Random.Range(spawnBoundsMin.z, spawnBoundsMax.z);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Создаем новый фрукт на сгенерированных координатах
        fruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
    }


    public void DecreaseSpeed(float amount)
    {
        MoveSpeed -= amount;
    }

    public void IncreaseSpeed(float amount)
    {
        MoveSpeed += amount;
    }

    internal void SpawnPill()
    {
        // Генерируем случайные координаты для появления фрукта
        float randomX = Random.Range(spawnBoundsMin.x, spawnBoundsMax.x);
        float randomY = Random.Range(spawnBoundsMin.y, spawnBoundsMax.y);
        float randomZ = Random.Range(spawnBoundsMin.z, spawnBoundsMax.z);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Создаем новый фрукт на сгенерированных координатах
        pill = Instantiate(pillPrefab, spawnPosition, Quaternion.identity);
    }


    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    internal void SpawnPill1()
    {
        // Генерируем случайные координаты для появления фрукта
        float randomX = Random.Range(spawnBoundsMin.x, spawnBoundsMax.x);
        float randomY = Random.Range(spawnBoundsMin.y, spawnBoundsMax.y);
        float randomZ = Random.Range(spawnBoundsMin.z, spawnBoundsMax.z);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Создаем новый фрукт на сгенерированных координатах
        pill1 = Instantiate(pillPrefab1, spawnPosition, Quaternion.identity);
    }

    public void SpeedBonus()
    {
        timerSpeed = timerSpeedMax;
    }
}