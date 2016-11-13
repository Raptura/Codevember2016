using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public partial class TextManager : MonoBehaviour
{
    private int cursor = 0;
    public int output { get; private set; }
    //Menu Mode
    public void setupMenu(string[] options)
    {
        StartCoroutine(runMenu(options));
    }

    public IEnumerator runMenu(string[] options)
    {
        while (mode != ManagerMode.Standby) { yield return null; }
        mode = ManagerMode.Menu;

        bool chosen = false;
        while (!chosen)
        {
            cursor = 0;

            //Print The Menu w/ Cursor
            printMenu(options, cursor);

            if (Input.GetKey(KeyCode.W))
            {
                cursor = (cursor - 1 >= 0 ? cursor - 1 : options.Length);
                yield return new WaitForSeconds(0.1f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                cursor = (cursor + 1 < options.Length ? cursor + 1 : 0);
                yield return new WaitForSeconds(0.1f);
            }
            if (Input.GetKey(KeyCode.Return))
            {
                chosen = true;
            }
        }
        output = cursor;
        mode = ManagerMode.Standby;
    }

    public void printMenu(string[] options, int cursor)
    {
        resetText(); //Clear the text first, then draw the new text w/ updated Cursor
        for (int i = 0; i < options.Length; i++)
        {
            string line = (i == cursor ? ">" : "");
            line += options[i];
            textToDisplay += line + "\n";
        }
    }


}
