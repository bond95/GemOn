using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
	public bool lockedLevel = true;
	public int level;
	public Sprite lockSprite;
	public Sprite unlockSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel() {
    	if (!lockedLevel) {
    		SceneManager.LoadScene(level);
    	}
    }
    public void LockLevel() {
    	lockedLevel = true;
    	GameObject icon = gameObject.transform.Find("Image/Icon").gameObject;
    	icon.GetComponent<Image>().sprite = lockSprite;
    }
    public void UnlockLevel() {
    	lockedLevel = false;
    	GameObject icon = gameObject.transform.Find("Image/Icon").gameObject;
    	icon.GetComponent<Image>().sprite = unlockSprite;
    }
}
