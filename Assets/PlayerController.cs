using UnityEngine;
using UnityEngine.SceneManagement;  // Для смены сцен

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость перемещения по X и Y
    private SpriteRenderer spriteRenderer; // Спрайт для переворота

    private int keysCollected = 0;  // Счетчик собранных ключей
    public int totalKeys = 3;  // Количество ключей для победы

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Получаем ввод по горизонтали
        float verticalInput = Input.GetAxisRaw("Vertical");     // Получаем ввод по вертикали

        // Позиция игрока
        float newXPosition = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;
        float newYPosition = transform.position.y + verticalInput * moveSpeed * Time.deltaTime;

        // Перемещение по X и Y без ограничений
        transform.position = new Vector2(newXPosition, newYPosition);

        // Переворот (flip) по оси X
        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0; // Переворачиваем спрайт влево
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка, если игрок столкнулся с ключом
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);  // Удаляем ключ с сцены
            keysCollected++;            // Увеличиваем счетчик ключей

            Debug.Log("Ключ подобран! Всего ключей: " + keysCollected); // Отладочный вывод

            // Проверяем, если собрали все ключи
            if (keysCollected >= totalKeys)
            {
                WinGame();  // Вызываем функцию завершения игры
            }
        }
    }

    private void WinGame()
    {
        // Переход к сцене WIN
        SceneManager.LoadScene("WIN");  // Убедись, что сцена WIN существует в проекте
    }
}
