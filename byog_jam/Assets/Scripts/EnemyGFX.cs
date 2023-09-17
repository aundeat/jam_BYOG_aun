using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aIPath;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject lostText;

    private bool loser = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (aIPath.desiredVelocity.x >= 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (aIPath.desiredVelocity.x <= -0.1f)
        {
            spriteRenderer.flipX = true;
        }

        if (aIPath.reachedEndOfPath)
        {
            lostText.SetActive(true);
            loser = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.R) && loser == true)
        {
            RestartScene();
        }
    }
    void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }
}
