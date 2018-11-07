using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defautAngle = 20;

    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defautAngle);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defautAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defautAngle);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
            {
                // タッチ開始
                SetAngle(this.flickAngle);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // タッチ終了
                SetAngle(this.defautAngle);
            }
            if (touch.phase == TouchPhase.Began && Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
            {
                // タッチ開始
                SetAngle(this.flickAngle);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // タッチ終了
                SetAngle(this.defautAngle);
            }
        }
    }


    public void SetAngle (float angle){
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
