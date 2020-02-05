using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Scripts
{
    public class StopwatchScript : MonoBehaviour
    {

        public Text stopwatchText;
        
        private Stopwatch stopwatch = new Stopwatch();

        public void Start()
        { 
            stopwatch.Start();
        }
        
        public void Update()
        {
            int mins = stopwatch.Elapsed.Minutes;
            int seconds = stopwatch.Elapsed.Seconds;
            int milliseconds = stopwatch.Elapsed.Milliseconds;
             
            stopwatchText.text = fixedLengthInt(mins, 2) + ":" + fixedLengthInt(seconds, 2) + ":" + fixedLengthInt(milliseconds, 2);
        }

        private string fixedLengthInt(int value, int length)
        {
            var result = "" + value;

            if (result.Length < length)
            {
                while (result.Length < length)
                {
                    result = "0" + result;
                }

                return result;
            }
            else
            {
                return result.Substring(0, length);
            }
        } 
    }
}