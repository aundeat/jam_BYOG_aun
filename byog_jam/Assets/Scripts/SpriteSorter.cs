using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic = false;
    public float offset = 0;
    private int sortingOrderBase = 0;
    private Renderer renderers;

    private void Awake()
    {
        renderers = GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        renderers.sortingOrder = (int) (sortingOrderBase - transform.position.y + offset);
        if(isStatic)
        {
            Destroy(this);
        }
    }
}
