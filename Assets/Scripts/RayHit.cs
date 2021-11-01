using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayHit : MonoBehaviour
{
    RaycastHit lightHit;
    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        //m_Material = GetComponent<Renderer>().material;
        //print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
        //m_Material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
        foreach(var obj in hits)
        {
            Debug.Log(obj.collider.tag);
        }
        //m_Material.GetTexture.
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        /*
        if (Physics.Raycast(transform.position, transform.forward, out lightHit, Mathf.Infinity))
        {
            Debug.Log(lightHit.collider.gameObject.name);
        }
        */
    }
}
