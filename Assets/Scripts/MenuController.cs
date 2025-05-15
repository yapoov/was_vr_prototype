using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject leftMenu;
    [SerializeField] GameObject rightMenu;
    InputSystem_Actions inputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();

        inputActions.UI.ToggleWristMenuLeft.performed += (ctx) =>
        {
            leftMenu.SetActive(!leftMenu.activeInHierarchy);
            rightMenu.SetActive(false);
        };

        inputActions.UI.ToggleWristMenuRight.performed += (ctx) =>
        {
            rightMenu.SetActive(!rightMenu.activeInHierarchy);
            leftMenu.SetActive(false);
        };
    }

}
