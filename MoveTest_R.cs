﻿using System.Collections;
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

    //碰撞这个事件由什么来监测呢？没错，用Collision来检测碰撞事件。
    //检测方法有三种，分别是：
    //OnCollisionEnter()：碰撞发生的起始瞬间调用，而且次数只会有一次。
    //OnCollisionExit()：碰撞结束的瞬间调用，也只会调用一次。
    //OnCollisionStay()：碰撞是一个过程，这个方法就是在开始后、结束前的过程中调用，会持续调用。
    //碰撞监测方法的等级和Start()与Update()是同级的。
    private void OnCollisionEnter(Collision collision) {
        //因为我的练习关卡里有个plane当地面，而我不想输出它的碰撞信息，所以屏蔽了它。
        if (collision.gameObject.name != "Plane") {
            //这里是利用debug的log输出打印出碰撞物体的名称
            Debug.Log("我撞上了" + collision.gameObject.name);
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name != "Plane") {
            Debug.Log("我撞完" + collision.gameObject.name + "后离开了");
        }
    }

    //如果你怼上了某个物体之后还持续的怼它，就会触发这个方法
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.name != "Plane") {
            Debug.Log("我和" + collision.gameObject.name + "在激烈互怼中");
        }
    }

    //我玩一些带有魔法设定的游戏时，总会考虑那些魔法阵是如何知道我踏进去的。
    //其实很简单，在unity里，用一个触发器就可以了。
    //我们要先创建一个物体，然后给它弄上合适的Collider，之后再在物体的属性面板里，把“Is Trigger”这一项前面的勾勾勾上，就行了。
    //勾上之后你会发现你就像是一个灵魂一样可以穿过它。
    //而刚才那个物体的Collider的范围，就是触发事件的范围了。
    //触发事件的监测方法有三种，和监测碰撞事件很相似：
    //OnTriggerEnter()：进入触发范围的瞬间调用，次数只有一次。
    //OnTriggerExit()：离开触发范围的瞬间调用，次数为一次。
    //OnTriggerStay()：一直处于触发范围内，持续调用。
    //触发监测方法的等级和Start()与Update()也是同级的。
    private void OnTriggerEnter(Collider other) {
        Debug.Log("我碰到了" + other.gameObject.name + "的边缘");
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("我离开了" + other.gameObject.name + "的范围");
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("我持续的收到来自" + other.gameObject.name + "的10000点伤害");
    }
}
