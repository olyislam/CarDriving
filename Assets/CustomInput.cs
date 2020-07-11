// GENERATED AUTOMATICALLY FROM 'Assets/CustomInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CustomInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomInput"",
    ""maps"": [
        {
            ""name"": ""Joystic"",
            ""id"": ""d967215e-1864-482d-9a47-8075dbe71a0e"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""f6eb3589-aa90-4298-ad50-5c8f3514cf79"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cbda3dde-f239-4078-9b06-886709780772"",
                    ""path"": ""<HID::OpenChord X RMIT Exertion Games Lab UnoJoy Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Joystic
        m_Joystic = asset.FindActionMap("Joystic", throwIfNotFound: true);
        m_Joystic_move = m_Joystic.FindAction("move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Joystic
    private readonly InputActionMap m_Joystic;
    private IJoysticActions m_JoysticActionsCallbackInterface;
    private readonly InputAction m_Joystic_move;
    public struct JoysticActions
    {
        private @CustomInput m_Wrapper;
        public JoysticActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Joystic_move;
        public InputActionMap Get() { return m_Wrapper.m_Joystic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoysticActions set) { return set.Get(); }
        public void SetCallbacks(IJoysticActions instance)
        {
            if (m_Wrapper.m_JoysticActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_JoysticActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_JoysticActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_JoysticActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_JoysticActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
            }
        }
    }
    public JoysticActions @Joystic => new JoysticActions(this);
    public interface IJoysticActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
