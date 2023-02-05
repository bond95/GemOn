using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogScript : MonoBehaviour
{
	[Serializable]
	public struct Dialog {
	    public double timeout;
	    public String text;
	    public bool startImmidiately;
	    public bool dialogWasDone;
	    public UnityEvent AfterTimeoutAction;
	}

	[SerializeField] private TMP_Text text;

	public List <Dialog> dialogs = new List<Dialog>();

	private double timeDelta = 0.0;
	public int currentDialogIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
		this.GoToNextDialog();   
    }

    // Update is called once per frame
    void Update()
    {
    	if (timeDelta <= 0) {
    		return;
    	}
        timeDelta -= Time.deltaTime;
    	if (timeDelta <= 0) {
    		this.GoToNextDialog();
    	}
    }

    void GoToNextDialog() {
    	if (currentDialogIndex > -1 && (dialogs.Count <= currentDialogIndex + 1 || (dialogs[currentDialogIndex + 1].startImmidiately && dialogs[currentDialogIndex].AfterTimeoutAction != null))) {
			dialogs[currentDialogIndex].AfterTimeoutAction.Invoke();
    	}
    	if (dialogs.Count > currentDialogIndex + 1 && dialogs[currentDialogIndex + 1].startImmidiately && timeDelta <= 0) {
    		currentDialogIndex++;
    		this.text.text = dialogs[currentDialogIndex].text;
    		timeDelta = dialogs[currentDialogIndex].timeout;
    		var dialog = dialogs[currentDialogIndex];
    		dialog.dialogWasDone = true;
    	}
    }

    public void GoToDialogIndex(int i) {
    	if (dialogs[currentDialogIndex].AfterTimeoutAction != null) {
			dialogs[currentDialogIndex].AfterTimeoutAction.Invoke();
		}
    	if (!dialogs[i].dialogWasDone) {
    		currentDialogIndex = i;
    		this.text.text = dialogs[currentDialogIndex].text;
    		timeDelta = dialogs[currentDialogIndex].timeout;
    		var dialog = dialogs[currentDialogIndex];
    		dialog.dialogWasDone = true;
    	}
    }
}
