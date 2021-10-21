using UnityEngine;
using TMPro;
public class StopWatch : MonoBehaviour
{
    private TMP_Text textOut;
    public static float timeNum;
    public bool isRunning = true;
    public string output;

    void Start()
    {
        textOut = GameObject.Find("Time").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (!isRunning)
        {
            timeNum = 0.0F;
            isRunning = true;
        }
        if (isRunning)
        {
            timeNum += Time.deltaTime;
            string minute = Mathf.Floor((timeNum % 3600) / 60).ToString("00");
            string second = (timeNum % 60).ToString("00");
            output = minute + ":" + second;
            textOut.text = output;
        }

    }
}
