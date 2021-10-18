using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum RotateType 
{
    Right , Left
}
public class Player : MonoBehaviour
{
    Transform _playerTransform;
    int _rotateDur = 200;
    void Start()
    {
        _playerTransform = this.transform;
    }

    void Update()
    {
#if UNITY_ANDROID 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.x > (Screen.width / 2)) 
            {
                Rotate(RotateType.Left);

            }
            if(touch.position.x <= (Screen.width / 2)) 
            {
                Rotate(RotateType.Right);
            }
        }

#endif

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x> (Screen.width / 2)) 
            {
                Rotate(RotateType.Left);
            }
            if (Input.mousePosition.x <= (Screen.width / 2)) 
            {
                Rotate(RotateType.Right);
            }
        }
#endif
        }

    private void Rotate(RotateType rotateType) 
    {
        if(rotateType == RotateType.Right)
            _playerTransform.eulerAngles = new Vector3(_playerTransform.eulerAngles.x
                        , _playerTransform.eulerAngles.y
                        ,Mathf.Lerp(_playerTransform.eulerAngles.z, _playerTransform.eulerAngles.z + _rotateDur,Time.deltaTime));
        if(rotateType == RotateType.Left)
            _playerTransform.eulerAngles = new Vector3(_playerTransform.eulerAngles.x
                       , _playerTransform.eulerAngles.y
                       , Mathf.Lerp(_playerTransform.eulerAngles.z, _playerTransform.eulerAngles.z - _rotateDur, Time.deltaTime));
    }
}
