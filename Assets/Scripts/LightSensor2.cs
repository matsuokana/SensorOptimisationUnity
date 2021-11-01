using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSensor2 : MonoBehaviour
{
    public Camera dispCamera;
    private Texture2D targetTexture;
    public float lightValue;

    public GameObject value_object = null; // Textオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        var tex = dispCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
    }

    // Update is called once per frame
    void Update()
    {
        // 指定されたカメラのRenderTexture取得
        var tex = dispCamera.targetTexture;
        // RenderTextureキャプチャ
        RenderTexture.active = dispCamera.targetTexture;

        targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        targetTexture.Apply();

        // 照度を取得する
        lightValue = GetLightValue(targetTexture);
        
        Text TextLightValue = value_object.GetComponent<Text>();
        TextLightValue.text = string.Format("{0:0.000}", lightValue);
        
    }

    // 画像全体の照度計算
    float GetLightValue(Texture2D tex)
    {
        var cols = tex.GetPixels();

        // 平均色計算
        Color avg = new Color(0, 0, 0);
        foreach (var col in cols)
        {
            avg += col;
        }
        avg /= cols.Length;

        // 照度計算
        //Debug.Log(0.229f * avg.r + 0.587f * avg.g + 0.114f * avg.b);
        return 0.229f * avg.r + 0.587f * avg.g + 0.114f * avg.b;
    }
}
