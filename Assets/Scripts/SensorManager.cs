using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SensorManager : MonoBehaviour
{
    const int sensorNum = 16;
    // array
    public GameObject[] sensor;
    LightSensor2[] sensorScript = new LightSensor2[sensorNum];

    private StreamWriter sw;
    GameObject SaveCsvObj;
    SaveCsv SaveCsvScript;

    float[] lightValue = new float[sensorNum];
    float intervalTime = 1f;
    float elapsedTime = 0;
    float time = 0;
    public int saveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sensorNum; i++)
        {
            sensorScript[i] = sensor[i].GetComponent<LightSensor2>();
        }

        SaveCsvObj = GameObject.Find("SensorManager");
        SaveCsvScript = SaveCsvObj.GetComponent<SaveCsv>();
        
        Application.targetFrameRate = 10; //FPSを10に設定
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sensorNum; i++)
        {
            lightValue[i] = sensorScript[i].lightValue;
        }

        // 経過時間を計測
        elapsedTime += Time.deltaTime;
        time += Time.deltaTime;
        // 前回の命令から1秒以上経過した場合
        // intervalTime < elapsedTime
        /*
        if (intervalTime < elapsedTime)
        {
            //Debug.Log("前回の命令から1秒以上経過した場合 start");
            //Debug.Log(this.gameObject.name);
            SaveCsvScript.SaveData(lightValue[0].ToString(), lightValue[1].ToString(), lightValue[2].ToString(), lightValue[3].ToString(), lightValue[4].ToString(), lightValue[5].ToString(), lightValue[6].ToString(), lightValue[7].ToString(), lightValue[8].ToString(), lightValue[9].ToString(),
                                    lightValue[10].ToString(), lightValue[11].ToString(), lightValue[12].ToString(), lightValue[13].ToString(), lightValue[14].ToString(), lightValue[15].ToString(), lightValue[16].ToString(), lightValue[17].ToString(), lightValue[18].ToString(), lightValue[19].ToString(),
                                    lightValue[20].ToString(), lightValue[21].ToString(), lightValue[22].ToString(), lightValue[23].ToString(), lightValue[24].ToString(), lightValue[25].ToString(), lightValue[26].ToString(), lightValue[27].ToString(), lightValue[28].ToString(), lightValue[29].ToString(),
                                    lightValue[30].ToString(), lightValue[31].ToString(), lightValue[32].ToString(), lightValue[33].ToString(), lightValue[34].ToString(), lightValue[35].ToString(), lightValue[36].ToString(), lightValue[37].ToString(), lightValue[38].ToString(), lightValue[39].ToString(),
                                    lightValue[40].ToString(), lightValue[41].ToString(), lightValue[42].ToString(), lightValue[43].ToString(), lightValue[44].ToString(), lightValue[45].ToString(), lightValue[46].ToString(), lightValue[47].ToString(), lightValue[48].ToString(), lightValue[49].ToString(),
                                    lightValue[50].ToString(), lightValue[51].ToString(), lightValue[52].ToString(), lightValue[53].ToString(), lightValue[54].ToString(), lightValue[55].ToString(), lightValue[56].ToString(), lightValue[57].ToString(), lightValue[58].ToString(), lightValue[59].ToString(),
                                    lightValue[60].ToString(), lightValue[61].ToString(), lightValue[62].ToString(), lightValue[63].ToString(), lightValue[64].ToString(), lightValue[65].ToString(), lightValue[66].ToString(), lightValue[67].ToString(), lightValue[68].ToString(), lightValue[69].ToString(),
                                    lightValue[70].ToString(), lightValue[71].ToString(), lightValue[72].ToString(), lightValue[73].ToString(), lightValue[74].ToString(), lightValue[75].ToString(), lightValue[76].ToString(), lightValue[77].ToString(), lightValue[78].ToString(), lightValue[79].ToString(), time.ToString());
            elapsedTime = 0.0f;
            Debug.Log("SensorManager SaveData()");
        }
        */
        /*
        SaveCsvScript.SaveData(lightValue[0].ToString(), lightValue[1].ToString(), lightValue[2].ToString(), lightValue[3].ToString(), lightValue[4].ToString(), lightValue[5].ToString(), lightValue[6].ToString(), lightValue[7].ToString(), lightValue[8].ToString(), lightValue[9].ToString(),
                                    lightValue[10].ToString(), lightValue[11].ToString(), lightValue[12].ToString(), lightValue[13].ToString(), lightValue[14].ToString(), lightValue[15].ToString(), lightValue[16].ToString(), lightValue[17].ToString(), lightValue[18].ToString(), lightValue[19].ToString(),
                                    lightValue[20].ToString(), lightValue[21].ToString(), lightValue[22].ToString(), lightValue[23].ToString(), lightValue[24].ToString(), lightValue[25].ToString(), lightValue[26].ToString(), lightValue[27].ToString(), lightValue[28].ToString(), lightValue[29].ToString(),
                                    lightValue[30].ToString(), lightValue[31].ToString(), lightValue[32].ToString(), lightValue[33].ToString(), lightValue[34].ToString(), lightValue[35].ToString(), lightValue[36].ToString(), lightValue[37].ToString(), lightValue[38].ToString(), lightValue[39].ToString(),
                                    lightValue[40].ToString(), lightValue[41].ToString(), lightValue[42].ToString(), lightValue[43].ToString(), lightValue[44].ToString(), lightValue[45].ToString(), lightValue[46].ToString(), lightValue[47].ToString(), lightValue[48].ToString(), lightValue[49].ToString(),
                                    lightValue[50].ToString(), lightValue[51].ToString(), lightValue[52].ToString(), lightValue[53].ToString(), lightValue[54].ToString(), lightValue[55].ToString(), lightValue[56].ToString(), lightValue[57].ToString(), lightValue[58].ToString(), lightValue[59].ToString(),
                                    lightValue[60].ToString(), lightValue[61].ToString(), lightValue[62].ToString(), lightValue[63].ToString(), lightValue[64].ToString(), lightValue[65].ToString(), lightValue[66].ToString(), lightValue[67].ToString(), lightValue[68].ToString(), lightValue[69].ToString(),
                                    lightValue[70].ToString(), lightValue[71].ToString(), lightValue[72].ToString(), lightValue[73].ToString(), lightValue[74].ToString(), lightValue[75].ToString(), lightValue[76].ToString(), lightValue[77].ToString(), lightValue[78].ToString(), lightValue[79].ToString(), time.ToString());
        */
        // 最初の2フレームは値0だから入れないようにしている
        if (saveCount > 1) { 
            SaveCsvScript.SaveData(lightValue[0].ToString(), lightValue[1].ToString(), lightValue[2].ToString(), lightValue[3].ToString(), lightValue[4].ToString(), lightValue[5].ToString(), lightValue[6].ToString(), lightValue[7].ToString(), lightValue[8].ToString(), lightValue[9].ToString(),
                                        lightValue[10].ToString(), lightValue[11].ToString(), time.ToString());
        }
        saveCount++;
    }
}
