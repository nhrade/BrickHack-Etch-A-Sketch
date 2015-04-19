using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class DrawerController : MonoBehaviour {

    Vector3 lastPosition;
    List<Vector3> vectors = new List<Vector3>();
    const float mulFactor = 0.7f;
    const float accelFactor = 40.0f;
    public GameObject myo;
    public GameObject system = null;
    public static Material lineMaterial;
	void Start () {
       
	}

    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            lineMaterial = new Material("Shader \"Lines/Colored Blended\" {" + "SubShader { Pass { " + "    Blend SrcAlpha OneMinusSrcAlpha " + "    ZWrite Off Cull Off Fog { Mode Off } " + "    BindChannels {" + "      Bind \"vertex\", vertex Bind \"color\", color }" + "} } }");
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        }
    }
	// Update is called once per frame
	void Update () {

        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        Vector3 acc = thalmicMyo.accelerometer;
        Debug.Log("X: " + thalmicMyo.accelerometer.x);
        transform.position = new Vector3((transform.position.y + (Mathf.Pow(acc.y, 3))) * 1.0f/3.0f * Time.deltaTime * accelFactor,
            (transform.position.x + (Mathf.Pow(acc.x, 3) * 70)) * 1.0f/3.0f * Time.deltaTime, 0);
        ParticleSystem particles = system.GetComponent<ParticleSystem>();
        if (thalmicMyo.pose == Pose.Fist)
        {   
            particles.emissionRate = 2500.0f;
        }
        else
        {
            particles.emissionRate = 60.0f;
        }
        if (thalmicMyo.pose == Pose.WaveIn)
        {
            particles.startColor = Color.cyan;
        }
        else if (thalmicMyo.pose == Pose.WaveOut)
        {
            particles.startColor = Color.yellow;
        }
        else
        {
            particles.startColor = Color.grey;
        }
	}
}
