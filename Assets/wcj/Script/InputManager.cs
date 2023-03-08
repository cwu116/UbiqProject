using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    
    [SerializeField]
    InputActionReference leftFirstButton;
    [SerializeField]
    InputActionReference rightFirstButton;
    [SerializeField]
    InputActionReference rightSecondButton;
    [SerializeField]
    GameObject leftHandRay;
    [SerializeField]
    GameObject rightHandRay;
    [SerializeField]
    GameObject leftHandReal;
    [SerializeField]
    GameObject rightHandReal;
    [SerializeField]
    GameObject playerPos;

    [SerializeField]
    GameObject crateFireWorkUI;

    public bool rightSecondButtonOn;

    public static InputManager instance;
    
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    void Start()
    {
        InputAction inputActionleft1 = leftFirstButton.action;
        inputActionleft1.started += SwitchHand;

        InputAction inputActionright1 = rightFirstButton.action;
        inputActionright1.started += OpenCreateFireWorkPanel;

        InputAction inputActionright2 = rightSecondButton.action;
        inputActionright2.started += SwitchRightButtonOn;
        inputActionright2.canceled += SwitchRightButtonOff;
    }

    void SwitchHand(InputAction.CallbackContext obj)
    {
        if(leftHandReal.activeSelf == true && rightHandReal.activeSelf == true)
        {
            leftHandReal.SetActive(false);
            rightHandReal.SetActive(false);
            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);
        }

        else if (leftHandRay.activeSelf == true && rightHandRay.activeSelf == true)
        {
            leftHandReal.SetActive(true);
            rightHandReal.SetActive(true);
            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
        }
    }

    void OpenCreateFireWorkPanel(InputAction.CallbackContext obj)
    {
        if (crateFireWorkUI.activeSelf)
            crateFireWorkUI.SetActive(false);
        else
        {
            crateFireWorkUI.SetActive(true);
            crateFireWorkUI.transform.position = playerPos.transform.position + playerPos.transform.forward * 2;
            crateFireWorkUI.transform.LookAt(playerPos.transform);
        }
    }

    void SwitchRightButtonOn(InputAction.CallbackContext obj)
    {
        rightSecondButtonOn = true;

    }

    void SwitchRightButtonOff(InputAction.CallbackContext obj)
    {
        rightSecondButtonOn = false;

    }

}
