using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotroller : MonoBehaviour
{
    
    [Range(1f,10f)]public float TurnSpeed = 1;
    [Range(1f,10f)]public float Speed = 1;
    public Vector2 position;
 /*
    CustomInput cin;
    
    // Start is called before the first frame update
    void Awake()
    {
        cin = new CustomInput();
        cin.Joystic.move.performed += ctx => position = ctx.ReadValue<Vector2>();
        cin.Joystic.move.canceled += ctx => position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = position.x * TurnSpeed;
        transform.Translate(new  Vector3(position.x,0, Speed) * Time.deltaTime);
    }


    private void OnEnable()
    {
        cin.Enable();
    }

    private void OnDisable()
    {
        cin.Disable();
    }
    */
}
