using UnityEngine;

public class SortLayerTrigger : MonoBehaviour
{
    public int layer;

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer;
    }
}
