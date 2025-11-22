using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;           // Ссылка на игрока
    public float chaseSpeed = 3.5f;    // Скорость движения врага
    public float chaseRange = 10f;     // Расстояние для начала погони
    public float stoppingDistance = 1f; // Расстояние до игрока, при котором враг остановится

    private bool isCaught = false;     // Флаг, чтобы проверить, поймал ли враг игрока
    public GameObject screamerCanvas;  // Canvas с скримером
    public AudioSource screamerSound;  // Звук скримера

    void Update()
    {
        if (!isCaught)
        {
            // Проверка расстояния до игрока для начала погони
            if (Vector3.Distance(transform.position, player.position) < chaseRange)
            {
                // Двигаемся к игроку
                ChasePlayer();
            }

            // Проверка на ловлю игрока (если расстояние меньше stoppingDistance)
            if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {
                if (!isCaught)
                {
                    isCaught = true; // Враг поймал игрока
                    TriggerScreamer(); // Запускаем скример
                }
            }
        }
    }

    void ChasePlayer()
    {
        // Двигаем врага к позиции игрока с использованием MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void TriggerScreamer()
    {
        // Включаем Canvas скримера
        screamerCanvas.SetActive(true);
        // Включаем звук скримера
        screamerSound.Play();

        // После окончания звука, переходим на главную сцену
        Invoke("BackToMainMenu", screamerSound.clip.length); // Ждем, пока не проиграет звук
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Возвращаемся в меню
    }
}
