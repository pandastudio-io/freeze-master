using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
	public static GameManager Instance;
	public GameObject retryPanel;
	public GameObject winPanel;

	private void Awake()
    {
		if (Instance == null)
		{
			Instance = this;
		}
	}

    private void Update()
    {	
		if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

	public void RetryGame()
	{
		if (retryPanel.activeSelf == false && winPanel.activeSelf == false)
		{
			Invoke("InvokeRetryGame", 1);
		}
	}

	public void InvokeRetryGame()
    {
		print("Failed");
		//Time.timeScale = 0;
		retryPanel.SetActive(true);
	}
}
