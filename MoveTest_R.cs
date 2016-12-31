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
        //如果一个物体添加了Rigidbody组件，那么必须也要添加一个Collider组件。因为物体与物体之间碰撞是物体的Collider组件的碰撞，所以如果只添加了Rigidbody而不添加Collider，是没有意义的。
        //unity的基本模型(cube之类的)，当你创建的时候，一般是默认带有Colider组件的。

        //常见的基础Collider形式有：
        //Box Collider(Center：中心位置；Size：范围大小)、
        //Sphere Collider(Center：中心位置；Radius：半径大小)、
        //Capsule Collider(Center：中心位置；Radius：半径大小；Height：高度；Direction：Height属性的伸缩轴向)、
        //Mesh Collider(这是一个网格状的“薄膜”，用来覆盖一些复杂的物体。Meth：根据你所选择的基本网格形状来构建整个“薄膜”)。
    }
}
