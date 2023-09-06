using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    // オリジナルのゲームオブジェクト
    public GameObject _gameobject;

    // Start is called before the first frame update
    void Start()
    {
        for (int z = 0; z < 10; z++)
        {
            for(int x = 0; x < 10; x++)
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
