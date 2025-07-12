using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenScroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x,_y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x,_y) * Time.deltaTime, _img.uvRect.size);  
    }
}
