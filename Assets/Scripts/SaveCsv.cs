using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveCsv : MonoBehaviour
{
    
    public StreamWriter sw;

    public void OpenCSV(string filename, int sensorsNum) {
        //sw = new StreamWriter(@"SaveData_matsuo_jump_10fps_12sensors.csv", true, Encoding.GetEncoding("Shift_JIS"));
        sw = new StreamWriter(filename, true, Encoding.GetEncoding("Shift_JIS"));

        string[] s1 = new string[sensorsNum+1];
        for (int i = 0; i < sensorsNum; i++) {
            s1[i] = "sensor" + (i+1).ToString();
        }
        s1[sensorsNum] = "label";
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        Debug.Log("SaveCsv start()");
    }

    public void SaveData(IEnumerable<float> enumerable, string label, int sensorsNum) {
        int i = 0;
        string[] s1 = new string[sensorsNum+1];
        foreach (float s in enumerable) {
            s1[i] = s.ToString();
            i++;
        }
        s1[i] = label;
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        Debug.Log("SaveCsv SaveData()");
    }
}
