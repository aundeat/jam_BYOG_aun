using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private bool playerInsideTrigger = false;
    [SerializeField] private Item itemToadd;
    [SerializeField] private GameObject pressText;


    [SerializeField] private GameObject playerLight;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && itemToadd != null)
        {
            playerInsideTrigger = true;
            if (pressText != null) pressText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && itemToadd != null)
        {
            playerInsideTrigger = false;
            if (pressText != null) pressText.SetActive(false);
        }
    }
    private void Update()
    {
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E) && itemToadd != null)
        {
            if (takeLight())
            {
                itemToadd = null;
                pressText.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                GameObject.Find("Player").GetComponent<Inventory>().AddItem(itemToadd);
                itemToadd = null;
                pressText.SetActive(false);
            }
        }
    }

    private bool takeLight()
    {
        if (gameObject.tag == "Light")
        {
            playerLight.SetActive(true);
            pressText.SetActive(false);
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }

    }
}
