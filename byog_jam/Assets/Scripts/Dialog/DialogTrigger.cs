using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private bool destroyOnExit;
    private void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
    private void EndDialog()
    {
        FindObjectOfType<DialogManager>().EndDialog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialog();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EndDialog();
        if (destroyOnExit)
        {
            Destroy(gameObject);
        }
    }

}
