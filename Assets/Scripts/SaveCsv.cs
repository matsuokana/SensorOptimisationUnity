using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveCsv : MonoBehaviour
{
    float intervalTime = 6f;
    float elapsedTime = 0;
    private StreamWriter sw;

    GameObject SensorManagerObj;
    SensorManager SensorManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        SensorManagerObj = GameObject.Find("SensorManager");
        SensorManagerScript = SensorManagerObj.GetComponent<SensorManager>();

        sw = new StreamWriter(@"SaveData_matsuo_turnHandRight_10fps_12sensors.csv", true, Encoding.GetEncoding("Shift_JIS"));
        /*
        string[] s1 = { "sensor1", "sensor2", "sensor3", "sensor4", "sensor5", "sensor6", "sensor7", "sensor8", "sensor9", "sensor10",
                        "sensor11", "sensor12", "sensor13", "sensor14", "sensor15", "sensor16", "sensor17", "sensor18", "sensor19", "sensor20",
                        "sensor21", "sensor22", "sensor23", "sensor24", "sensor25", "sensor26", "sensor27", "sensor28", "sensor29", "sensor30",
                        "sensor31", "sensor32", "sensor33", "sensor34", "sensor35", "sensor36", "sensor37", "sensor38", "sensor39", "sensor40",
                        "sensor41", "sensor42", "sensor43", "sensor44", "sensor45", "sensor46", "sensor47", "sensor48", "sensor49", "sensor50",
                        "sensor51", "sensor52", "sensor53", "sensor54", "sensor55", "sensor56", "sensor57", "sensor58", "sensor59", "sensor60",
                        "sensor61", "sensor62", "sensor63", "sensor64", "sensor65", "sensor66", "sensor67", "sensor68", "sensor69", "sensor70",
                        "sensor71", "sensor72", "sensor73", "sensor74", "sensor75", "sensor76", "sensor77", "sensor78", "sensor79", "sensor80","time" };
        */
        string[] s1 = { "sensor1", "sensor2", "sensor3", "sensor4", "sensor5", "sensor6", "sensor7", "sensor8", "sensor9", "sensor10",
                        "sensor11", "sensor12","time" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        Debug.Log("SaveCsv start()");
    }

    /*
    public void SaveData(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9, string txt10,
                        string txt11, string txt12, string txt13, string txt14, string txt15, string txt16, string txt17, string txt18, string txt19, string txt20,
                        string txt21, string txt22, string txt23, string txt24, string txt25, string txt26, string txt27, string txt28, string txt29, string txt30,
                        string txt31, string txt32, string txt33, string txt34, string txt35, string txt36, string txt37, string txt38, string txt39, string txt40,
                        string txt41, string txt42, string txt43, string txt44, string txt45, string txt46, string txt47, string txt48, string txt49, string txt50,
                        string txt51, string txt52, string txt53, string txt54, string txt55, string txt56, string txt57, string txt58, string txt59, string txt60,
                        string txt61, string txt62, string txt63, string txt64, string txt65, string txt66, string txt67, string txt68, string txt69, string txt70,
                        string txt71, string txt72, string txt73, string txt74, string txt75, string txt76, string txt77, string txt78, string txt79, string txt80, string time)
    {
        string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10,
                        txt11, txt12, txt13, txt14, txt15, txt16, txt17, txt18, txt19, txt20,
                        txt21, txt22, txt23, txt24, txt25, txt26, txt27, txt28, txt29, txt30,
                        txt31, txt32, txt33, txt34, txt35, txt36, txt37, txt38, txt39, txt40,
                        txt41, txt42, txt43, txt44, txt45, txt46, txt47, txt48, txt49, txt50,
                        txt51, txt52, txt53, txt54, txt55, txt56, txt57, txt58, txt59, txt60,
                        txt61, txt62, txt63, txt64, txt65, txt66, txt67, txt68, txt69, txt70,
                        txt71, txt72, txt73, txt74, txt75, txt76, txt77, txt78, txt79, txt80, time};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        Debug.Log("SaveCsv SaveData()");
    }
    */
    public void SaveData(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9, string txt10,
                        string txt11, string txt12, string time)
    {
        string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10,
                        txt11, txt12, time};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        Debug.Log("SaveCsv SaveData()");
    }
    // Update is called once per frame
    void Update()
    {
        // Enter key押したら終了
        /* 
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sw.Close();
            Debug.Log("SaveCsv sw.Close()");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        */

        /*
        // 経過時間を計測
        elapsedTime += Time.deltaTime;
        // 6秒以上経ったら終了
        if (intervalTime <= elapsedTime)
        {
            sw.Close();
            Debug.Log("SaveCsv sw.Close()");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        */

        // SensorManegerで2フレーム飛ばしている。60フレームにするため
        if (SensorManagerScript.saveCount > 61) {
            sw.Close();
            Debug.Log("SaveCsv sw.Close()");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
