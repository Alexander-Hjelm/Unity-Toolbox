using UnityEngine;
using System.Collections;

public class Screencap : MonoBehaviour {

    int frames = 0;
    int num = 0;

	// Update is called once per frame
	void FixedUpdate () {
	    frames++;
            if (frames % 5 == 0)
            {
                Application.CaptureScreenshot("shot_" + num.ToString() + ".png");
                num++;
            }
	}
}
