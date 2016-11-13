using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public partial class TextManager : MonoBehaviour
{

    public enum ManagerMode
    {
        Standby, AutoQueue, Menu
    }
    public ManagerMode mode { get; set; }

    bool m_showTextBox;
    public bool showTextBox
    {
        get
        {
            return m_showTextBox;
        }
        set
        {
            m_showTextBox = value;

            //Open the text box
            if (value)
            {
                Color c = gameObject.GetComponent<Image>().color;
                gameObject.GetComponent<Image>().color = new Color(c.r, c.g, c.b, 1);
                //TODO: Make Open and Close Animation
            }
            else
            {
                Color c = gameObject.GetComponent<Image>().color;
                gameObject.GetComponent<Image>().color = new Color(c.r, c.g, c.b, 0);
                //TODO: Make Open and Close Animation

            }
        }
    }

    public Font font;
    public Text textBoxText;
    public ScrollRect scrollRect;

    /// <summary>
    /// Resets the current Text box
    /// </summary>
    public void resetText()
    {
        textToDisplay = "";
    }

    void Start()
    {
        pushing = runningCurrentQueue = running = showTextBox = false; //default off all vaiables
        mode = ManagerMode.Standby;

        textBoxText.font = font;
    }

    // Update is called once per frame
    void Update()
    {
        textBoxText.text = textToDisplay;

        if (!running && textQueue.Count > 0 && timingQueue.Count > 0)
        {
            StartCoroutine(runQueue());
        }

        showTextBox = mode != ManagerMode.Standby;


        textBoxText.rectTransform.localPosition = new Vector2(0, 0);
        textBoxText.rectTransform.sizeDelta = new Vector2(textBoxText.rectTransform.rect.width, textBoxText.preferredHeight);
        scrollRect.verticalNormalizedPosition = 0;

    }

}
