using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    // 生成したいゲームオブジェクト
    [SerializeField]private GameObject _gameobject;

    // Start is called before the first frame update
    void Start()
    {
        for (int z = -10; z < 10; z++)
        {
            for(int x = -10; x < 10; x++)
            {
                Instantiate(_gameobject, new Vector3(x, 0.0f, z), Quaternion.identity);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
