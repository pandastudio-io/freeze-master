using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void MoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=crazyappslabz");
    }

    public void RateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.crazyappslabz.stretchboy");
    }

    public void PrivacyPolicy()
    {
        Application.OpenURL("https://sites.google.com/view/crazyappslabz/home");
    }
}
