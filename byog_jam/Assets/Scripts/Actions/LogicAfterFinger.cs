using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicAfterFinger : MonoBehaviour, LogicAfterTake
{
    [SerializeField] private Animator anim;
    [SerializeField] private int loadScene;
    public static GameObject instance;
    public void ExecuteCustomLogic()
    {
        GameObject fader = GameObject.Find("Fader");
        fader.GetComponent<LoadScene>().inxexScene = loadScene;
        if (anim != null) anim.SetBool("endScene", true);
    }

}
