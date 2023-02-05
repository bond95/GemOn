using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
	public int level;
	public Sprite lockSprite;
	public Sprite unlockSprite;
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance == null || !MainManager.Instance.unlocked_levels.Exists(l => l == level)) { return; }
        UnlockLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel() {
        if (MainManager.Instance == null || !MainManager.Instance.unlocked_levels.Exists(l => l == level)) { return; }
        MainManager.Instance.current_level = level;
        SceneManager.LoadScene(level);
    }

    public void UnlockLevel() {
    	GameObject icon = gameObject.transform.Find("Image/Icon").gameObject;
    	icon.GetComponent<Image>().sprite = unlockSprite;
    }
}
