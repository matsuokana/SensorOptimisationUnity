using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    //操作したいAnimationControllerを持ったGameObjectを割り当てる
    public Animator _animator;
    GameObject SensorManagerObj;
    SensorManager SensorManagerScript;

    void Start() {
        _animator = GetComponent<Animator>();
        //SensorManagerObj = GameObject.Find("SensorManager");
        //SensorManagerScript = SensorManagerObj.GetComponent<SensorManager>();
        SensorManagerObj = GameObject.Find("SensorManager");
        SensorManagerScript = SensorManagerObj.GetComponent<SensorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //もし、enterキーが押されたらなら
        //if (Input.GetKey(KeyCode.Return)) {
        //    //Bool型のパラメーターであるisStartをTrueにする
        //    _animator.SetBool("isStart", true);
        //    Debug.Log("enter");
        //}
        _animator.SetBool("isStart", true);
        _animator.SetBool("isRestart", true);

        // transformを取得
        Transform myTransform = this.transform;
        // 座標を取得
        Vector3 pos = myTransform.position;
        
        if ((SensorManagerScript.motionCount == 10 || SensorManagerScript.motionCount == 11 || SensorManagerScript.motionCount == 12 || SensorManagerScript.motionCount == 13 || SensorManagerScript.motionCount == 14 || SensorManagerScript.motionCount == 15
                || SensorManagerScript.motionCount == 16 || SensorManagerScript.motionCount == 17 || SensorManagerScript.motionCount == 18 || SensorManagerScript.motionCount == 19
                || SensorManagerScript.motionCount == 1 || SensorManagerScript.motionCount == 2 || SensorManagerScript.motionCount == 3 || SensorManagerScript.motionCount == 4
                || SensorManagerScript.motionCount == 5 || SensorManagerScript.motionCount == 6 || SensorManagerScript.motionCount == 7 || SensorManagerScript.motionCount == 8
                || SensorManagerScript.motionCount == 9 || SensorManagerScript.motionCount == 60 || SensorManagerScript.motionCount == 61 || SensorManagerScript.motionCount == 62 
                || SensorManagerScript.motionCount == 63 || SensorManagerScript.motionCount == 64 || SensorManagerScript.motionCount == 65 || SensorManagerScript.motionCount == 66
                || SensorManagerScript.motionCount == 67 || SensorManagerScript.motionCount == 68 || SensorManagerScript.motionCount == 69 || SensorManagerScript.motionCount == 70
                || SensorManagerScript.motionCount == 71 || SensorManagerScript.motionCount == 72 || SensorManagerScript.motionCount == 73 || SensorManagerScript.motionCount == 74
                || SensorManagerScript.motionCount == 75 || SensorManagerScript.motionCount == 76 || SensorManagerScript.motionCount == 77 || SensorManagerScript.motionCount == 78
                || SensorManagerScript.motionCount == 79) && SensorManagerScript.isChangeLabel == true) {
            // repositon
            pos.y = -1.0f;
            myTransform.position = pos;  // 座標を設定
        }
        
        // Int
        // 押したナンバーキーに対応したポーズを呼び出すイメージ
        if (SensorManagerScript.motionCount == 1) {
            //jump2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=1");

            _animator.SetBool("isRestart", false);
        }
        else if (SensorManagerScript.motionCount == 2) {
            //jump3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=2");
        }
        else if (SensorManagerScript.motionCount == 3) {
            //jump4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=3");
        }
        else if (SensorManagerScript.motionCount == 4) {
            //jump5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=4");
        }
        else if (SensorManagerScript.motionCount == 5) {
            //jump6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=5");
        }
        else if (SensorManagerScript.motionCount == 6) {
            //jump7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=6");
        }
        else if (SensorManagerScript.motionCount == 7) {
            //jump8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=7");
        }
        else if (SensorManagerScript.motionCount == 8) {
            //jump9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=8");
        }
        else if (SensorManagerScript.motionCount == 9) {
            //jump10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=9");
        }
        else if (SensorManagerScript.motionCount == 10) {
            //squat1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=10 squat1");
        }
        else if (SensorManagerScript.motionCount == 11) {
            //squat2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=11 squat2");
        }
        else if (SensorManagerScript.motionCount == 12) {
            //squat3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=12 squat3");
        }
        else if (SensorManagerScript.motionCount == 13) {
            //squat4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=13 squat4");
        }
        else if (SensorManagerScript.motionCount == 14) {
            //squat5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=14 squat5");
        }
        else if (SensorManagerScript.motionCount == 15) {
            //squat6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=15 squat6");
        }
        else if (SensorManagerScript.motionCount == 16) {
            //squat7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=16 squat7");
        }
        else if (SensorManagerScript.motionCount == 17) {
            //squat8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=17 squat8");
        }
        else if (SensorManagerScript.motionCount == 18) {
            //squat9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=18 squat9");
        }
        else if (SensorManagerScript.motionCount == 19) {
            //squat10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=19 squat10");
        }
        else if (SensorManagerScript.motionCount == 20) {
            // tiltBodyLeft1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=20 tiltBodyLeft1");
        }
        else if (SensorManagerScript.motionCount == 21) {
            // tiltBodyLeft2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=21 tiltBodyLeft2");
        }
        else if (SensorManagerScript.motionCount == 22) {
            // tiltBodyLeft3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=22 tiltBodyLeft3");
        }
        else if (SensorManagerScript.motionCount == 23) {
            // tiltBodyLeft4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=23 tiltBodyLeft4");
        }
        else if (SensorManagerScript.motionCount == 24) {
            // tiltBodyLeft5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=24 tiltBodyLeft5");
        }
        else if (SensorManagerScript.motionCount == 25) {
            // tiltBodyLeft6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=25 tiltBodyLeft6");
        }
        else if (SensorManagerScript.motionCount == 26) {
            // tiltBodyLeft7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=27 tiltBodyLeft7");
        }
        else if (SensorManagerScript.motionCount == 27) {
            // tiltBodyLeft8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=27 tiltBodyLeft8");
        }
        else if (SensorManagerScript.motionCount == 28) {
            // tiltBodyLeft9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=28 tiltBodyLeft9");
        }
        else if (SensorManagerScript.motionCount == 29) {
            // tiltBodyLeft10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=29 tiltBodyLeft10");
        }
        else if (SensorManagerScript.motionCount == 30) {
            // tiltBodyRight1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=30 tiltBodyRight1");
        }
        else if (SensorManagerScript.motionCount == 31) {
            // tiltBodyRight2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=31 tiltBodyRight2");
        }
        else if (SensorManagerScript.motionCount == 32) {
            // tiltBodyRight3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=32 tiltBodyRight3");
        }
        else if (SensorManagerScript.motionCount == 33) {
            // tiltBodyRight4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=33 tiltBodyRight4");
        }
        else if (SensorManagerScript.motionCount == 34) {
            // tiltBodyRight5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=34 tiltBodyRight5");
        }
        else if (SensorManagerScript.motionCount == 35) {
            // tiltBodyRight6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=35 tiltBodyRight6");
        }
        else if (SensorManagerScript.motionCount == 36) {
            // tiltBodyRight7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=36 tiltBodyRight7");
        }
        else if (SensorManagerScript.motionCount == 37) {
            // tiltBodyRight8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=37 tiltBodyRight8");
        }
        else if (SensorManagerScript.motionCount == 38) {
            // tiltBodyRight9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=38 tiltBodyRight9");
        }
        else if (SensorManagerScript.motionCount == 39) {
            // tiltBodyRight10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=39 tiltBodyRight10");
        }
        else if (SensorManagerScript.motionCount == 40) {
            // turnHandLeft1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=40 turnHandLeft1");
        }
        else if (SensorManagerScript.motionCount == 41) {
            // turnHandLeft2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=41 turnHandLeft2");
        }
        else if (SensorManagerScript.motionCount == 42) {
            // turnHandLeft3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=42 turnHandLeft3");
        }
        else if (SensorManagerScript.motionCount == 43) {
            // turnHandLeft4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=43 turnHandLeft4");
        }
        else if (SensorManagerScript.motionCount == 44) {
            // turnHandLeft5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=44 turnHandLeft5");
        }
        else if (SensorManagerScript.motionCount == 45) {
            // turnHandLeft6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=45 turnHandLeft6");
        }
        else if (SensorManagerScript.motionCount == 46) {
            // turnHandLeft7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=46 turnHandLeft7");
        }
        else if (SensorManagerScript.motionCount == 47) {
            // turnHandLeft8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=47 turnHandLeft8");
        }
        else if (SensorManagerScript.motionCount == 48) {
            // turnHandLeft9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=48 turnHandLeft9");
        }
        else if (SensorManagerScript.motionCount == 49) {
            // turnHandLeft10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=49 turnHandLeft10");
        }
        else if (SensorManagerScript.motionCount == 50) {
            // turnHandRight1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=50 turnHandRight1");
        }
        else if (SensorManagerScript.motionCount == 51) {
            // turnHandRight2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=51 turnHandRight2");
        }
        else if (SensorManagerScript.motionCount == 52) {
            // turnHandRight3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=52 turnHandRight3");
        }
        else if (SensorManagerScript.motionCount == 53) {
            // turnHandRight4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=53 turnHandRight4");
        }
        else if (SensorManagerScript.motionCount == 54) {
            // turnHandRight5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=54 turnHandRight5");
        }
        else if (SensorManagerScript.motionCount == 55) {
            // turnHandRight6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=55 turnHandRight6");
        }
        else if (SensorManagerScript.motionCount == 56) {
            // turnHandRight7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=56 turnHandRight7");
        }
        else if (SensorManagerScript.motionCount == 57) {
            // turnHandRight8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=57 turnHandRight8");
        }
        else if (SensorManagerScript.motionCount == 58) {
            // turnHandRight9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=58 turnHandRight9");
        }
        else if (SensorManagerScript.motionCount == 59) {
            // turnHandRight10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=59 turnHandRight10");
        }
        else if (SensorManagerScript.motionCount == 60) {
            //jump1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=1-1");
        }
        else if (SensorManagerScript.motionCount == 61) {
            //jump2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=1-2");
        }
        else if (SensorManagerScript.motionCount == 62) {
            //jump3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=2");
        }
        else if (SensorManagerScript.motionCount == 63) {
            //jump4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=3");
        }
        else if (SensorManagerScript.motionCount == 64) {
            //jump5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=4");
        }
        else if (SensorManagerScript.motionCount == 65) {
            //jump6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=5");
        }
        else if (SensorManagerScript.motionCount == 66) {
            //jump7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=6");
        }
        else if (SensorManagerScript.motionCount == 67) {
            //jump8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=7");
        }
        else if (SensorManagerScript.motionCount == 68) {
            //jump9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=8");
        }
        else if (SensorManagerScript.motionCount == 69) {
            //jump10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=9");
        }
        else if (SensorManagerScript.motionCount == 70) {
            //squat1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=10 squat1");
        }
        else if (SensorManagerScript.motionCount == 71) {
            //squat2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=11 squat2");
        }
        else if (SensorManagerScript.motionCount == 72) {
            //squat3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=12 squat3");
        }
        else if (SensorManagerScript.motionCount == 73) {
            //squat4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=13 squat4");
        }
        else if (SensorManagerScript.motionCount == 74) {
            //squat5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=14 squat5");
        }
        else if (SensorManagerScript.motionCount == 75) {
            //squat6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=15 squat6");
        }
        else if (SensorManagerScript.motionCount == 76) {
            //squat7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=16 squat7");
        }
        else if (SensorManagerScript.motionCount == 77) {
            //squat8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=17 squat8");
        }
        else if (SensorManagerScript.motionCount == 78) {
            //squat9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=18 squat9");
        }
        else if (SensorManagerScript.motionCount == 79) {
            //squat10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=19 squat10");
        }
        else if (SensorManagerScript.motionCount == 80) {
            // tiltBodyLeft1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=20 tiltBodyLeft1");
        }
        else if (SensorManagerScript.motionCount == 81) {
            // tiltBodyLeft2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=21 tiltBodyLeft2");
        }
        else if (SensorManagerScript.motionCount == 82) {
            // tiltBodyLeft3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=22 tiltBodyLeft3");
        }
        else if (SensorManagerScript.motionCount == 83) {
            // tiltBodyLeft4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=23 tiltBodyLeft4");
        }
        else if (SensorManagerScript.motionCount == 84) {
            // tiltBodyLeft5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=24 tiltBodyLeft5");
        }
        else if (SensorManagerScript.motionCount == 85) {
            // tiltBodyLeft6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=25 tiltBodyLeft6");
        }
        else if (SensorManagerScript.motionCount == 86) {
            // tiltBodyLeft7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=27 tiltBodyLeft7");
        }
        else if (SensorManagerScript.motionCount == 87) {
            // tiltBodyLeft8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=27 tiltBodyLeft8");
        }
        else if (SensorManagerScript.motionCount == 88) {
            // tiltBodyLeft9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=28 tiltBodyLeft9");
        }
        else if (SensorManagerScript.motionCount == 89) {
            // tiltBodyLeft10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=29 tiltBodyLeft10");
        }
        else if (SensorManagerScript.motionCount == 90) {
            // tiltBodyRight1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=30 tiltBodyRight1");
        }
        else if (SensorManagerScript.motionCount == 91) {
            // tiltBodyRight2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=31 tiltBodyRight2");
        }
        else if (SensorManagerScript.motionCount == 92) {
            // tiltBodyRight3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=32 tiltBodyRight3");
        }
        else if (SensorManagerScript.motionCount == 93) {
            // tiltBodyRight4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=33 tiltBodyRight4");
        }
        else if (SensorManagerScript.motionCount == 94) {
            // tiltBodyRight5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=34 tiltBodyRight5");
        }
        else if (SensorManagerScript.motionCount == 95) {
            // tiltBodyRight6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=35 tiltBodyRight6");
        }
        else if (SensorManagerScript.motionCount == 96) {
            // tiltBodyRight7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=36 tiltBodyRight7");
        }
        else if (SensorManagerScript.motionCount == 97) {
            // tiltBodyRight8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=37 tiltBodyRight8");
        }
        else if (SensorManagerScript.motionCount == 98) {
            // tiltBodyRight9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=38 tiltBodyRight9");
        }
        else if (SensorManagerScript.motionCount == 99) {
            // tiltBodyRight10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=39 tiltBodyRight10");
        }
        else if (SensorManagerScript.motionCount == 100) {
            // turnHandLeft1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=40 turnHandLeft1");
        }
        else if (SensorManagerScript.motionCount == 101) {
            // turnHandLeft2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=41 turnHandLeft2");
        }
        else if (SensorManagerScript.motionCount == 102) {
            // turnHandLeft3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=42 turnHandLeft3");
        }
        else if (SensorManagerScript.motionCount == 103) {
            // turnHandLeft4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=43 turnHandLeft4");
        }
        else if (SensorManagerScript.motionCount == 104) {
            // turnHandLeft5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=44 turnHandLeft5");
        }
        else if (SensorManagerScript.motionCount == 105) {
            // turnHandLeft6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=45 turnHandLeft6");
        }
        else if (SensorManagerScript.motionCount == 106) {
            // turnHandLeft7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=46 turnHandLeft7");
        }
        else if (SensorManagerScript.motionCount == 107) {
            // turnHandLeft8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=47 turnHandLeft8");
        }
        else if (SensorManagerScript.motionCount == 108) {
            // turnHandLeft9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=48 turnHandLeft9");
        }
        else if (SensorManagerScript.motionCount == 109) {
            // turnHandLeft10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=49 turnHandLeft10");
        }
        else if (SensorManagerScript.motionCount == 110) {
            // turnHandRight1
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=50 turnHandRight1");
        }
        else if (SensorManagerScript.motionCount == 111) {
            // turnHandRight2
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=51 turnHandRight2");
        }
        else if (SensorManagerScript.motionCount == 112) {
            // turnHandRight3
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=52 turnHandRight3");
        }
        else if (SensorManagerScript.motionCount == 113) {
            // turnHandRight4
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=53 turnHandRight4");
        }
        else if (SensorManagerScript.motionCount == 114) {
            // turnHandRight5
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=54 turnHandRight5");
        }
        else if (SensorManagerScript.motionCount == 115) {
            // turnHandRight6
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=55 turnHandRight6");
        }
        else if (SensorManagerScript.motionCount == 116) {
            // turnHandRight7
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=56 turnHandRight7");
        }
        else if (SensorManagerScript.motionCount == 117) {
            // turnHandRight8
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=57 turnHandRight8");
        }
        else if (SensorManagerScript.motionCount == 118) {
            // turnHandRight9
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=58 turnHandRight9");
        }
        else if (SensorManagerScript.motionCount == 119) {
            // turnHandRight10
            pos.x = 0.45f;    // x座標へ0.01加算
            pos.y = -1.35f;    // y座標へ0.01加算
            pos.z = 9.5f;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            myTransform.rotation = Quaternion.Euler(0f, 180f, 0f);

            _animator.SetInteger("motion", SensorManagerScript.motionCount);
            Debug.Log("motion=59 turnHandRight10");
        }
    }
}
