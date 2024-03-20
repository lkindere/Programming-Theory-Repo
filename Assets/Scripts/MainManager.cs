using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    static public MainManager Instance { get; private set; }

    void Start()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
