using UnityEngine;
using UnityEngine.SceneManagement;  // Для смены сцен

public class MainMenuController : MonoBehaviour
{
    // Метод для запуска игры
    public void PlayButtonClicked()
    {
        // Загружаем сцену игры
        SceneManager.LoadScene("Game"); // Убедись, что сцена "Game" добавлена в Build Settings
    }

    // Метод для выхода из игры
    public void ExitButtonClicked()
    {
        // Закрываем игру
        Debug.Log("Exit game...");
        Application.Quit();  // Закрывает игру
    }
}
