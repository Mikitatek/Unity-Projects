using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{

    public static bool GameIsPaused = true;
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public GameObject registerUI;
    public GameObject resetUI;

    EventSystem system;
    public Button quitButton;
    public Button registerButton;
    public Button returnButton;
    public Button resetButton;
    public Button returnButton2;

    public Text Information;

    // Start is called before the first frame update
    void Start()
    {
        Pause();
        system = EventSystem.current;
        pauseMenuUI.SetActive(true);
        registerUI.SetActive(false);
        resetUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Button qbtn = quitButton.GetComponent<Button>();
        qbtn.onClick.AddListener(Exit);

        Button regbtn = registerButton.GetComponent<Button>();
        regbtn.onClick.AddListener(RegisterMenu);

        Button lgnbtn = returnButton.GetComponent<Button>();
        lgnbtn.onClick.AddListener(Pause);

        Button resetbtn = resetButton.GetComponent<Button>();
        resetbtn.onClick.AddListener(ResetMenu);

        Button lgnbtn2 = returnButton2.GetComponent<Button>();
        lgnbtn2.onClick.AddListener(Pause);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Equals))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous != null)
            {
                previous.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
    }

    public void Resume()
    {
        gameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        registerUI.SetActive(false);
        resetUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Information.text = "";
    }

    public void Pause()
    {
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        registerUI.SetActive(false);
        resetUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Information.text = "";
    }

    public void RegisterMenu()
    {
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        registerUI.SetActive(true);
        resetUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Information.text = "";
    }

    public void ResetMenu()
    {
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        registerUI.SetActive(false);
        resetUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Information.text = "";
    }

    void Exit()
    {
        Application.Quit();
        Information.text = "";
    }

}
