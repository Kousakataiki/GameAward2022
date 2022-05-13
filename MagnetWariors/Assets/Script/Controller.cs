using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller
{
    public enum ControllerButton
    {
        A,
        B,
        X,
        Y,
        L,
        R,
        ZR,
        ZL,
        Up,
        Down,
        Left,
        Right,
        LStick,
        RStick,
        Start,
        Select,
        Max
    }

    public enum ControllerStick
    {
        LStick,
        RStick,
        Max
    }

    private static bool bVibration = false;
    private static bool KeyTrigger = false;

    // �{�^�����������u�Ԃ�True��Ԃ�
    public static bool GetKeyTrigger(ControllerButton key)
    {
        if (Gamepad.current != null)
        {
            // Y�{�^��
            switch (key)
            {
                case ControllerButton.Y:
                    KeyTrigger = Gamepad.current.buttonNorth.wasPressedThisFrame;
                    break;
                case ControllerButton.X:
                    KeyTrigger = Gamepad.current.buttonWest.wasPressedThisFrame;
                    break;
                case ControllerButton.A:
                    KeyTrigger = Gamepad.current.buttonSouth.wasPressedThisFrame;
                    break;
                case ControllerButton.B:
                    KeyTrigger = Gamepad.current.buttonEast.wasPressedThisFrame;
                    break;
                case ControllerButton.L:
                    KeyTrigger = Gamepad.current.leftShoulder.wasPressedThisFrame;
                    break;
                case ControllerButton.R:
                    KeyTrigger = Gamepad.current.rightShoulder.wasPressedThisFrame;
                    break;
                case ControllerButton.ZL:
                    KeyTrigger = Gamepad.current.leftTrigger.wasPressedThisFrame;
                    break;
                case ControllerButton.ZR:
                    KeyTrigger = Gamepad.current.rightTrigger.wasPressedThisFrame;
                    break;
                case ControllerButton.Right:
                    KeyTrigger = Gamepad.current.dpad.right.wasPressedThisFrame;
                    break;
                case ControllerButton.Left:
                    KeyTrigger = Gamepad.current.dpad.left.wasPressedThisFrame;
                    break;
                case ControllerButton.Up:
                    KeyTrigger = Gamepad.current.dpad.up.wasPressedThisFrame;
                    break;
                case ControllerButton.Down:
                    KeyTrigger = Gamepad.current.dpad.down.wasPressedThisFrame;
                    break;
                case ControllerButton.Start:
                    KeyTrigger = Gamepad.current.startButton.wasPressedThisFrame;
                    break;
                case ControllerButton.Select:
                    KeyTrigger = Gamepad.current.selectButton.wasPressedThisFrame;
                    break;
                case ControllerButton.LStick:
                    KeyTrigger = Gamepad.current.leftStickButton.wasPressedThisFrame;
                    break;
                case ControllerButton.RStick:
                    KeyTrigger = Gamepad.current.rightStickButton.wasPressedThisFrame;
                    break;
                default:
                    KeyTrigger = false;
                    break;
            }
            return KeyTrigger;
        }
        return false;
    }

    // �{�^���������Ă����True��Ԃ�
    public static bool GetKeyPress(ControllerButton key)
    {
        if (Gamepad.current != null)
        {
            // Y�{�^��
            switch (key)
            {
                case ControllerButton.Y:
                    KeyTrigger = Gamepad.current.buttonNorth.isPressed;
                    break;
                case ControllerButton.X:
                    KeyTrigger = Gamepad.current.buttonWest.isPressed;
                    break;
                case ControllerButton.A:
                    KeyTrigger = Gamepad.current.buttonSouth.isPressed;
                    break;
                case ControllerButton.B:
                    KeyTrigger = Gamepad.current.buttonEast.isPressed;
                    break;
                case ControllerButton.L:
                    KeyTrigger = Gamepad.current.leftShoulder.isPressed;
                    break;
                case ControllerButton.R:
                    KeyTrigger = Gamepad.current.rightShoulder.isPressed;
                    break;
                case ControllerButton.ZL:
                    KeyTrigger = Gamepad.current.leftTrigger.isPressed;
                    break;
                case ControllerButton.ZR:
                    KeyTrigger = Gamepad.current.rightTrigger.isPressed;
                    break;
                case ControllerButton.Right:
                    KeyTrigger = Gamepad.current.dpad.right.isPressed;
                    break;
                case ControllerButton.Left:
                    KeyTrigger = Gamepad.current.dpad.left.isPressed;
                    break;
                case ControllerButton.Up:
                    KeyTrigger = Gamepad.current.dpad.up.isPressed;
                    break;
                case ControllerButton.Down:
                    KeyTrigger = Gamepad.current.dpad.down.isPressed;
                    break;
                case ControllerButton.Start:
                    KeyTrigger = Gamepad.current.startButton.isPressed;
                    break;
                case ControllerButton.Select:
                    KeyTrigger = Gamepad.current.selectButton.isPressed;
                    break;
                case ControllerButton.LStick:
                    KeyTrigger = Gamepad.current.leftStickButton.isPressed;
                    break;
                case ControllerButton.RStick:
                    KeyTrigger = Gamepad.current.rightStickButton.isPressed;
                    break;
                default:
                    KeyTrigger = false;
                    break;
            }
            return KeyTrigger;
        }
        return false;
    }

    // �{�^���𗣂����Ƃ���True��Ԃ�
    public static bool GetKeyRelease(ControllerButton key)
    {
        if (Gamepad.current != null)
        {
            // Y�{�^��
            switch (key)
            {
                case ControllerButton.Y:
                    KeyTrigger = Gamepad.current.buttonNorth.wasReleasedThisFrame;
                    break;
                case ControllerButton.X:
                    KeyTrigger = Gamepad.current.buttonWest.wasReleasedThisFrame;
                    break;
                case ControllerButton.A:
                    KeyTrigger = Gamepad.current.buttonSouth.wasReleasedThisFrame;
                    break;
                case ControllerButton.B:
                    KeyTrigger = Gamepad.current.buttonEast.wasReleasedThisFrame;
                    break;
                case ControllerButton.L:
                    KeyTrigger = Gamepad.current.leftShoulder.wasReleasedThisFrame;
                    break;
                case ControllerButton.R:
                    KeyTrigger = Gamepad.current.rightShoulder.wasReleasedThisFrame;
                    break;
                case ControllerButton.ZL:
                    KeyTrigger = Gamepad.current.leftTrigger.wasReleasedThisFrame;
                    break;
                case ControllerButton.ZR:
                    KeyTrigger = Gamepad.current.rightTrigger.wasReleasedThisFrame;
                    break;
                case ControllerButton.Right:
                    KeyTrigger = Gamepad.current.dpad.right.wasReleasedThisFrame;
                    break;
                case ControllerButton.Left:
                    KeyTrigger = Gamepad.current.dpad.left.wasReleasedThisFrame;
                    break;
                case ControllerButton.Up:
                    KeyTrigger = Gamepad.current.dpad.up.wasReleasedThisFrame;
                    break;
                case ControllerButton.Down:
                    KeyTrigger = Gamepad.current.dpad.down.wasReleasedThisFrame;
                    break;
                case ControllerButton.Start:
                    KeyTrigger = Gamepad.current.startButton.wasReleasedThisFrame;
                    break;
                case ControllerButton.Select:
                    KeyTrigger = Gamepad.current.selectButton.wasReleasedThisFrame;
                    break;
                case ControllerButton.LStick:
                    KeyTrigger = Gamepad.current.leftStickButton.wasReleasedThisFrame;
                    break;
                case ControllerButton.RStick:
                    KeyTrigger = Gamepad.current.rightStickButton.wasReleasedThisFrame;
                    break;
                default:
                    KeyTrigger = false;
                    break;
            }
            return KeyTrigger;
        }
        return false;
    }

    // �X�e�B�b�N�̓|���Ă���l��Ԃ��B(XY���ꂼ��Max1.0f)
    public static Vector2 StickValue(ControllerStick key)
    {
        if (Gamepad.current != null)
        {
            // �E�X�e�B�b�N
            if (key == ControllerStick.RStick) return Gamepad.current.leftStick.ReadValue();
            // ���X�e�B�b�N
            if (key == ControllerStick.LStick) return Gamepad.current.leftStick.ReadValue();
        }
        return new Vector2(0.0f, 0.0f);
    }

    // �R���g���[���[��U��������
    // ��P�����F����g�U��(�U�����傫���A�񐔂����Ȃ�)
    // ��Q�����F�����g�U��(�U�����������A�񐔂�����)�@���U���͎蓮��0�ɂ���K�v������
    public static void Vibration(float lowFrequency, float highFrequency)
    {
        if(!bVibration)
            Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);
    }

    // �R���g���[���[����莞�ԐU��������
    // ��P�����F����g�U��(�U�����傫���A�񐔂����Ȃ�)
    // ��Q�����F�����g�U��(�U�����������A�񐔂�����)
    // ��R�����F�U�������鎞��(�b)
    public static IEnumerator VibrationCor(float lowFrequency, float highFrequency , float Time)
    {
        bVibration = true;
        Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);
        yield return new WaitForSeconds(Time);
        Gamepad.current.SetMotorSpeeds(0, 0);
        bVibration = false;
    }
    
}

