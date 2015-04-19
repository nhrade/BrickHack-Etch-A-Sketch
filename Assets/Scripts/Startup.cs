using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

    public GameObject myo = null;
    
	// Use this for initialization
	void Start () {
        ThalmicHub hub = ThalmicHub.instance;
        ThalmicMyo myoInstance = myo.GetComponent<ThalmicMyo>();

        if (!hub.hubInitialized)
        {
            Debug.Log("Cannot connect Myo Connect.");
        }
        else if (!myoInstance.isPaired)
        {
            Debug.Log("Myo is not paired.");
        }
        else if (!myoInstance.armSynced)
        {
            Debug.Log("Myo not synced.");
        }
	}
	
	// Update is called once per frame
	void Update () {
        ThalmicHub hub = ThalmicHub.instance;
        if (Input.GetKeyDown(KeyCode.E))
            hub.ResetHub();
	}
}
