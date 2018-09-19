using System.Collections.Generic;
using System.Linq;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models
{
    public class KeyboardInputKey
    {
        public static KeyboardInputKey A { get; } = new KeyboardInputKey("A");
        public static KeyboardInputKey Add { get; } = new KeyboardInputKey("Add");

        public static IReadOnlyCollection<KeyboardInputKey> AllKeys
        {
            get
            {
                var keyboardInputKeyType = typeof(KeyboardInputKey);
                var result = keyboardInputKeyType.GetProperties()
                    .Where(f => f.PropertyType == keyboardInputKeyType)
                    .Select(prop => prop.GetValue(null))
                    .Cast<KeyboardInputKey>()
                    .ToList();

                return result;
            }
        }

        public static KeyboardInputKey Alt { get; } = new KeyboardInputKey("Alt");
        public static KeyboardInputKey Apps { get; } = new KeyboardInputKey("Apps");
        public static KeyboardInputKey Attn { get; } = new KeyboardInputKey("Attn");
        public static KeyboardInputKey B { get; } = new KeyboardInputKey("B");
        public static KeyboardInputKey Back { get; } = new KeyboardInputKey("Back");
        public static KeyboardInputKey BrowserBack { get; } = new KeyboardInputKey("BrowserBack");
        public static KeyboardInputKey BrowserFavorites { get; } = new KeyboardInputKey("BrowserFavorites");
        public static KeyboardInputKey BrowserForward { get; } = new KeyboardInputKey("BrowserForward");
        public static KeyboardInputKey BrowserHome { get; } = new KeyboardInputKey("BrowserHome");
        public static KeyboardInputKey BrowserRefresh { get; } = new KeyboardInputKey("BrowserRefresh");
        public static KeyboardInputKey BrowserSearch { get; } = new KeyboardInputKey("BrowserSearch");
        public static KeyboardInputKey BrowserStop { get; } = new KeyboardInputKey("BrowserStop");
        public static KeyboardInputKey C { get; } = new KeyboardInputKey("C");
        public static KeyboardInputKey Cancel { get; } = new KeyboardInputKey("Cancel");
        public static KeyboardInputKey Capital { get; } = new KeyboardInputKey("Capital");
        public static KeyboardInputKey Clear { get; } = new KeyboardInputKey("Clear");
        public static KeyboardInputKey Control { get; } = new KeyboardInputKey("Control");
        public static KeyboardInputKey ControlKey { get; } = new KeyboardInputKey("ControlKey");
        public static KeyboardInputKey Crsel { get; } = new KeyboardInputKey("Crsel");
        public static KeyboardInputKey D { get; } = new KeyboardInputKey("D");
        public static KeyboardInputKey D0 { get; } = new KeyboardInputKey("D0");
        public static KeyboardInputKey D1 { get; } = new KeyboardInputKey("D1");
        public static KeyboardInputKey D2 { get; } = new KeyboardInputKey("D2");
        public static KeyboardInputKey D3 { get; } = new KeyboardInputKey("D3");
        public static KeyboardInputKey D4 { get; } = new KeyboardInputKey("D4");
        public static KeyboardInputKey D5 { get; } = new KeyboardInputKey("D5");
        public static KeyboardInputKey D6 { get; } = new KeyboardInputKey("D6");
        public static KeyboardInputKey D7 { get; } = new KeyboardInputKey("D7");
        public static KeyboardInputKey D8 { get; } = new KeyboardInputKey("D8");
        public static KeyboardInputKey D9 { get; } = new KeyboardInputKey("D9");
        public static KeyboardInputKey Decimal { get; } = new KeyboardInputKey("Decimal");
        public static KeyboardInputKey Delete { get; } = new KeyboardInputKey("Delete");
        public static KeyboardInputKey Divide { get; } = new KeyboardInputKey("Divide");
        public static KeyboardInputKey Down { get; } = new KeyboardInputKey("Down");
        public static KeyboardInputKey E { get; } = new KeyboardInputKey("E");
        public static KeyboardInputKey End { get; } = new KeyboardInputKey("End");
        public static KeyboardInputKey EraseEof { get; } = new KeyboardInputKey("EraseEof");
        public static KeyboardInputKey Escape { get; } = new KeyboardInputKey("Escape");
        public static KeyboardInputKey Execute { get; } = new KeyboardInputKey("Execute");
        public static KeyboardInputKey Exsel { get; } = new KeyboardInputKey("Exsel");
        public static KeyboardInputKey F { get; } = new KeyboardInputKey("F");
        public static KeyboardInputKey F1 { get; } = new KeyboardInputKey("F1");
        public static KeyboardInputKey F10 { get; } = new KeyboardInputKey("F10");
        public static KeyboardInputKey F11 { get; } = new KeyboardInputKey("F11");
        public static KeyboardInputKey F12 { get; } = new KeyboardInputKey("F12");
        public static KeyboardInputKey F13 { get; } = new KeyboardInputKey("F13");
        public static KeyboardInputKey F14 { get; } = new KeyboardInputKey("F14");
        public static KeyboardInputKey F15 { get; } = new KeyboardInputKey("F15");
        public static KeyboardInputKey F16 { get; } = new KeyboardInputKey("F16");
        public static KeyboardInputKey F17 { get; } = new KeyboardInputKey("F17");
        public static KeyboardInputKey F18 { get; } = new KeyboardInputKey("F18");
        public static KeyboardInputKey F19 { get; } = new KeyboardInputKey("F19");
        public static KeyboardInputKey F2 { get; } = new KeyboardInputKey("F2");
        public static KeyboardInputKey F20 { get; } = new KeyboardInputKey("F20");
        public static KeyboardInputKey F21 { get; } = new KeyboardInputKey("F21");
        public static KeyboardInputKey F22 { get; } = new KeyboardInputKey("F22");
        public static KeyboardInputKey F23 { get; } = new KeyboardInputKey("F23");
        public static KeyboardInputKey F24 { get; } = new KeyboardInputKey("F24");
        public static KeyboardInputKey F3 { get; } = new KeyboardInputKey("F3");
        public static KeyboardInputKey F4 { get; } = new KeyboardInputKey("F4");
        public static KeyboardInputKey F5 { get; } = new KeyboardInputKey("F5");
        public static KeyboardInputKey F6 { get; } = new KeyboardInputKey("F6");
        public static KeyboardInputKey F7 { get; } = new KeyboardInputKey("F7");
        public static KeyboardInputKey F8 { get; } = new KeyboardInputKey("F8");
        public static KeyboardInputKey F9 { get; } = new KeyboardInputKey("F9");
        public static KeyboardInputKey FinalMode { get; } = new KeyboardInputKey("FinalMode");
        public static KeyboardInputKey G { get; } = new KeyboardInputKey("G");
        public static KeyboardInputKey H { get; } = new KeyboardInputKey("H");
        public static KeyboardInputKey HanjaMode { get; } = new KeyboardInputKey("HanjaMode");
        public static KeyboardInputKey Help { get; } = new KeyboardInputKey("Help");
        public static KeyboardInputKey Home { get; } = new KeyboardInputKey("Home");
        public static KeyboardInputKey I { get; } = new KeyboardInputKey("I");
        public static KeyboardInputKey IMEAceept { get; } = new KeyboardInputKey("IMEAceept");
        public static KeyboardInputKey IMEConvert { get; } = new KeyboardInputKey("IMEConvert");
        public static KeyboardInputKey IMEModeChange { get; } = new KeyboardInputKey("IMEModeChange");
        public static KeyboardInputKey IMENonconvert { get; } = new KeyboardInputKey("IMENonconvert");
        public static KeyboardInputKey Insert { get; } = new KeyboardInputKey("Insert");
        public static KeyboardInputKey J { get; } = new KeyboardInputKey("J");
        public static KeyboardInputKey JunjaMode { get; } = new KeyboardInputKey("JunjaMode");
        public static KeyboardInputKey K { get; } = new KeyboardInputKey("K");
        public static KeyboardInputKey KanaMode { get; } = new KeyboardInputKey("KanaMode");
        public static KeyboardInputKey KeyCode { get; } = new KeyboardInputKey("KeyCode");
        public static KeyboardInputKey L { get; } = new KeyboardInputKey("L");
        public static KeyboardInputKey LaunchApplication1 { get; } = new KeyboardInputKey("LaunchApplication1");
        public static KeyboardInputKey LaunchApplication2 { get; } = new KeyboardInputKey("LaunchApplication2");
        public static KeyboardInputKey LaunchMail { get; } = new KeyboardInputKey("LaunchMail");
        public static KeyboardInputKey LButton { get; } = new KeyboardInputKey("LButton");
        public static KeyboardInputKey LControlKey { get; } = new KeyboardInputKey("LControlKey");
        public static KeyboardInputKey Left { get; } = new KeyboardInputKey("Left");
        public static KeyboardInputKey LineFeed { get; } = new KeyboardInputKey("LineFeed");
        public static KeyboardInputKey LMenu { get; } = new KeyboardInputKey("LMenu");
        public static KeyboardInputKey LShiftKey { get; } = new KeyboardInputKey("LShiftKey");
        public static KeyboardInputKey LWin { get; } = new KeyboardInputKey("LWin");
        public static KeyboardInputKey M { get; } = new KeyboardInputKey("M");
        public static KeyboardInputKey MButton { get; } = new KeyboardInputKey("MButton");
        public static KeyboardInputKey MediaNextTrack { get; } = new KeyboardInputKey("MediaNextTrack");
        public static KeyboardInputKey MediaPlayPause { get; } = new KeyboardInputKey("MediaPlayPause");
        public static KeyboardInputKey MediaPreviousTrack { get; } = new KeyboardInputKey("MediaPreviousTrack");
        public static KeyboardInputKey MediaStop { get; } = new KeyboardInputKey("MediaStop");
        public static KeyboardInputKey Menu { get; } = new KeyboardInputKey("Menu");
        public static KeyboardInputKey Modifiers { get; } = new KeyboardInputKey("Modifiers");
        public static KeyboardInputKey Multiply { get; } = new KeyboardInputKey("Multiply");
        public static KeyboardInputKey N { get; } = new KeyboardInputKey("N");
        public string NativeRepresentation { get; }
        public static KeyboardInputKey Next { get; } = new KeyboardInputKey("Next");
        public static KeyboardInputKey NoName { get; } = new KeyboardInputKey("NoName");
        public static KeyboardInputKey None { get; } = new KeyboardInputKey("None");
        public static KeyboardInputKey NumLock { get; } = new KeyboardInputKey("NumLock");
        public static KeyboardInputKey NumPad0 { get; } = new KeyboardInputKey("NumPad0");
        public static KeyboardInputKey NumPad1 { get; } = new KeyboardInputKey("NumPad1");
        public static KeyboardInputKey NumPad2 { get; } = new KeyboardInputKey("NumPad2");
        public static KeyboardInputKey NumPad3 { get; } = new KeyboardInputKey("NumPad3");
        public static KeyboardInputKey NumPad4 { get; } = new KeyboardInputKey("NumPad4");
        public static KeyboardInputKey NumPad5 { get; } = new KeyboardInputKey("NumPad5");
        public static KeyboardInputKey NumPad6 { get; } = new KeyboardInputKey("NumPad6");
        public static KeyboardInputKey NumPad7 { get; } = new KeyboardInputKey("NumPad7");
        public static KeyboardInputKey NumPad8 { get; } = new KeyboardInputKey("NumPad8");
        public static KeyboardInputKey NumPad9 { get; } = new KeyboardInputKey("NumPad9");
        public static KeyboardInputKey O { get; } = new KeyboardInputKey("O");
        public static KeyboardInputKey Oem1 { get; } = new KeyboardInputKey("Oem1");
        public static KeyboardInputKey Oem5 { get; } = new KeyboardInputKey("Oem5");
        public static KeyboardInputKey Oem6 { get; } = new KeyboardInputKey("Oem6");
        public static KeyboardInputKey Oem7 { get; } = new KeyboardInputKey("Oem7");
        public static KeyboardInputKey Oem8 { get; } = new KeyboardInputKey("Oem8");
        public static KeyboardInputKey OemBackslash { get; } = new KeyboardInputKey("OemBackslash");
        public static KeyboardInputKey OemClear { get; } = new KeyboardInputKey("OemClear");
        public static KeyboardInputKey Oemcomma { get; } = new KeyboardInputKey("Oemcomma");
        public static KeyboardInputKey OemMinus { get; } = new KeyboardInputKey("OemMinus");
        public static KeyboardInputKey OemOpenBrackets { get; } = new KeyboardInputKey("OemOpenBrackets");
        public static KeyboardInputKey OemPeriod { get; } = new KeyboardInputKey("OemPeriod");
        public static KeyboardInputKey Oemplus { get; } = new KeyboardInputKey("Oemplus");
        public static KeyboardInputKey OemQuestion { get; } = new KeyboardInputKey("OemQuestion");
        public static KeyboardInputKey Oemtilde { get; } = new KeyboardInputKey("Oemtilde");
        public static KeyboardInputKey P { get; } = new KeyboardInputKey("P");
        public static KeyboardInputKey Pa1 { get; } = new KeyboardInputKey("Pa1");
        public static KeyboardInputKey Packet { get; } = new KeyboardInputKey("Packet");
        public static KeyboardInputKey PageUp { get; } = new KeyboardInputKey("PageUp");
        public static KeyboardInputKey Pause { get; } = new KeyboardInputKey("Pause");
        public static KeyboardInputKey Play { get; } = new KeyboardInputKey("Play");
        public static KeyboardInputKey Print { get; } = new KeyboardInputKey("Print");
        public static KeyboardInputKey PrintScreen { get; } = new KeyboardInputKey("PrintScreen");
        public static KeyboardInputKey ProcessKey { get; } = new KeyboardInputKey("ProcessKey");
        public static KeyboardInputKey Q { get; } = new KeyboardInputKey("Q");
        public static KeyboardInputKey R { get; } = new KeyboardInputKey("R");
        public static KeyboardInputKey RButton { get; } = new KeyboardInputKey("RButton");
        public static KeyboardInputKey RControlKey { get; } = new KeyboardInputKey("RControlKey");
        public static KeyboardInputKey Return { get; } = new KeyboardInputKey("Return");
        public static KeyboardInputKey Right { get; } = new KeyboardInputKey("Right");
        public static KeyboardInputKey RMenu { get; } = new KeyboardInputKey("RMenu");
        public static KeyboardInputKey RShiftKey { get; } = new KeyboardInputKey("RShiftKey");
        public static KeyboardInputKey RWin { get; } = new KeyboardInputKey("RWin");
        public static KeyboardInputKey S { get; } = new KeyboardInputKey("S");
        public static KeyboardInputKey Scroll { get; } = new KeyboardInputKey("Scroll");
        public static KeyboardInputKey Select { get; } = new KeyboardInputKey("Select");
        public static KeyboardInputKey SelectMedia { get; } = new KeyboardInputKey("SelectMedia");
        public static KeyboardInputKey Separator { get; } = new KeyboardInputKey("Separator");
        public static KeyboardInputKey Shift { get; } = new KeyboardInputKey("Shift");
        public static KeyboardInputKey ShiftKey { get; } = new KeyboardInputKey("ShiftKey");
        public static KeyboardInputKey Sleep { get; } = new KeyboardInputKey("Sleep");
        public static KeyboardInputKey Space { get; } = new KeyboardInputKey("Space");
        public static KeyboardInputKey Subtract { get; } = new KeyboardInputKey("Subtract");
        public static KeyboardInputKey T { get; } = new KeyboardInputKey("T");
        public static KeyboardInputKey Tab { get; } = new KeyboardInputKey("Tab");
        public static KeyboardInputKey U { get; } = new KeyboardInputKey("U");
        public static KeyboardInputKey Up { get; } = new KeyboardInputKey("Up");
        public static KeyboardInputKey V { get; } = new KeyboardInputKey("V");
        public static KeyboardInputKey VolumeDown { get; } = new KeyboardInputKey("VolumeDown");
        public static KeyboardInputKey VolumeMute { get; } = new KeyboardInputKey("VolumeMute");
        public static KeyboardInputKey VolumeUp { get; } = new KeyboardInputKey("VolumeUp");
        public static KeyboardInputKey W { get; } = new KeyboardInputKey("W");
        public static KeyboardInputKey X { get; } = new KeyboardInputKey("X");
        public static KeyboardInputKey XButton1 { get; } = new KeyboardInputKey("XButton1");
        public static KeyboardInputKey XButton2 { get; } = new KeyboardInputKey("XButton2");
        public static KeyboardInputKey Y { get; } = new KeyboardInputKey("Y");
        public static KeyboardInputKey Z { get; } = new KeyboardInputKey("Z");
        public static KeyboardInputKey Zoom { get; } = new KeyboardInputKey("Zoom");

        private KeyboardInputKey(string nativeRepresentation)
        {
            NativeRepresentation = nativeRepresentation;
        }

        public override string ToString()
        {
            return NativeRepresentation;
        }
    }
}