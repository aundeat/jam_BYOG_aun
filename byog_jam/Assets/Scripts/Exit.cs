using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene(9);
    }
}
