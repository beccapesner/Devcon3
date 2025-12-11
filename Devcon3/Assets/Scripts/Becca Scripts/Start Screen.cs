using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public InputActionReference menu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        menu.action.started += Menu;
    }

    private void Menu(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }
}
