using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoctorHandler : MonoBehaviour
{
    private int happy = 0, sad = 1;
    [SerializeField] private List <Sprite> win_loose;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void Finish(bool win)
    {
        gameObject.GetComponent<Image>().sprite = win ? win_loose[happy] : win_loose[sad];
    }
}
