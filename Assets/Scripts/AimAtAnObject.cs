using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtAnObject : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask _layerMask;//выбрать слои которые будут участвовать в  колиззи
    private Color _originalColor;


    private void Awake()
    { 
        
        _originalColor = GetComponent<Renderer>().material.color ;
    }

    private void Update()
    {
      //  //Данный метод будет создает  луч из точки экрана где находится наша мышка  
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
      
          //узнаём попал ли наш луч
          if (Physics.Raycast(ray, out RaycastHit raycastHit,100,_layerMask))
          {
              var hitObject = raycastHit.collider.gameObject;
             
              hitObject.GetComponent<Renderer>().material.color = Color.gray;
          }
          else
          {
              if (_originalColor != null)
              {
                  OnMouseExit();
              }
             
          }
        
    }

   private void OnMouseExit()
   {
        GetComponent<Renderer>().material.color =  _originalColor;
   }
}
