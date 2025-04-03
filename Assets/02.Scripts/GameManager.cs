using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance = null)
            {
                _instance = FindFirstObjectByType<GameManager>();
            }
            return _instance;
        }
    }
    private static GameManager _instance;

    public static Transform PlayerTransform { get; private set; }

    public static bool IsGameOver;

    void Awake()
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = FindFirstObjectByType<PlayerMove>().transform;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public static Transform GetPlayerTransform()
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = FindFirstObjectByType<PlayerMove>()?.transform;
        }

        return PlayerTransform;
    }
}
