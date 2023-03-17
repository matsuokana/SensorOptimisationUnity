using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
	const int sensorNum = 12;
	// array
	public GameObject[] sensor;
	/// <summary>
	/// パーティクルが他のGameObject(Collider)に当たると呼び出される
	/// </summary>
	/// <param name="other"></param>
	private void OnParticleCollision(GameObject other)
	{
		// 当たった相手の色をランダムに変える
		//other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
		
        if (other.name != "kuro-zetwall" && other.name != "floor" && other.name != "curatin" && other.name != "bedwall" && other.name != "doorwall"
			&& other.name != "shelfwall" && other.name != "deskwall" && other.name != "roof" && other.name != "Human") {
			Debug.Log(other.name);
		}
		else {
			Debug.Log("miss");
        }
        //else if (other.name == "Cube1") {
        //    cube1++;
        //    Debug.Log("Cube1: " + cube1);
        //}
    }
}
