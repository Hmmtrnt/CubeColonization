using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("SPECE"))
        //{
        //    Debug.Log("�ʂ���");
        //    if(GetComponent<Renderer>().material.color == Color.red)
        //    {
        //        GetComponent<Renderer>().material.color = Color.white;
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // �I�u�W�F�N�g�̐F��ԂɕύX
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
