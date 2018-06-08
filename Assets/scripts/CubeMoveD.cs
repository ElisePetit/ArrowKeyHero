using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveD : MonoBehaviour {

    public float speed = 8f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Renderer rend = GetComponent<Renderer>();

        transform.Translate(new Vector3(0,0,-3f) * (speed * UnityEngine.Random.value + 2f) * Time.fixedDeltaTime);
        CheckKeys(rend);

        if (transform.position.z < -3)
        {
            Debug.Log("Boom ! Raté à droite");
            GererCubes.score -= 1.5f;
            Destroy(gameObject);
        }

        if (transform.position.z < 1.5f)
        {

            //Set the main Color of the Material to blue
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.blue);

            //Find the Specular shader and change its Color to blue
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.blue);
        }

        if (transform.position.z < -1.5f)
        {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.black);
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.black);
        }

    }
     
    private void CheckKeys(Renderer rend)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.z < 1.5f && transform.position.z > -1.5f)
            {
                Debug.Log("Précision : " + transform.position.z);
                GererCubes.score += Math.Abs(1.5f - transform.position.z);
                Destroy(gameObject);
            }
        }
    }
}
