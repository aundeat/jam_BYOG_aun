using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI DialogText;
    public TextMeshProUGUI CharecterNameText;

    [SerializeField] private Queue<string> sentences;
    [SerializeField] private Queue<string> charecterName;

    [SerializeField] private Animator anim;

    private void Start()
    {
        sentences = new Queue<string>();
        charecterName = new Queue<string>();
    }
    public void StartDialog(Dialog dialog)
    {
        anim.SetBool("isOpen", true);

        sentences.Clear();
        charecterName.Clear();

        foreach (string sentence in dialog.Sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialog.Name)
        {
            charecterName.Enqueue(name);
        }
        displayNextSentances();
    }

    public void displayNextSentances()
    {
        if (!isAmpty())
        {
            string sentence = sentences.Dequeue();
            string name = charecterName.Dequeue();

            StartCoroutine(TypeSentence(sentence, name));
        }
    }
    IEnumerator TypeSentence(string sentence, string name)
    {
        DialogText.text = "";
        CharecterNameText.text = name;
        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return null;
        }
    }
    private bool isAmpty()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EndDialog()
    {
        anim.SetBool("isOpen", false);
    }
}
