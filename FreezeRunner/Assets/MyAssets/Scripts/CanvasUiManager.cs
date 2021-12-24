using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Imphenzia;
public class CanvasUiManager : MonoBehaviour
{
    public int currentLevelNo = 1;
    public Text thisLevelNo;

  //  public Material[] skyBox;
    public Material groundMat;

    public Color[] groundSideColors;
    public Gradient[] gradiant;

    private void Awake()
    {
        Time.timeScale = 1;

        thisLevelNo.text = "Level " + PlayerPrefs.GetInt("LevelNo", 1).ToString();
       
        currentLevelNo = PlayerPrefs.GetInt("LevelNo", 1);

        FindObjectOfType<Camera>().GetComponent<GradientSkyCamera>().gradient = gradiant[Random.Range(0, gradiant.Length)];
        //   RenderSettings.skybox = skyBox[Random.Range(0, skyBox.Length)];
        // groundMat.SetColor("Color_564D37D0", groundSideColors[Random.Range(0, groundSideColors.Length)]);
        Color color = groundSideColors[Random.Range(0, groundSideColors.Length)];
        groundMat.color = color;

        groundMat.SetColor("_EmissionColor", color);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void Next()
    {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("LevelNo", currentLevelNo + 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RetryGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            print("ResetGame");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
