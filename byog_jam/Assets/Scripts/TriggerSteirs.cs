using UnityEngine;

public class TriggerSteirs : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int loadScene;
    private bool playerInsideTrigger = false;

    [SerializeField] private GameObject pressText;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            if (pressText != null) pressText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            if (pressText != null) pressText.SetActive(false);
        }
    }
    private void Update()
    {
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("endScene", true);

            GameObject.Find("Fader").GetComponent<LoadScene>().inxexScene = loadScene;
        }
    }

}
