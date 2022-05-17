// GENERATED AUTOMATICALLY FROM 'Assets/04_Script/TouchControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControlls"",
    ""maps"": [
        {
            ""name"": ""UI_System"",
            ""id"": ""a034a35b-a831-4f94-847c-1d2a3cb6d819"",
            ""actions"": [
                {
                    ""name"": ""PressButton"",
                    ""type"": ""Button"",
                    ""id"": ""242139ee-6b31-4c2b-b938-ae68e74bafb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cbc2baf3-2401-40f0-8a03-bb5f26259091"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""PressButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""1a778eab-b90a-4134-8e68-4888e02e7b26"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""be33cded-60da-4abf-866a-b83da38b4e44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""b46d5d14-da56-4ef9-97e8-811a91561d1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atk"",
                    ""type"": ""Button"",
                    ""id"": ""b49baec0-0674-46d9-b7f9-82c080b24620"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""78851c43-c0f3-464a-bcbb-4b2d74e11f01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2),Hold""
                },
                {
                    ""name"": ""Act"",
                    ""type"": ""Button"",
                    ""id"": ""2c98929e-aa62-4f06-873b-051d4242e36a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abd9b80e-ff0c-45c4-861a-672c7d9e26bd"",
                    ""path"": ""<Touchscreen>/touch1/indirectTouch"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e3a2a94-c95f-405f-b499-e335600e07d3"",
                    ""path"": ""<Touchscreen>/touch2/indirectTouch"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""245d203e-b047-4c8f-a2f9-307ce9f7f685"",
                    ""path"": ""<Touchscreen>/touch3/indirectTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""Atk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6290fad-c78e-4347-8fe1-c120aec311bb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""Atk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb75d0c1-3496-40d4-8f1b-09799ca24595"",
                    ""path"": ""<Touchscreen>/touch4/indirectTouch"",
                    ""interactions"": ""Press(behavior=2),Hold"",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""728338d8-fb21-4bff-a9da-fca165638682"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a920b3b-57da-4602-8dee-957bb2d1bd15"",
                    ""path"": ""<Touchscreen>/touch5/indirectTouch"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""Act"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0200cb5-80bf-4823-bc4a-1f6eef34f577"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Android"",
                    ""action"": ""Act"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Android"",
            ""bindingGroup"": ""Android"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI_System
        m_UI_System = asset.FindActionMap("UI_System", throwIfNotFound: true);
        m_UI_System_PressButton = m_UI_System.FindAction("PressButton", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveLeft = m_Player.FindAction("MoveLeft", throwIfNotFound: true);
        m_Player_MoveRight = m_Player.FindAction("MoveRight", throwIfNotFound: true);
        m_Player_Atk = m_Player.FindAction("Atk", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
        m_Player_Act = m_Player.FindAction("Act", throwIfNotFound: true);
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

    // UI_System
    private readonly InputActionMap m_UI_System;
    private IUI_SystemActions m_UI_SystemActionsCallbackInterface;
    private readonly InputAction m_UI_System_PressButton;
    public struct UI_SystemActions
    {
        private @TouchControlls m_Wrapper;
        public UI_SystemActions(@TouchControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressButton => m_Wrapper.m_UI_System_PressButton;
        public InputActionMap Get() { return m_Wrapper.m_UI_System; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UI_SystemActions set) { return set.Get(); }
        public void SetCallbacks(IUI_SystemActions instance)
        {
            if (m_Wrapper.m_UI_SystemActionsCallbackInterface != null)
            {
                @PressButton.started -= m_Wrapper.m_UI_SystemActionsCallbackInterface.OnPressButton;
                @PressButton.performed -= m_Wrapper.m_UI_SystemActionsCallbackInterface.OnPressButton;
                @PressButton.canceled -= m_Wrapper.m_UI_SystemActionsCallbackInterface.OnPressButton;
            }
            m_Wrapper.m_UI_SystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressButton.started += instance.OnPressButton;
                @PressButton.performed += instance.OnPressButton;
                @PressButton.canceled += instance.OnPressButton;
            }
        }
    }
    public UI_SystemActions @UI_System => new UI_SystemActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveLeft;
    private readonly InputAction m_Player_MoveRight;
    private readonly InputAction m_Player_Atk;
    private readonly InputAction m_Player_Block;
    private readonly InputAction m_Player_Act;
    public struct PlayerActions
    {
        private @TouchControlls m_Wrapper;
        public PlayerActions(@TouchControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_Player_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Player_MoveRight;
        public InputAction @Atk => m_Wrapper.m_Player_Atk;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputAction @Act => m_Wrapper.m_Player_Act;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @Atk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtk;
                @Atk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtk;
                @Atk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAtk;
                @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Act.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAct;
                @Act.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAct;
                @Act.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAct;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Atk.started += instance.OnAtk;
                @Atk.performed += instance.OnAtk;
                @Atk.canceled += instance.OnAtk;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Act.started += instance.OnAct;
                @Act.performed += instance.OnAct;
                @Act.canceled += instance.OnAct;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_AndroidSchemeIndex = -1;
    public InputControlScheme AndroidScheme
    {
        get
        {
            if (m_AndroidSchemeIndex == -1) m_AndroidSchemeIndex = asset.FindControlSchemeIndex("Android");
            return asset.controlSchemes[m_AndroidSchemeIndex];
        }
    }
    public interface IUI_SystemActions
    {
        void OnPressButton(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnAtk(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnAct(InputAction.CallbackContext context);
    }
}
