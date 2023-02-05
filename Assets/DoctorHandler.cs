using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoctorHandler : MonoBehaviour
{
    private int happy = 0, sad = 1;
    [SerializeField] private List <Sprite> win_loose;
    [SerializeField] private Sprite default_state;

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
        gameObject.GetComponent<Image>().sprite = win ? win_loose[happy] : win_loose[sad];
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

 
}
