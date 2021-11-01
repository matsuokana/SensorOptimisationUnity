using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTime : MonoBehaviour
{
    [SerializeField] Color[] lightColors;
    [SerializeField] Light sceneLight;

    void Awake()
    {
        int hour = System.DateTime.Now.Hour;
        int month = System.DateTime.Now.Month;
        int value;

        if (month == 1 || month == 11 || month == 12)
        {  //冬
            value = 1;
        }
        else if (month == 5 || month == 6 || month == 7)
        {  //夏
            value = -1;
        }
        else
        {  //春秋
            value = 0;
        }

        if (hour < 5 + value)
        {  //夜中
            sceneLight.color = lightColors[0];
        }
        else if (hour < 8 + value)
        {  //朝
            sceneLight.color = lightColors[1];
        }
        else if (hour < 17 - value)
        {  //昼
            sceneLight.color = lightColors[2];
        }
        else if (hour < 18 - value)
        {  //夕方
            sceneLight.color = lightColors[3];
        }
        else if (hour < 22 - value)
        {  //夜
            sceneLight.color = lightColors[4];
        }
        else
        {  //夜中
            sceneLight.color = lightColors[0];
        }
    }
}
