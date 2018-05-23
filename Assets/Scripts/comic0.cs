using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PanelStep{

    public GameObject panel;
    public float camSize;
}


public class comic0 : MonoBehaviour {


   

    public List<PanelStep> Panels = new List<PanelStep>();
    int i;

    public float speed;
    public Vector3 destV;

    public float camResizeVelocity;
    public float smoothTime;

    bool arrived;

	// Use this for initialization
	void Start () {
        i = -1;
        destV = transform.position;
        arrived = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){



            arrived = false;
            if(i < Panels.Count-1){
                i++;   
            }else{
                i = 0;
            }

            destV = Panels[i].panel.transform.position + new Vector3(0, 0, -1);
        }	

        if(i>= 0){
            CamManager();
        }

	}


    void CamManager(){

        if (Camera.main.orthographicSize != Panels[i].camSize)
        {
            Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, Panels[i].camSize, ref camResizeVelocity, smoothTime);
        }

        if (transform.position != destV)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destV, step);

        }else{
            if(!arrived){
                Debug.Log("arrived");
                arrived = true;
            }
        }
    }
}
