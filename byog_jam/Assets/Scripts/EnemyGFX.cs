using Pathfinding;
using System.IO;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aIPath;
    private SpriteRenderer spriteRenderer;
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
            Debug.Log("GameOver");
        }
    }
}
