using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GererCubes : MonoBehaviour {

    public GameObject MonCubeG;
    public GameObject MonCubeM;
    public GameObject MonCubeD;
    public Text scoreText;
    public Text finText;

    public static float score;

    private float lastScore;
    private float nextActionTimeG = 0.0f;
    private float nextActionTimeM = 0.0f;
    private float nextActionTimeD = 0.0f;
    // Use this for initialization
    void Start () {
        score = 0;
        lastScore = -1;
    }
	
	// Update is called once per frame
	void Update () {

        if (score != lastScore)
        {
            SetScoreText();
            lastScore = score;
        }

        if (finText.text == "")
        {
            if (Time.time > nextActionTimeG)
            {
                nextActionTimeG += (3f * UnityEngine.Random.value) + 0.8f;
                Instantiate(MonCubeG, new Vector3(-3f, 0, 30), Quaternion.identity);
            }

            if (Time.time > nextActionTimeM)
            {
                nextActionTimeM += (3f * UnityEngine.Random.value) + 0.8f;
                Instantiate(MonCubeM, new Vector3(0, 0, 30), Quaternion.identity);
            }

            if (Time.time > nextActionTimeD)
            {
                nextActionTimeD += (3f * UnityEngine.Random.value) + 0.8f;
                Instantiate(MonCubeD, new Vector3(3f, 0, 30), Quaternion.identity);
            }
        }
    }

    void SetScoreText()
    {
        // Update the text field of our 'countText' variable
        float truncated = (float)(Math.Truncate((double)score * 100.0) / 100.0);
        scoreText.text = "Score : " + truncated.ToString();

        // Check if our 'count' is equal to or exceeded 12
        if (score <= -15)
        {
            finText.text = "You Loose :(";
            Destroy(GameObject.FindWithTag("GenCube"));
        }
        if (score >= 15)
        {
            finText.text = "You Win!";
            Destroy(GameObject.FindWithTag("GenCube"));
        }
    }
}
