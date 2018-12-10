using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscilator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(0f, -15f, 0f);
    [SerializeField] float period = 2f;

    float movementFactor;
    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}

    // Update is called once per frame
    void Update() {

        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to 1

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
