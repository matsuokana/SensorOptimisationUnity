using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSensor : MonoBehaviour
{
    public Camera dispCamera;
    //public Text TextLightValue;
    public GameObject value_object = null; // Textオブジェクト
    private Texture2D targetTexture;

    public float lightValue;

    // Use this for initialization
    IEnumerator Start()
    {
        var tex = dispCamera.targetTexture;
        targetTexture = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        while (true)
        {
            // RenderTextureキャプチャ
            RenderTexture.active = dispCamera.targetTexture;

            yield return new WaitForEndOfFrame();

            targetTexture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
            targetTexture.Apply();

            // 照度を取得する
            lightValue = GetLightValue(targetTexture);
            
            //Text TextLightValue = value_object.GetComponent<Text>();
            //TextLightValue.text = string.Format("{0:0.000000000}", lightValue);
            
            //yield return new WaitForSeconds(1.0f);
        }
    }

    // 画像全体の照度計算
    float GetLightValue(Texture2D tex)
    {
        var cols = tex.GetPixels();

        // 平均色計算
        Color avg = new Color(0, 0, 0);
        foreach(var col in cols)
        {
            avg += col;
        }
        avg /= cols.Length;

        // 照度計算
        //Debug.Log(0.229f * avg.r + 0.587f * avg.g + 0.114f * avg.b);
        Text TextLightValue = value_object.GetComponent<Text>();
        TextLightValue.text = string.Format("{0:0.000000000}", 0.229f * avg.r + 0.587f * avg.g + 0.114f * avg.b);
        return 0.229f * avg.r + 0.587f * avg.g + 0.114f * avg.b;
    }
}
