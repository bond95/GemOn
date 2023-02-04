using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuManager : MonoBehaviour
{
	public GameObject escapeMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
        	escapeMenu.gameObject.SetActive(!escapeMenu.gameObject.activeSelf);
        }
    }

    public void HideMenu() {
    	escapeMenu.gameObject.SetActive(false);
    }
}
