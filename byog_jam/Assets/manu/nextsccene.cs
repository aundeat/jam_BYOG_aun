using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextsccene : MonoBehaviour
{
    public int sceneIndex;
    public void newscene() 
    
    {
        SceneManager.LoadScene(sceneIndex);
    
    }
}
