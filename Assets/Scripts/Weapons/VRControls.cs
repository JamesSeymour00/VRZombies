//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/VRControls.inputactions
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

public partial class @VRControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @VRControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VRControls"",
    ""maps"": [
        {
            ""name"": ""VRPlayer"",
            ""id"": ""d2322a0c-f30a-41d5-a000-1ac8a64f5ef2"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""da21a405-3e9c-42ff-adf1-e28870720f97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2437808a-3974-4a6f-b114-63f3831f05bf"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // VRPlayer
        m_VRPlayer = asset.FindActionMap("VRPlayer", throwIfNotFound: true);
        m_VRPlayer_Shoot = m_VRPlayer.FindAction("Shoot", throwIfNotFound: true);
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

    // VRPlayer
    private readonly InputActionMap m_VRPlayer;
    private List<IVRPlayerActions> m_VRPlayerActionsCallbackInterfaces = new List<IVRPlayerActions>();
    private readonly InputAction m_VRPlayer_Shoot;
    public struct VRPlayerActions
    {
        private @VRControls m_Wrapper;
        public VRPlayerActions(@VRControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_VRPlayer_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_VRPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VRPlayerActions set) { return set.Get(); }
        public void AddCallbacks(IVRPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_VRPlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VRPlayerActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IVRPlayerActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IVRPlayerActions instance)
        {
            if (m_Wrapper.m_VRPlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVRPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_VRPlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VRPlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VRPlayerActions @VRPlayer => new VRPlayerActions(this);
    public interface IVRPlayerActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
