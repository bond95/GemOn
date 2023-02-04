using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ExitGame() {
    	Application.Quit();
    }

    public void GoToLevels() {
    	SceneManager.LoadScene(1);
    }
    public void GoToMenu() {
    	SceneManager.LoadScene(0);
    }
}
