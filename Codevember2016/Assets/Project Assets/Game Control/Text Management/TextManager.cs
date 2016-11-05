using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    public bool pushing { get; set; }
    public bool running { get; set; }
    public bool queueEnabled { get; set; }
    public Font font;


    //Auto Text Pushes
    public float endTimer = 4f; //the time between ending auto text queues and closing the box
    public float nextQueueTimer = 2f; //The time between transitioning in the queue

    public Text textBoxText;
    public Scrollbar scrollBar;

    private int stringIndex = 0; //is local to the push text iteration. NOT the entire text box
    private string textToDisplay = "";

    ArrayList textQueue = new ArrayList();
    ArrayList timingQueue = new ArrayList();

    public TextSpeed speedLevel = TextSpeed.Medium; //default medium

    public enum TextSpeed
    {
        Slowest,
        Slow,
        Medium,
        Fast,
        Fastest,
    }

    void Start()
    {
        pushing = running = queueEnabled = false; //default off all vaiables

        textBoxText.font = font;
    }

    // Update is called once per frame
    void Update()
    {
        textBoxText.text = textToDisplay;

        if (!queueEnabled && textQueue.Count > 0 && timingQueue.Count > 0)
        {
            StartCoroutine(runQueue());
        }

    }

    public float getSpeed()
    {
        switch (speedLevel)
        {
            case TextSpeed.Fastest:
                return 0.001f;
            case TextSpeed.Fast:
                return 0.05f;
            case TextSpeed.Medium:
                return 0.1f;
            case TextSpeed.Slow:
                return 0.25f;
            case TextSpeed.Slowest:
                return 0.2f;
            default:
                return 0.1f;
        }
    }

    public IEnumerator pushText(string textInput, float preWaitTime)
    {
        pushing = true;

        yield return new WaitForSeconds(preWaitTime); //text delays to lead into new texts

        //Put a bullet point for each of the new pushText iterations
        if (stringIndex == 0)
        {
            textToDisplay += "\n" + "•"; //move down a line and create a bullet point
        }


        textToDisplay += textInput.ToCharArray()[stringIndex];

        //for any character that is not a space, play a sound
        if (stringIndex < textInput.Length - 2 && textInput.ToCharArray()[stringIndex] != ' ') ;
        {
            //TODO: Play Text Sound
            //Debug.Log("TODO: Create text sound");
        }


        stringIndex++; //increase the string index
        yield return new WaitForSeconds(getSpeed()); //push text at the pace of the speed

        //TODO: Custom Inputs
        if (Input.anyKeyDown)
        {
            textToDisplay += textInput.Substring(stringIndex, textInput.Length - stringIndex);
            stringIndex = 0;
            pushing = false;
            StopCoroutine("pushText"); //end the push text function if the submit button is pressed : instant text emulation
        }
        else if (stringIndex >= textInput.Length)
        {
            stringIndex = 0;
            pushing = false;
            StopCoroutine("pushText"); //end the push text function if the submit button is pressed : instant text emulation
        }
        else
        {
            //Do it again with no text delay
            StartCoroutine(pushText(textInput, 0));
        }
    }

    /// <summary>
    /// Resets the current Text box
    /// </summary>
    public void resetText()
    {
        textToDisplay = "";
    }

    public IEnumerator autoTextQueue(string[] text, float[] timing)
    {
        running = true;
        //Start off by reseting the previous text

        for (int i = 0; i < text.Length; i++)
        {
            while (pushing) { yield return null; }

            StartCoroutine(pushText(text[i], timing[i]));

        }

        while (pushing) { yield return null; }
        yield return new WaitForSeconds(endTimer);

        resetText();

        running = false;
    }

    public IEnumerator runQueue()
    {
        queueEnabled = true;

        while (textQueue.Count > 0)
        {
            while (running) { yield return null; }

            yield return new WaitForSeconds(nextQueueTimer);

            StartCoroutine(autoTextQueue((string[])textQueue.ToArray().GetValue(0), (float[])timingQueue.ToArray().GetValue(0)));

            textQueue.RemoveAt(0); //FIFO Queue
        }

        queueEnabled = false;

    }

    /// <summary>
    /// Pushes Text using a font specified
    /// </summary>
    /// <param name="text"> The text to be pushed</param>
    /// <param name="timing">The timing of the Text: </param>
    /// <param name="_font"></param>
    public void addToQueue(string[] text, float[] timing, Font _font)
    {
        textQueue.Add(text);
        timingQueue.Add(timing);
        font = _font;
    }

    /// <summary>
    /// Pushes text using the last font specified
    /// </summary>
    /// <param name="text"></param>
    /// <param name="timing"></param>
    public void addToQueue(string[] text, float[] timing)
    {
        addToQueue(text, timing, font);
    }

    /// <summary>
    /// Pushes Text using the last font specified, as well as default speed
    /// </summary>
    /// <param name="text"></param>
    public void addToQueue(string[] text)
    {
        addToQueue(text, new float[text.Length], font); //null timer as a fill to keep synchronized stringQueue and timingQueue
    }

    /// <summary>
    /// Pushes Text using the last font specified, as well as default speed
    /// </summary>
    /// <param name="text">The text being pushed</param>
    public void addToQueue(string text)
    {
        addToQueue(new string[] { text }, new float[text.Length], font); //null timer as a fill to keep synchronized stringQueue and timingQueue
    }

}
