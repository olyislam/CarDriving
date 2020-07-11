using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Controlling Setup")]
    [SerializeField, Range(100f, 500f)] private float Speed = 40f;
    [SerializeField, Range(20f, 45f)] private float TurnSpeed = 40f;
    [SerializeField, Range(20f, 1000f)] private float BreakeForce = 100f;


    [Header("WheelCollider Reference")]
    [SerializeField] private WheelCollider[] Wheels = new WheelCollider[4];
    [Header("WheelMesh Reference")]
    [SerializeField] private GameObject[] WheelsMesh = new GameObject[4];

    public new AudioHandeller audio;
    CustomInput cin;

    private Vector2 Directiontion;

    void Awake()
    {
        cin = new CustomInput();
        cin.Joystic.move.performed += ctx => Directiontion = ctx.ReadValue<Vector2>();
        cin.Joystic.move.canceled += ctx => Directiontion = Vector2.zero;
    }

    private void OnEnable()
    {
        cin.Enable();
    }

    private void OnDisable()
    {
        cin.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        audio.Mute(false);
        audio.StartEngine();
        CarBodyInitilize();

    }


    //initilize car body and wheel position and rotation
    private void CarBodyInitilize()
    {
        for (int i = 0; i < Wheels.Length; i++)
        {
            Vector3 Wheelpos = new Vector3();
            Quaternion Wheelrot = new Quaternion();
            Wheels[i].GetWorldPose(out Wheelpos, out Wheelrot);
            WheelsMesh[i].transform.position = Wheelpos;
            WheelsMesh[i].transform.rotation = Wheelrot;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            Breake();
            Debug.Log("f");
        }
        */
   
        audio.Forword(1);
        Move(1);
        Turn(Directiontion.x);
    }

    //move only forword position
    private void Move( float dir)
    {
        for(int i = 0; i< Wheels.Length; i++){
            Wheels[i].motorTorque = dir * Speed;
            Vector3 Wheelpos = new Vector3();
            Quaternion Wheelrot = new Quaternion();
            Wheels[i].GetWorldPose(out Wheelpos, out Wheelrot);
            WheelsMesh[i].transform.position = Wheelpos;
            WheelsMesh[i].transform.rotation = Wheelrot;
        }
    }

    private void Breake()
    { 
    foreach(WheelCollider wheel in Wheels)
        {
            wheel.brakeTorque = BreakeForce;
        }
    }

    //turn left or right direction
    private void Turn(float dir)
    {
        for (int i = 2; i < Wheels.Length; i++)
        {
            Wheels[i].steerAngle = dir * TurnSpeed;
        }
    }


    [Serializable]
    public class AudioHandeller
    {

        [Header("Audio Sorce reference")]
        [SerializeField] private AudioSource EngineSound;

        [Header("Audio Clip reference")]
        [SerializeField] private AudioClip EngineIdle;
        [SerializeField] private AudioClip Acceleration;

        /// <summary>
        /// set sound mode mute or not
        /// </summary>
        /// <param name="mute"> sound mode value that effect on audio source</param>
        public void Mute(bool mute = false)
        {
            EngineSound.mute = mute;
        }

        public void StartEngine()
        {
            PlayClip(EngineIdle, "Engine");
        }


        /// <summary>
        /// play engine sound effect W.R.To accelleration value and direction of value
        /// </summary>
        /// <param name="directionValur"> direction of acceleration</param>
        public void Forword(float directionValur)
        {
            if (directionValur > 0)
            {
                PlayClip(Acceleration, "Engine");
            }
            else if (directionValur < 0)
            {
                PlayClip(Acceleration, "Engine");
            }
            else
            {
                PlayClip(EngineIdle, "Engine");
            }
        }


        /// <summary>
        /// play audio under seperate audio source
        /// </summary>
        /// <param name="clip">what clip will be play</param>
        /// <param name="DeviceName">what device will play this audio clip that passed by parameter</param>
        private void PlayClip(AudioClip clip ,string DeviceName)
        {
            switch (DeviceName)
            {
                case "Engine":
                    if (EngineSound.clip != clip)
                    { 
                        EngineSound.clip = clip;
                        EngineSound.Play();
                    }
                    break;
                    
            }
        }

    }
}

