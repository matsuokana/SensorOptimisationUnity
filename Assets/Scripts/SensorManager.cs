using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using XCharts;
using System.Threading;


public class SensorManager : MonoBehaviour
{
    private int sensorsNum;
    // array
    public GameObject[] sensor;
    public GameObject[] sensorObject;
    LightSensor2[] sensorScript;

    //private StreamWriter sw;
    public GameObject SaveCsvObj;
    public SaveCsv SaveCsvScript;

    // センサの位置記録用の変数
    public StreamWriter swTXT;
    private string positions;
    public float a_x;
    public float a_y;

    RayHit rayHit;
    float[] lightValue;

    // GAの処理用
    private string preTextfromPython = "";
    private string preImageFilePath_cm = "";

    float time = 0;
    public int saveCount = 0;
    public int motionCount = 0;
    private int motionType = 0;
    public bool OpenFile = true;
    public bool SaveData = false;
    public bool isTrain = true;
    public bool isTest = false;
    public bool isChangeLabel = true;
    public bool isReceive = true;
    public bool isOnetime = true;
    public bool isSVM = false;
    public bool isGA = false;
    public bool isSVM_file = false;
    public bool isGA_file = false;
    public bool isLearn = false;
    public bool FPS = true;
    public bool TPS = false;

    private string loop = "Loop1";
    public int loopNum = 1;

    // broadcast address
    public string host = "127.0.0.1";
    public int port = 8000;
    private UdpClient client;

    static UdpClient udp;
    //IPEndPoint remoteEP = null;

    //Panelを格納する変数
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject meunPanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] Text resutText;
    [SerializeField] GameObject closeBtn;
    [SerializeField] GameObject tpsBtn;
    [SerializeField] GameObject thirdCamera;
    [SerializeField] Image resultImage_cm;
    [SerializeField] Image resultImage_fi;
    // BarChart本体
    [SerializeField] GameObject Barchart_g;
    [SerializeField] Text viewButtonText;
    [SerializeField] Text EvaluationScore;
    //BarChartコンポーネント
    private BarChart barchart;
    //[SerializeField] Image img;

    // Update is called once per frame
    void Update() {

        if (motionCount < 120) {
            // sensorの値を配列に格納
            for (int i = 0; i < sensorsNum; i++) {
                lightValue[i] = sensorScript[i].lightValue;
            }
            
            // 経過時間を計測
            //elapsedTime += Time.deltaTime;
            //time += Time.deltaTime;

            if (OpenFile) {
                if (isTrain) {
                    SaveCsvScript.OpenCSV("Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv", sensorsNum);
                    //UnityEngine.Debug.Log("isTrain");
                }
                else if (isTest) {
                    SaveCsvScript.OpenCSV("Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv", sensorsNum);
                }
                OpenFile = false;
            }

            if (isChangeLabel) {
                if (motionCount == 10 || motionCount == 20 || motionCount == 30 || motionCount == 40 || motionCount == 50) {
                    motionType++;
                }
                else if (motionCount == 70 || motionCount == 80 || motionCount == 90 || motionCount == 100 || motionCount == 110) {
                    motionType++;
                }
                isChangeLabel = false;
            }

            saveCount++;
            if (saveCount == 3) {
                SaveCsvScript.SaveData(lightValue, motionType.ToString(), sensorsNum);
                UnityEngine.Debug.Log("SaveCsvSaveCsvScript.SaveData()");
                barchart.series.list[0].data.Clear();
                for (int i = 0; i < sensorsNum; i++) {
                    // グラフへの反映
                    SerieData addData = new SerieData();
                    addData.data = new List<double> { i, lightValue[i] };
                    barchart.series.list[0].data.Add(addData);
                }
                // 正規
                Barchart_g.SetActive(false);
                Barchart_g.SetActive(true);
                // Xxharts
            }
            // 最初の2フレームは値0だから入れないようにしている
            if (saveCount > 10) {
                //SaveCsvScript.SaveData(lightValue, motionType.ToString(), sensorsNum);
                saveCount = 0;
                //time = 0;
                motionCount++;
                isChangeLabel = true;
                UnityEngine.Debug.Log(motionCount);

                if (motionCount == 60) {
                    motionType = 0;
                    isTrain = false;
                    OpenFile = true;
                    isTest = true;
                    SaveCsvScript.sw.Close();
                    UnityEngine.Debug.Log("SaveCsv sw.Close()");
                }

                //　データ取得実行終了
                if (motionCount == 120) {
                    // SVM実行
                    //client = new UdpClient();
                    //client.Connect(host, port);
                    //byte[] dgram = Encoding.UTF8.GetBytes("C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/cm.png" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/result.txt" + "," + sensorsNum.ToString());
                    //client.Send(dgram, dgram.Length);

                    //GA実行
                    //client = new UdpClient();
                    //client.Connect(host, port);
                    //byte[] dgram = Encoding.UTF8.GetBytes("C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "," + sensorsNum.ToString());
                    //client.Send(dgram, dgram.Length);

                    motionType = 0;
                    isTrain = true;
                    isTest = false;
                    SaveCsvScript.sw.Close();
                    UnityEngine.Debug.Log("SaveCsv sw.Close()");

                    GameObject human = GameObject.Find("Human");
                    human.transform.position = new Vector3(0.45f, -1.0f, 9.5f);
                    MotionController motionController = human.GetComponent<MotionController>();
                    motionController.enabled = false;
                    FPSCameraController fPSCameraController = human.GetComponent<FPSCameraController>();
                    fPSCameraController.enabled = true;
                    //fPSCameraController.cursorLock = true;
                    fPSCameraController.ThirdCamera.transform.position = new Vector3(0.36f, 1.75f, 8.82f);
                    fPSCameraController.ThirdCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    fPSCameraController.FirstCamera.SetActive(true);
                    fPSCameraController.ThirdCamera.SetActive(false);
                    fPSCameraController.FirstCamera.transform.localPosition = new Vector3(0.05194804f, 1.62f, 0.03f);
                    fPSCameraController.FirstCamera.transform.rotation = Quaternion.Euler(180f, 180f, 180f);
                    fPSCameraController.enabled = false;
                    resultPanel.SetActive(true);
                    TPS = false;
                    FPS = true;
                    tpsBtn.SetActive(false);
                    Barchart_g.SetActive(false);
                }
            }
        }
        else if (isReceive) {
            if (isSVM) {
                GameObject stepString = GameObject.Find("Text_explain");
                stepString.GetComponent<UnityEngine.UI.Text>().text = "In calculation";
                resutText.text = "In calculation";
                client = new UdpClient();
                client.Connect(host, port);
                byte[] dgram = Encoding.UTF8.GetBytes("C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/cm.png" + "," +"C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/FI.png" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/result.txt" + "," + sensorsNum.ToString() + "," + "SVM");
                client.Send(dgram, dgram.Length);
                isSVM = false;
                isLearn = true;
            }
            else if (isGA) {
                GameObject stepString = GameObject.Find("Text_explain");
                stepString.GetComponent<UnityEngine.UI.Text>().text = "In calculation";
                resutText.text = "In calculation";
                client = new UdpClient();
                client.Connect(host, port);
                byte[] dgram = Encoding.UTF8.GetBytes("C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "," + sensorsNum.ToString() + "," + "GA");
                client.Send(dgram, dgram.Length);
                isGA = false;
                isLearn = true;
            }

            if (isLearn) {
                IPEndPoint remoteEP = null;
                byte[] data = udp.Receive(ref remoteEP);
                string textFromPython = Encoding.UTF8.GetString(data);

                if (textFromPython != null) {
                    resultPanel.SetActive(true);
                    //UnityEngine.Debug.Log(textFromPython);
                    isReceive = false;
                    isLearn = false;
                    string ImageFilePath_cm;
                    string ImageFilePath_fi;
                    if (isSVM_file) {
                        UnityEngine.Debug.Log(textFromPython);
                        ImageFilePath_cm = "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/cm.png";
                        ImageFilePath_fi = "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/FI.png";
                        //GameObject image_object_cm = GameObject.Find("Image_cm");
                        Image img_cm = resultImage_cm.GetComponent<Image>();
                        Texture2D texture2D = new Texture2D(2, 2);
                        texture2D.LoadImage(System.IO.File.ReadAllBytes(ImageFilePath_cm));
                        img_cm.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), 0.5f * Vector2.one);
                        //img_cm.material.mainTexture = readByBinary(readPngFile(ImageFilePath_cm));

                        //GameObject image_object_fi = GameObject.Find("Image_fi");
                        Image img_fi = resultImage_fi.GetComponent<Image>();
                        Texture2D texture2D_fi = new Texture2D(2, 2);
                        texture2D_fi.LoadImage(System.IO.File.ReadAllBytes(ImageFilePath_fi));
                        img_fi.sprite = Sprite.Create(texture2D_fi, new Rect(0, 0, texture2D_fi.width, texture2D_fi.height), 0.5f * Vector2.one);
                        //img_fi.material.mainTexture = readByBinary(readPngFile(ImageFilePath_fi));

                        resultImage_cm.color = new Color32(255, 255, 255, 255);
                        resultImage_fi.color = new Color32(255, 255, 255, 255);

                        // 評価式のスコアの計算
                        resutText.text = textFromPython;
                        string[] str = textFromPython.Split(':', ' ');
                        //UnityEngine.Debug.Log(str.Length);
                        //UnityEngine.Debug.Log(str[5]);
                        UnityEngine.Debug.Log(double.Parse(str[5]));
                        UnityEngine.Debug.Log(((439 - rayHit.list_sensors.Count) / 439.0));
                        UnityEngine.Debug.Log((double.Parse(str[5]) + ((493 - rayHit.list_sensors.Count) / 493.0)) / 2.0);
                        double evaScore = (double.Parse(str[5]) + ((493 - rayHit.list_sensors.Count) / 493.0)) / 2.0;
                        EvaluationScore.text = evaScore.ToString();

                        isSVM_file = false;
                    }
                    else if (isGA_file) {
                        char[] delimiterChars = {',', '[', ']'};
                        string[] words = textFromPython.Split(delimiterChars);
                        string[] results = words[0].Split('_', '.');
                        UnityEngine.Debug.Log(words[0]);

                        if (textFromPython.Equals(preTextfromPython)) {
                            ImageFilePath_cm = preImageFilePath_cm;
                            Image img_cm = resultImage_cm.GetComponent<Image>();
                            Texture2D texture2D = new Texture2D(2, 2);
                            texture2D.LoadImage(System.IO.File.ReadAllBytes(ImageFilePath_cm));
                            img_cm.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), 0.5f * Vector2.one);

                            Image img_fi = resultImage_fi.GetComponent<Image>();
                            Texture2D texture2D_fi = new Texture2D(2, 2);
                            //texture2D_fi.LoadImage(System.IO.File.ReadAllBytes(ImageFilePath_fi));
                            //img_fi.sprite = Sprite.Create(texture2D_fi, new Rect(0, 0, texture2D_fi.width, texture2D_fi.height), 0.5f * Vector2.one);

                            resultImage_cm.color = new Color32(255, 255, 255, 255);
                            resultImage_fi.color = new Color32(255, 255, 255, 255);
                            //resutText.text = words[0];
                            resutText.text = "Number of sensors: " + results[1] + ", Identification rate for test data： " + results[2] + "." + results[3];

                            isGA_file = false;
                            
                            UnityEngine.Debug.Log(rayHit.list_sensors.Count);
                            // 評価式のスコアの計算
                            UnityEngine.Debug.Log(((439 - rayHit.list_sensors.Count) / 439.0));
                            UnityEngine.Debug.Log((double.Parse(results[2] + "." + results[3]) + ((493 - rayHit.list_sensors.Count) / 493.0)) / 2.0);
                            double evaScore = (double.Parse(results[2] + "." + results[3]) + ((493 - rayHit.list_sensors.Count) / 493.0)) / 2.0;
                            EvaluationScore.text = evaScore.ToString();

                            loop = "Loop" + loopNum.ToString();
                            MakeTxt("Sensor Data/" + loop + "/SensorsPosition_GA.txt");
                            // GAのセンサ位置の書き出し
                            for (int i = 0; i < rayHit.list_sensors.Count; i++) {
                                // センサ位置の書き出し
                                a_x = 2.7f * Mathf.Abs(1.87f - rayHit.list_sensors[i].transform.position.x) / 2.44f;
                                a_y = 1.82f * Mathf.Abs(1.32f - rayHit.list_sensors[i].transform.position.y) / 1.58f;
                                positions = "sensor" + (i + 1).ToString() + " x: " + a_x.ToString("N2") + ", y: " + a_y.ToString("N2");
                                swTXT.WriteLine(positions);
                            }
                            swTXT.Close();
                        } else {
                            ImageFilePath_cm = "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v7/Sensor Data/" + loop + "/GAresults/GA_keras/heatmap/virtual/" + words[0];
                            preTextfromPython = textFromPython;
                            preImageFilePath_cm = ImageFilePath_cm;

                            Image img_cm = resultImage_cm.GetComponent<Image>();
                            Texture2D texture2D = new Texture2D(2, 2);
                            texture2D.LoadImage(System.IO.File.ReadAllBytes(ImageFilePath_cm));
                            img_cm.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), 0.5f * Vector2.one);

                            Image img_fi = resultImage_fi.GetComponent<Image>();
                            Texture2D texture2D_fi = new Texture2D(2, 2);
                            //texture2D_fi.LoadImage(System.IO.File.ReadAllBytes(ImageFilePath_fi));
                            //img_fi.sprite = Sprite.Create(texture2D_fi, new Rect(0, 0, texture2D_fi.width, texture2D_fi.height), 0.5f * Vector2.one);

                            resultImage_cm.color = new Color32(255, 255, 255, 255);
                            resultImage_fi.color = new Color32(255, 255, 255, 255);
                            //resutText.text = words[0];
                            resutText.text = "Number of sensors: " + results[1] + ", Identification rate for test data： " + results[2] + "." + results[3];

                            isGA_file = false;
                            UnityEngine.Debug.Log(string.Join(",", words));
                            UnityEngine.Debug.Log(words.Length);
                            for (int i = 0; i < words.Length - 1; i++) {
                                if (i > 1) {
                                    //UnityEngine.Debug.Log(words[i]);
                                    if (Int32.Parse(words[i]) == 0) {
                                        Destroy(rayHit.list_sensors[i - 2]);
                                    }
                                    //rayHit.list_sensors.RemoveAt(Int32.Parse(words[i]));
                                }
                            }
                            UnityEngine.Debug.Log(rayHit.list_sensors.Count);
                            rayHit.sensorsNumber = rayHit.list_sensors.Count;
                            int j = 0;
                            for (int i = 0; i < words.Length - 1; i++) {
                                if (i > 1) {
                                    //UnityEngine.Debug.Log(words[i]);
                                    //Destroy(rayHit.list_sensors[Int32.Parse(words[i])]);
                                    //rayHit.list_sensors.RemoveAt(Int32.Parse(words[i]));
                                    if (Int32.Parse(words[i]) == 0) {
                                        rayHit.list_sensors.RemoveAt(i - 2 - j);
                                        j++;
                                    }
                                }
                            }
                            //Destroy(rayHit.list_sensors[rayHit.list_sensors.Count - 1]);
                            //rayHit.list_sensors.RemoveAt(rayHit.list_sensors.Count - 1);
                            //rayHit.list_sensors.RemoveAll(s => s == null);
                            UnityEngine.Debug.Log(rayHit.list_sensors.Count);
                            // 評価式のスコアの計算
                            UnityEngine.Debug.Log(((439 - rayHit.list_sensors.Count) / 439.0));
                            UnityEngine.Debug.Log((double.Parse(results[2] + "." + results[3]) + ((493 - rayHit.list_sensors.Count) / 493.0)) / 2.0);
                            double evaScore = (double.Parse(results[2] + "." + results[3]) + ((493 - rayHit.list_sensors.Count) / 493.0)) / 2.0;
                            EvaluationScore.text = evaScore.ToString();

                            loop = "Loop" + loopNum.ToString();
                            MakeTxt("Sensor Data/" + loop + "/SensorsPosition_GA.txt");
                            // GAのセンサ位置の書き出し
                            for (int i = 0; i < rayHit.list_sensors.Count; i++) {
                                // センサ位置の書き出し
                                a_x = 2.7f * Mathf.Abs(1.87f - rayHit.list_sensors[i].transform.position.x) / 2.44f;
                                a_y = 1.82f * Mathf.Abs(1.32f - rayHit.list_sensors[i].transform.position.y) / 1.58f;
                                positions = "sensor" + (i + 1).ToString() + " x: " + a_x.ToString("N2") + ", y: " + a_y.ToString("N2");
                                swTXT.WriteLine(positions);
                            }
                            swTXT.Close();
                        }

                        
                    }
                    
                }
            }
        }
        
    }  

    public void Click() {
        motionCount = 0;
        
        GameObject SensorManagerObj = GameObject.Find("SensorManager");
        SensorManager SensorManagerScript = SensorManagerObj.GetComponent<SensorManager>();
        SensorManagerScript.enabled = true;

        // OwnStart()
        OpenFile = true;
        isReceive = true;
        GameObject human = GameObject.Find("Human");
        Vector3 pos = human.transform.position;
        pos.x = 0.45f;
        pos.y = -1.0f;
        pos.z = 9.5f;
        human.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

        rayHit = human.GetComponent<RayHit>();
        // RayHis.csから移植
        rayHit.isPut = false;
        rayHit.isLight = false;
        rayHit.isSensor = false;
        //rayHit.swTXT.Close();
        // end
        loop = "Loop" + loopNum.ToString();
        MakeTxt("Sensor Data/" + loop + "/SensorsPosition.txt");

        sensorsNum = rayHit.list_sensors.Count;
        UnityEngine.Debug.Log(rayHit.list_sensors.Count.ToString());
        sensorScript = new LightSensor2[sensorsNum];
        lightValue = new float[sensorsNum];
        for (int i = 0; i < rayHit.list_sensors.Count; i++) {
            sensorScript[i] = rayHit.list_sensors[i].transform.GetChild(1).GetComponent<Camera>().GetComponent<LightSensor2>();
            //Camera camera = rayHit.list_sensors[i].transform.GetChild(1).GetComponent<Camera>();
            //Debug.Log(camera);
            //Debug.Log(sensorScript[i]);

            // センサ位置の書き出し
            a_x = 2.7f * Mathf.Abs(1.87f - rayHit.list_sensors[i].transform.position.x) / 2.44f;
            a_y = 1.82f * Mathf.Abs(1.32f - rayHit.list_sensors[i].transform.position.y) / 1.58f;
            positions = "sensor" + (i+1).ToString() + " x: " + a_x.ToString("N2") + ", y: " + a_y.ToString("N2");
            swTXT.WriteLine(positions);
        }
        swTXT.Close();

        FPSCameraController fPSCameraController = human.GetComponent<FPSCameraController>();
        fPSCameraController.cursorLock = false;
        fPSCameraController.UpdateCursorLock();
        fPSCameraController.FirstCamera.SetActive(false);
        fPSCameraController.ThirdCamera.SetActive(true);
        fPSCameraController.ThirdCamera.transform.position = new Vector3(0.36f, 0.07f, 9.63f);
        fPSCameraController.ThirdCamera.transform.rotation = Quaternion.Euler(-10f, 180f, 0f);
        fPSCameraController.enabled = false;

        SaveCsvObj = GameObject.Find("SensorManager");
        SaveCsvScript = SaveCsvObj.GetComponent<SaveCsv>();

        Application.targetFrameRate = 5; //FPSを5に設定
        // end

        //this.gameObject.SetActive(true);

        //GameObject human = GameObject.Find("Human");
        MotionController motionController = human.GetComponent<MotionController>();
        motionController.enabled = true;
        //motionController._animator.SetBool("isRestart", true);

        UnityEngine.Debug.Log("sensormanager and human active");

        GameObject stepString = GameObject.Find("Text_explain");
        stepString.GetComponent<UnityEngine.UI.Text>().text = "Measurement step";

        // 正規　Xchart
        Barchart_g.SetActive(true);

        // receive
        if (isOnetime) {
            int LOCA_LPORT = 50007;
            udp = new UdpClient(LOCA_LPORT);
            udp.Client.ReceiveTimeout = 10000;
            isOnetime = false;

            // graphの設定
            barchart = Barchart_g.GetComponent<BarChart>();
            barchart.title.show = true;
            barchart.title.textStyle.fontSize = 15;
            barchart.title.text = "Sensor values";
            barchart.yAxis0.type = Axis.AxisType.Value;
            barchart.yAxis0.minMaxType = Axis.AxisMinMaxType.Custom;
            barchart.yAxis0.min = 0.0;
            barchart.yAxis0.max = 0.8;      
        }
        List<string> s1 = new List<string>();
        for (int i = 0; i < sensorsNum; i++) {
            s1.Add((i + 1).ToString());
        }
        barchart.xAxis0.data = s1;
        barchart.series.list[0].data.Clear();

        meunPanel.SetActive(false);
        closeBtn.SetActive(false);
        tpsBtn.SetActive(true);

        resultImage_cm.color = new Color32(255, 255, 255, 0);
        resultImage_fi.color = new Color32(255, 255, 255, 0);
    }

    public void Click_panelClose() {
        resultPanel.SetActive(false);
        
        loopNum++;
        loop = "Loop" + loopNum.ToString();
        MakeFiles(loop);

        int numbers = 1;
        foreach (GameObject sensor in rayHit.list_sensors) {
            sensor.GetComponentInChildren<Text>().text = numbers.ToString();
            numbers++;
        }

        //rayHit.sensorsNumber = 0;
        rayHit.sensorsNumber = rayHit.list_sensors.Count;
        rayHit.isPut = true;
        //MakeTxt("Sensor Data/" + loop + "/SensorsPosition.txt");
        GameObject stepString = GameObject.Find("Text_explain");
        stepString.GetComponent<UnityEngine.UI.Text>().text = "Install step";
        meunPanel.SetActive(true);
        closeBtn.SetActive(true);
    }

    public void Click_SVM() {
        // SVM実行
        //resutText.text = "In calculation";
        //client = new UdpClient();
        //client.Connect(host, port);
        //byte[] dgram = Encoding.UTF8.GetBytes("C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/cm.png" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/result.txt" + "," + sensorsNum.ToString() + "," + "SVM");
        //client.Send(dgram, dgram.Length);
        isReceive = true;
        isSVM = true;
        isSVM_file = true;
        resultPanel.SetActive(false);
    }

    public void Click_GA() {
        //GA実行
        //resutText.text = "In calculation";
        //client = new UdpClient();
        //client.Connect(host, port);
        //byte[] dgram = Encoding.UTF8.GetBytes("C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_train.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "/CSV/SaveData_matsuo_5fps_" + sensorsNum.ToString() + "sensors_test.csv" + "," + "C:/Users/tuoka/Unity_projects/Sensor optimisation proj_v5/Sensor Data/" + loop + "," + sensorsNum.ToString() + "," + "GA");
        //client.Send(dgram, dgram.Length);
        isReceive = true;
        isGA = true;
        isGA_file = true;
        resultPanel.SetActive(false);
    }
    
    public void Click_cameraChange() {
        if (FPS) {
            thirdCamera.transform.position = new Vector3(0.36f, 0.87f, 10.91f);
            thirdCamera.transform.rotation = Quaternion.Euler(20f, 180f, 0f);
            TPS = true;
            FPS = false;
            viewButtonText.text = "Change view\n(3PV)";
        }
        else if (TPS) {
            thirdCamera.transform.position = new Vector3(0.36f, 0.07f, 9.63f);
            thirdCamera.transform.rotation = Quaternion.Euler(-10f, 180f, 0f);
            TPS = false;
            FPS = true;
            viewButtonText.text = "Change view\n(FPV)";
        }
    }

    public void MakeFiles(string loop) {
        var HomePath = "Sensor Data";
        if (System.IO.Directory.Exists(HomePath)) {
            if (System.IO.Directory.Exists(HomePath + "/" + loop)) {
                if (!System.IO.Directory.Exists(HomePath + "/" + loop + "/" + "CSV")) {
                    System.IO.Directory.CreateDirectory(HomePath + "/" + loop + "/" + "CSV");
                }
            } else {
                System.IO.Directory.CreateDirectory(HomePath + "/" + loop);
                System.IO.Directory.CreateDirectory(HomePath + "/" + loop + "/" + "CSV");
            }
        } else {
            //ディレクトリ作成
            System.IO.Directory.CreateDirectory(HomePath);
            System.IO.Directory.CreateDirectory(HomePath + "/" + loop);
            System.IO.Directory.CreateDirectory(HomePath + "/" + loop + "/" + "CSV");
        }
    }

    public byte[] readPngFile(string path) {
        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
            BinaryReader bin = new BinaryReader(fileStream);
            byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
            bin.Close();
            return values;
        }
    }
    public Texture2D readByBinary(byte[] bytes) {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }

    public void MakeTxt(string loop) {
        swTXT = File.CreateText(loop);
    }

}
