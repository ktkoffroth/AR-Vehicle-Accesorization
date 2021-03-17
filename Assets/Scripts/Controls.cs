//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.0
//     from Assets/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""ObjectPlace"",
            ""id"": ""c93d238d-9fb8-4a21-bb57-1d739bba0d70"",
            ""actions"": [
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1233b92f-5dd2-4a3e-80ae-221ae23f951a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c6606326-0939-4418-8fb3-1d5c415d73fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""753fc96b-4e72-4ad7-b1e9-9b9983de5a2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04b1df77-a75e-4906-9c10-bfccf382f0f9"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""488236c5-e699-4293-97c4-244b4e0fb14e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c14558b-4c21-4be5-a5ba-7b59a2222f6e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ObjectPlace
        m_ObjectPlace = asset.FindActionMap("ObjectPlace", throwIfNotFound: true);
        m_ObjectPlace_TouchPress = m_ObjectPlace.FindAction("TouchPress", throwIfNotFound: true);
        m_ObjectPlace_Position = m_ObjectPlace.FindAction("Position", throwIfNotFound: true);
        m_ObjectPlace_Rotation = m_ObjectPlace.FindAction("Rotation", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ObjectPlace
    private readonly InputActionMap m_ObjectPlace;
    private IObjectPlaceActions m_ObjectPlaceActionsCallbackInterface;
    private readonly InputAction m_ObjectPlace_TouchPress;
    private readonly InputAction m_ObjectPlace_Position;
    private readonly InputAction m_ObjectPlace_Rotation;
    public struct ObjectPlaceActions
    {
        private @Controls m_Wrapper;
        public ObjectPlaceActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPress => m_Wrapper.m_ObjectPlace_TouchPress;
        public InputAction @Position => m_Wrapper.m_ObjectPlace_Position;
        public InputAction @Rotation => m_Wrapper.m_ObjectPlace_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_ObjectPlace; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ObjectPlaceActions set) { return set.Get(); }
        public void SetCallbacks(IObjectPlaceActions instance)
        {
            if (m_Wrapper.m_ObjectPlaceActionsCallbackInterface != null)
            {
                @TouchPress.started -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnTouchPress;
                @Position.started -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnPosition;
                @Rotation.started -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_ObjectPlaceActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_ObjectPlaceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public ObjectPlaceActions @ObjectPlace => new ObjectPlaceActions(this);
    public interface IObjectPlaceActions
    {
        void OnTouchPress(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
}