using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTools : MonoBehaviour
{
    public void GoToTools()
    {
        SceneLoadData.menuToShow = "Tools";
        SceneManager.LoadScene("Main Menu");
    }
}
