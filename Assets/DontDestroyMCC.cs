using UnityEngine;

public class DontDestroyMCC : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
