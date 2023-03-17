using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Collections;

public class RayHit : MonoBehaviour
{
    //生成したObject(sensor)を持っておくためのList
    public List<GameObject> list_sensors = new List<GameObject>();
    public List<GameObject> list_lights = new List<GameObject>();

    public float a_x;
    public float a_y;
    public float u_x;
    public float u_y;

// 照準のImageをインスペクターから設定
[SerializeField]
    private Image aimPointImage;

    private GameObject cloneObject;

    //private RawImage cloneImage;
    //private RawImage rawImage;
    private RenderTexture renderTexture;
    private Camera renderTextureCamera;

    
    //public StreamWriter swTXT;
    //private string positions;
    public int sensorsNumber = 0;

    private string[] motionName = { "Jump", "Squat", "TiltBodyLeft", "TiltBodyRight", "TurnHandLeft", "TurnHandRight" };
    public string loop = "Loop1";

    public GameObject FirstCamera;
    public GameObject ThirdCamera;
    private GameObject cam;
    private GameObject clickedGameObject;

    public bool isPut = false;
    public bool isSensor = false;
    public bool isLight = false;
    public bool isEdit = false;
    public bool isGet = false;

    public FPSCameraController fPSCameraController;

    //Panelを格納する変数
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject menuPanel;
    public bool isPanelTrue = true;

    [SerializeField] GameObject editPanel;

    [SerializeField]
    Text buttonText = null;

    [SerializeField]
    Text editButtonText = null;

    [SerializeField]
    private Button closeBtn;

    [SerializeField]
    private Button deleteBtn;

    [SerializeField]
    private Button allDeleteBtn;

    [SerializeField]
    private Button editBtn;

    [SerializeField]
    GameObject human;

    private void Start() {
        MakeFiles(loop);
        //string filename = "sensor data/loop1/sensorsposition.txt";
        ////swtxt = file.createtext(filename);
        //maketxt(filename);
    }

    void Update() {
        // rayを飛ばすカメラの設定
        if (FirstCamera.activeInHierarchy) {
            cam = FirstCamera;
        }
        else if (ThirdCamera.activeInHierarchy) {
            cam = ThirdCamera;
        }

        // Rayを飛ばす（第1引数がRayの発射座標、第2引数がRayの向き）
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        // outパラメータ用に、Rayのヒット情報を取得するための変数を用意
        RaycastHit hitInfo;

        // シーンビューにRayを可視化するデバッグ（必要がなければ消してOK）
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 0.0f);

        //Rayのhit情報を取得する
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("ESC");
            closeBtn.onClick.Invoke();
        }
        if (isPut && Physics.Raycast(ray, out hitInfo, 30.0f)) {

            // Rayがhitしたオブジェクトのタグ名を取得
            //string hitTag = hitInfo.collider.tag;
            //Debug.Log(hitTag);
            
            // 照準を赤に変える
            aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            //Debug.Log("Install");
            // マウス左クリックしたらrayの交点にオブジェクト設置
            if (Input.GetMouseButtonDown(0) && isPut && !isEdit && !isGet) {
                if (isSensor) {
                    // CubeプレハブをGameObject型で取得
                    GameObject obj = (GameObject)Resources.Load("Cube_sensor16");
                    Quaternion q2 = Quaternion.Euler(90f, 0f, 0f);
                    cloneObject = Instantiate(obj, new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), q2);
                    renderTexture = new RenderTexture(256, 256, 24);
                    renderTextureCamera = cloneObject.transform.GetChild(1).GetComponent<Camera>();
                    renderTextureCamera.targetTexture = renderTexture;
                    //生成したインスタンスをリストで持っておく
                    list_sensors.Add(cloneObject);
                    // インスタンスのimageだけ移動
                    cloneObject.GetComponentInChildren<Text>().text = (sensorsNumber + 1).ToString();
                    //u_x = 160f * Mathf.Abs(1.87f - hitInfo.point.x) / 2.44f + 300;
                    //u_y = 110f * Mathf.Abs(1.32f - hitInfo.point.y) / 1.58f - 100;
                    u_x = (160f * 3f) * Mathf.Abs(1.87f - hitInfo.point.x) / 2.44f + 350;
                    u_y = (110f * 3f) * Mathf.Abs(1.32f - hitInfo.point.y) / 1.58f - 300;
                    //cloneObject.GetComponentInChildren<Image>().GetComponent<RectTransform>().anchoredPosition = new Vector2(100, 10);
                    cloneObject.GetComponentInChildren<Image>().GetComponent<RectTransform>().anchoredPosition = new Vector2(u_x, -u_y);

                    sensorsNumber++;
                    // 実世界におけるセンサの位置の導出
                    //a_x = 2.7f * Mathf.Abs(1.87f - hitInfo.point.x) / 2.44f;
                    //a_y = 1.82f * Mathf.Abs(1.32f - hitInfo.point.y) / 1.58f;
                    //positions = "sensor" + sensorsNumber.ToString() + " x: " + a_x.ToString("N2") + ", y: " + a_y.ToString("N2");
                    //swTXT.WriteLine(positions);
                }
                else if (isLight) {
                    // CubeプレハブをGameObject型で取得
                    GameObject obj = (GameObject)Resources.Load("Infrared light");
                    Quaternion q2 = Quaternion.Euler(180f, 0f, 0f);
                    cloneObject = Instantiate(obj, new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), q2);
                    list_lights.Add(cloneObject);
                }
            }
            else if (Input.GetKeyDown(KeyCode.E)) {
                editBtn.onClick.Invoke();
            }
            else if (Input.GetMouseButtonDown(0) && isEdit) {
                clickedGameObject = hitInfo.collider.gameObject.transform.root.gameObject;
                if (string.Equals(clickedGameObject.transform.name, "Cube_sensor16(Clone)")) {
                    isGet = true;
                    isEdit = false;
                }
            }
            else if (isGet) {
                //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
                Vector3 objectPoint = Camera.main.WorldToScreenPoint(clickedGameObject.transform.position);
                // Cubeの現在位置(マウス位置)を、pointScreenに格納
                Vector3 pointScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPoint.z);
                //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
                Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
                //pointWorld.z = transform.position.z;
                pointWorld.z = hitInfo.point.z;
                //Cubeの位置を、pointWorldにする
                clickedGameObject.transform.position = pointWorld;
                if (Input.GetMouseButtonUp(0)) {
                    u_x = (160f * 3f) * Mathf.Abs(1.87f - hitInfo.point.x) / 2.44f + 350;
                    u_y = (110f * 3f) * Mathf.Abs(1.32f - hitInfo.point.y) / 1.58f - 300;
                    clickedGameObject.GetComponentInChildren<Image>().GetComponent<RectTransform>().anchoredPosition = new Vector2(u_x, -u_y);
                    isGet = false;
                    isEdit = true;
                }
            }
            else if (Input.GetMouseButtonDown(1) && isEdit) {
                clickedGameObject = hitInfo.collider.gameObject.transform.root.gameObject;
                if (string.Equals(clickedGameObject.transform.name, "Cube_sensor16(Clone)")) {
                    Debug.Log(clickedGameObject.GetComponentInChildren<Text>().text);
                    Destroy(list_sensors[int.Parse(clickedGameObject.GetComponentInChildren<Text>().text) - 1]);          
                    list_sensors.RemoveAt(int.Parse(clickedGameObject.GetComponentInChildren<Text>().text) - 1);
                    sensorsNumber--;
                    // センサ番号の振り直し
                    //int numbers = 1;
                    //foreach (GameObject sensor in list_sensors) {
                    //    sensor.GetComponentInChildren<Text>().text = numbers.ToString();
                    //    numbers++;
                    //}
                }
            }
            else if (Input.GetKeyDown(KeyCode.Backspace)) {
                deleteBtn.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Delete)) {
                allDeleteBtn.onClick.Invoke();
            }
        }
        
        //else if (isPut) {
        //    // Rayがヒットしていない場合は水色に
        //    aimPointImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        //    Debug.Log("no hit");
        //}
    }
    
    public void MakeFiles(string loop) {
        var HomePath = "Sensor Data";
        if (System.IO.Directory.Exists(HomePath)) {
            if (System.IO.Directory.Exists(HomePath + "/" + loop)) {
                if (!System.IO.Directory.Exists(HomePath + "/" + loop + "/" + "CSV")) {
                    System.IO.Directory.CreateDirectory(HomePath + "/" + loop + "/" + "CSV");
                }
            }
            else {
                System.IO.Directory.CreateDirectory(HomePath + "/" + loop);
                System.IO.Directory.CreateDirectory(HomePath + "/" + loop + "/" + "CSV");
            }
        }
        else {
            //ディレクトリ作成
            System.IO.Directory.CreateDirectory(HomePath);
            System.IO.Directory.CreateDirectory(HomePath + "/" + loop);
            System.IO.Directory.CreateDirectory(HomePath + "/" + loop + "/" + "CSV");
        }
    }
    public void Click_human() {
        buttonText.text = "Menu\n(ESC)";
        closeBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
        human.SetActive(true);
        fPSCameraController.enabled = true;
        fPSCameraController.cursorLock = true;
        fPSCameraController.UpdateCursorLock();
        fPSCameraController.ThirdCamera.transform.position = new Vector3(0.36f, 1.75f, 8.82f);
        fPSCameraController.ThirdCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        menuPanel.SetActive(false);
        GameObject stepString = GameObject.Find("Text_explain");
        stepString.GetComponent<UnityEngine.UI.Text>().text = "Install human step";
        isPanelTrue = false;
        editButtonText.text = "Change view\n(3PV)";
    }
    public void Click_lightMode() {
        buttonText.text = "Menu\n(ESC)";
        closeBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
        isLight = true;
        isSensor = false;
        isPut = true;
        fPSCameraController.enabled = true;
        fPSCameraController.cursorLock = true;
        fPSCameraController.UpdateCursorLock();
        menuPanel.SetActive(false);
        isPanelTrue = false;
        GameObject stepString = GameObject.Find("Text_explain");
        stepString.GetComponent<UnityEngine.UI.Text>().text = "Install lights step";
        editPanel.SetActive(true);
    }
    public void Click_sensorMode() {
        buttonText.text = "Menu\n(ESC)";
        closeBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
        isLight = false;
        isSensor = true;
        isPut = true;
        fPSCameraController.enabled = true;
        fPSCameraController.cursorLock = true;
        fPSCameraController.UpdateCursorLock();
        menuPanel.SetActive(false);
        isPanelTrue = false;
        GameObject stepString = GameObject.Find("Text_explain");
        stepString.GetComponent<UnityEngine.UI.Text>().text = "Install sensors step";
        editPanel.SetActive(true);
    } 

    public void Click_menu() {
        Debug.Log("menu");
        isPut = false;
        closeBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
        //closeBtn.transition = Selectable.Transition.ColorTint;
        if (isPanelTrue == true) {
            buttonText.text = "Menu\n(ESC)";
            menuPanel.SetActive(false);
            isPanelTrue = false;
            fPSCameraController.enabled = true;
            fPSCameraController.cursorLock = true;
            fPSCameraController.UpdateCursorLock();
            isPut = true;
            if (isLight || isSensor) {
                editPanel.SetActive(true);
            }
        }
        else if (isPanelTrue == false) {
            editPanel.SetActive(false);
            menuPanel.SetActive(true);
            isPanelTrue = true;
            fPSCameraController.cursorLock = false;
            fPSCameraController.UpdateCursorLock();
            fPSCameraController.enabled = false;
            buttonText.text = "Close\n(ESC)";
            closeBtn.image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
        }
    }

    public void Click_delete() {
        StartCoroutine("Blink_delete");
        if (isSensor) {
            Destroy(list_sensors[list_sensors.Count - 1]);
            list_sensors.RemoveAt(list_sensors.Count - 1);
            sensorsNumber--;
        }
        else if (isLight) {
            Destroy(list_lights[list_lights.Count - 1]);
            list_lights.RemoveAt(list_lights.Count - 1);
        }
        deleteBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
    }
    public void Click_allDelete() {
        StartCoroutine("Blink_allDelete");
        if (isSensor) {
            foreach (GameObject sensor in list_sensors) {
                Destroy(sensor);
            }
            list_sensors.Clear();
            sensorsNumber = 0;
        } 
        else if (isLight) {
            foreach (GameObject light in list_lights) {
                Destroy(light);
            }
            list_lights.Clear();
        }
        allDeleteBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
    }
    public void Click_edit() {
        StartCoroutine("Blink_edit");
        if (isEdit) {
            isEdit = false;
            if (isSensor) {
                GameObject stepString = GameObject.Find("Text_explain");
                stepString.GetComponent<UnityEngine.UI.Text>().text = "Install sensors step";
                // センサ番号の振り直し
                int numbers = 1;
                foreach (GameObject sensor in list_sensors) {
                    sensor.GetComponentInChildren<Text>().text = numbers.ToString();
                    numbers++;
                }
            }
            else if (isLight) {
                GameObject stepString = GameObject.Find("Text_explain");
                stepString.GetComponent<UnityEngine.UI.Text>().text = "Install lights step";
            }
        }
        else if (isEdit == false) {
            isEdit = true;
            GameObject stepString = GameObject.Find("Text_explain");
            stepString.GetComponent<UnityEngine.UI.Text>().text = "Edit step";
        }
        editBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
    }

    // 点滅コルーチン
    IEnumerator Blink_delete() {
        while (true) {
            deleteBtn.image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }
    IEnumerator Blink_allDelete() {
        while (true) {
            allDeleteBtn.image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator Blink_edit() {
        while (true) {
            editBtn.image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
