using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class WindowBack : MonoBehaviour
{
    private BaseButton _button;
    private CloseWindowButton _closeWindowButton;
		
    public void Init(CloseWindowButton closeButton)
    {
        _button = GetComponent<BaseButton>();
        _button.SetCallback(OnPressedClose);
			
        _closeWindowButton = closeButton;
    }

    private void OnPressedClose()
    {
        _closeWindowButton.SimulateClick();
    }
}