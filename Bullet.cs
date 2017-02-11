using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //如果是一颗子弹的话，还像MoveTest_R里那样移动吗？
    //我并不建议，我们需要有子弹的特点
    private Rigidbody b_Rigidbody;
    private Person att;

    // Use this for initialization
    void Start () {
        b_Rigidbody = gameObject.GetComponent<Rigidbody>();
        //如果场景里有很多东西，而我们有时候需要找到其中的某一个，那么如何做呢？
        //用GameObjectFind()方法就可以了
        //GameObjectFind()方法的返回值是一个gameobject，所以泛型里我们可以填写找到的这个物体的脚本
        att = GameObject.Find("Attect").GetComponent<Person>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E)) {
            //给它一个力，让它能够飞出去！
            //注意此处方向为世界坐标系，如果想按照自身坐标系，那么应该用AddRelativeForce方法，而不是AddForce -> xxx.AddRelativeForce();
            //ForceMode：力的模式选择，有如下四种模式
            //Acceleration：加速度；Force：类似真实物理那种作用的力；Impulse：冲击力，瞬间发生；VelocityChange：速度变化；
            b_Rigidbody.AddForce(Vector3.forward * 100, ForceMode.Force);
        }
	}
}
