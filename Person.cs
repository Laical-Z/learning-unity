using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    private Transform att;
    // Use this for initialization
    void Start () {
        att = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //如果一个人被子弹击中了会怎么样呢？当然是倒地了
    //所以，我们要给人物一个触发器，让他能够在被子弹击中的时候死去
    private void OnTriggerEnter(Collider other) {
        //我的场景中，子弹只是一个cube来简略代替，所以这里就要写Cube
        if (other.gameObject.name == "Cube") {
            att.Rotate(Vector3.down,90);
        }
    }
}
