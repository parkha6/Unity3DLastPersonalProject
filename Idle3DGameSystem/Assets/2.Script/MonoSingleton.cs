using UnityEngine;

/// <summary>
/// 싱글턴 패턴 배치용 클래스
/// </summary>
public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static MonoSingleton<T> instance;
    public static MonoSingleton<T> Instance
    {
        get
        {
            if (instance == null)
            { SetupInstance(); }
            return instance;
        }
    }
    private static void SetupInstance()
    {
        instance = FindAnyObjectByType<MonoSingleton<T>>();
        if (instance != null)
        {
            instance = new GameObject(typeof(MonoSingleton<T>).Name).AddComponent<MonoSingleton<T>>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(Instance.gameObject); }
        else
        { DontDestroyOnLoad(this.gameObject); }
    }
}
