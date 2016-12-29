using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

    private Transform m_Transform;

	// Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W)) {
            //方法为Transform.Translate，此方法有两个特点：1.物体会穿模 2.不受重力影响 所以如果想要避免出现这两点，需要引入Rigidbody
            //Rigidbody的属性：Mass：质量，单位为Kg；Drag：空气阻力，为0即表示无阻力；Angular Drag：收到扭曲力时的空气阻力；Use Gravity：是否使用重力(关于Drag和Angular Drag推荐用两个方块进行演示，就知道是什么了)
            //Vector3代表为三维移动，space指相对于自身坐标系还是世界坐标系
            m_Transform.Translate(Vector3.forward * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.S)) {
            m_Transform.Translate(Vector3.back * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.A)) {
            m_Transform.Translate(Vector3.left * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.D)) {
            m_Transform.Translate(Vector3.right * 0.1f, Space.Self);
        }
	}
}
