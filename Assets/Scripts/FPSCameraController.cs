using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCameraController : MonoBehaviour
{
    float x, z;
    float speed = 0.1f;

    public GameObject cam;
    //private GameObject cam;
    public GameObject FirstCamera;
    public GameObject ThirdCamera;
    public Vector3 pos;
    public Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;

    public bool cursorLock = false;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    [SerializeField] public Button changeViewBtn;
    [SerializeField] GameObject human;
    [SerializeField] Text viewButtonText = null;
    // Start is called before the first frame update
    void Start() {
        FirstCamera.SetActive(true);
        ThirdCamera.SetActive(false);
        cam = FirstCamera;
        //FirstCamera.SetActive(false);
        //ThirdCamera.SetActive(true);
        //cam = ThirdCamera;

        cameraRot = cam.transform.localRotation;
        characterRot = human.transform.localRotation;
        cursorLock = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeViewBtn.onClick.Invoke();
            //FirstCamera.SetActive(!FirstCamera.activeInHierarchy);
            //ThirdCamera.SetActive(!ThirdCamera.activeInHierarchy);
            //if (FirstCamera.activeInHierarchy) {
            //    cam = FirstCamera;
            //}
            //else if (ThirdCamera.activeInHierarchy) {
            //    cam = ThirdCamera;
            //}
        }

        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;


        // 実装上不都合があったらThirdCameraの移動は矢印キーに変更する
        if (FirstCamera.activeInHierarchy) {
            cameraRot *= Quaternion.Euler(-yRot, 0, 0);
            characterRot *= Quaternion.Euler(0, xRot, 0);
        } else if (ThirdCamera.activeInHierarchy) {
            cameraRot *= Quaternion.Euler(-yRot, xRot, 0);
            //cameraRot *= Quaternion.Euler(-yRot, 0, 0);
            characterRot *= Quaternion.Euler(0, xRot, 0);
        }

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        UpdateCursorLock();
    }

    private void FixedUpdate() {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //transform.position += new Vector3(x,0,z);

        transform.position += cam.transform.forward * z + cam.transform.right * x;
    }


    public void UpdateCursorLock() {
        if (Input.GetMouseButton(1)) {
            cursorLock = true;
        }

        if (cursorLock) {
            Cursor.lockState = CursorLockMode.Locked;
            //Debug.Log("CursorUpdate");
        }
        else if (!cursorLock) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q) {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    public void Click_changeView() {
        StartCoroutine("Blink_changeView");
        FirstCamera.SetActive(!FirstCamera.activeInHierarchy);
        ThirdCamera.SetActive(!ThirdCamera.activeInHierarchy);
        if (FirstCamera.activeInHierarchy) {
            cam = FirstCamera;
            viewButtonText.text = "Change view\n(FPV)";
        }
        else if (ThirdCamera.activeInHierarchy) {
            cam = ThirdCamera;
            viewButtonText.text = "Change view\n(3PV)";
        }
        changeViewBtn.image.color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 116.0f / 255.0f, 1.0f);
    }

    IEnumerator Blink_changeView() {
        while (true) {
            changeViewBtn.image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }
}