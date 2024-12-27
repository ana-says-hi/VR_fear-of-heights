using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    private static SceneSwapper instance;  // Singleton instance
    private int currentSceneIndex;

    void Awake()
    {
        // Check if there is already an instance of SceneSwapper
        if (instance == null)
        {
            // If not, set this as the instance and don't destroy it on scene load
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object across scenes
        }
        else
        {
            // If there is already an instance, destroy this one (ensures only one exists)
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Get the currently loaded scene's index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        // Check for right arrow key to move forward
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LoadNextScene();
        }
        // Check for left arrow key to move backward
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LoadPreviousScene();
        }
    }

    void LoadNextScene()
    {
        // Calculate next scene index (looping back to 0 if needed)
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
        currentSceneIndex = nextSceneIndex;
    }

    void LoadPreviousScene()
    {
        // Calculate previous scene index (looping to the last scene if needed)
        int previousSceneIndex = (currentSceneIndex - 1 + SceneManager.sceneCountInBuildSettings) % SceneManager.sceneCountInBuildSettings;

        // Load the previous scene
        SceneManager.LoadScene(previousSceneIndex);
        currentSceneIndex = previousSceneIndex;
    }
}
