using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DoctorHandler : MonoBehaviour
{
    private int happy = 0, sad = 1;
    [SerializeField] private List <Sprite> win_loose;
    [SerializeField] private Sprite default_state;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip looseClip;

    private float moody = 0.0f;


    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        if (moody <= 0) { return; }

        moody -= Time.deltaTime;
        if (moody <= 0) {
            gameObject.GetComponent<Image>().sprite = default_state;
        }
    }

    public void Finish(bool win)
    {
        if (win) {
            audioSource.PlayOneShot(winClip, 0.5f);
        } else {
            audioSource.PlayOneShot(looseClip, 0.5f);
        }
        gameObject.GetComponent<Image>().sprite = win ? win_loose[happy] : win_loose[sad];
        if (MainManager.Instance != null && win) {
            MainManager.Instance.UnlockNextLevel();
        }
        SceneManager.LoadScene(1);
    }

    public void Satisfy()
    {
        moody = 1.0f;
        gameObject.GetComponent<Image>().sprite = win_loose[happy];
    }


    public void Frustrate()
    {
        moody = 1.0f;
        gameObject.GetComponent<Image>().sprite = win_loose[sad];
    }

 
    public void HappyDoctor() {
        gameObject.GetComponent<Image>().sprite = win_loose[happy];   
    }
}
