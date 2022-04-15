using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            int activeSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeSceneBuildIndex);
        }
    }
}
