using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlUI : MonoBehaviour
{
    public Transform pipes;
    public Transform pipes2;
    public Transform pipeline;

    public bool eventClick;
    public bool clicked;
    public GameObject menuEscape;
    public event EventHandler<ClickModeArgs> OnClickMode;
    public class ClickModeArgs : EventArgs
    {
        public bool isClicked;
    }
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OnClickMode += MouseInteraction_OnClickMode;
    }
    public void HideMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void MouseInteraction_OnClickMode(object sender, ClickModeArgs e)
    {
        Cursor.visible = e.isClicked;

        if (e.isClicked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        eventClick = e.isClicked;
    }
    // Start is called before the first frame update
    void Start()
    {
        //menuEscape.SetActive(false);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clicked = !clicked;
            OnClickMode?.Invoke(this, new ClickModeArgs { isClicked = clicked });
            menuEscape.SetActive(clicked);
        }
    }

    public void ShowPipes(GameObject go)
    {
        Debug.Log("ShowPipes");
        pipes.gameObject.SetActive(!pipes.gameObject.activeSelf);
        if (pipes.gameObject.activeSelf) go.GetComponent<Image>().color = Color.green;
        else go.GetComponent<Image>().color = Color.red;

        if (pipes.gameObject.activeSelf) go.GetComponentInChildren<TMP_Text>().text = "Pipe 1 On";
        else go.GetComponentInChildren<TMP_Text>().text = "Pipe 1 Off";
    }
    public void ShowPipes2(GameObject go)
    {
        Debug.Log("ShowPipes 2");
        pipes2.gameObject.SetActive(!pipes2.gameObject.activeSelf);
        if (pipes2.gameObject.activeSelf) go.GetComponent<Image>().color = Color.green;
        else go.GetComponent<Image>().color = Color.red;

        if (pipes2.gameObject.activeSelf) go.GetComponentInChildren<TMP_Text>().text = "Pipe 2 On";
        else go.GetComponentInChildren<TMP_Text>().text = "Pipe 2 Off";
    }
    public void ShowPipesline(GameObject go)
    {
        Debug.Log("ShowPipeline");
        pipeline.gameObject.SetActive(!pipeline.gameObject.activeSelf);
        if (pipeline.gameObject.activeSelf) go.GetComponent<Image>().color = Color.green;
        else go.GetComponent<Image>().color = Color.red;

        if (pipeline.gameObject.activeSelf) go.GetComponentInChildren<TMP_Text>().text = "Pipeline On";
        else go.GetComponentInChildren<TMP_Text>().text = "Pipeline Off";
    }
}
