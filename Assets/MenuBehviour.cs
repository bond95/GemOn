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

    private IEnumerator WaitForSceneLoad(int scene) {
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(scene);

	}

    public void ExitGame() {
    	Application.Quit();
    }

    public void GoToLevels() {

    	// SceneManager.LoadScene(1);
    	StartCoroutine(WaitForSceneLoad(1));
    }
    public void GoToMenu() {
    	StartCoroutine(WaitForSceneLoad(0));
    }
    public void GoToAuthors() {
    	StartCoroutine(WaitForSceneLoad(4));
    }
}
