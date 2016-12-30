using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest_R : MonoBehaviour {

    private Rigidbody cube_R;
    private Transform cube_T;
	// Use this for initialization
	void Start () {
        cube_R = gameObject.GetComponent<Rigidbody>();
        cube_T = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //用Rigidbody来移动物体，这样物体就具有了物理特性。但移动并不能直接用下面的错误形式进行书写
        //这是错误示范：
        //if (Input.GetKey(KeyCode.W)) {
        //    cube_R.MovePosition(Vector3.forward * 0.1f);
        //}
        //正确移动方法如下：
        if (Input.GetKey(KeyCode.W)) {
            //先获取物体的当前位置，然后再附上移动的方向
            cube_R.MovePosition(cube_T.position + Vector3.forward * 0.1f);
        }

        if (Input.GetKey(KeyCode.S)){
            cube_R.MovePosition(cube_T.position + Vector3.back * 0.1f);
        }

        if (Input.GetKey(KeyCode.A)){
            cube_R.MovePosition(cube_T.position + Vector3.left * 0.1f);
        }

        if (Input.GetKey(KeyCode.D)){
            cube_R.MovePosition(cube_T.position + Vector3.right * 0.1f);
        }
    }
}
