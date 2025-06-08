using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGameSelector : MonoBehaviour
{
    public void GoToGameSelector()
    {
        SceneLoadData.menuToShow = "Games";
        SceneManager.LoadScene("Main Menu");
    }
}
