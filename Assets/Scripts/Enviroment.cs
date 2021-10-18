using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField] private GameObject _repeatableObject;
    [SerializeField]Player _player;
    public static bool _reseting = false;


    void Update()
    {
        if (!_reseting) 
        {
            if ((_repeatableObject.transform.position.y - _player.transform.position.y) < 0.1f)
            {
                _repeatableObject = Instantiate(_repeatableObject, new Vector2(_repeatableObject.transform.position.x, _repeatableObject.GetComponent<SpriteRenderer>().bounds.size.y + _repeatableObject.transform.position.y), Quaternion.identity, this.transform);
            }
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, this.transform.position.y - 1.5f, Time.deltaTime), this.transform.position.z);
        }
        if (_reseting) 
        {
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, this.transform.position.y + 5f, Time.deltaTime), this.transform.position.z);
            if(this.transform.position.y >= 0) 
            {
                _reseting = false;
            }
        }
    }
    public static void StopEnviromentAndReset() 
    {
        _reseting = true;
    }
}
