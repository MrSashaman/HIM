using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void Start()
    {
        // Убедись, что у ключа есть Collider2D с включенным Trigger
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError("Нет Collider2D на ключе! Убедись, что ключ имеет компонент Collider2D с установленным режимом Trigger.");
        }
    }
}
