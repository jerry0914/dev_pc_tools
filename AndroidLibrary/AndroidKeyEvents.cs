﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.AndroidLibrary
{
    public static class AndroidKeyEvents
    {
        /** Key code constant: Unknown key code. */
        public static readonly int KEYCODE_UNKNOWN = 0;
        /** Key code constant: Soft Left key.
         * Usually situated below the display on phones and used as a multi-function
         * feature key for selecting a software defined function shown on the bottom left
         * of the display. */
        public static readonly int KEYCODE_SOFT_LEFT = 1;
        /** Key code constant: Soft Right key.
         * Usually situated below the display on phones and used as a multi-function
         * feature key for selecting a software defined function shown on the bottom right
         * of the display. */
        public static readonly int KEYCODE_SOFT_RIGHT = 2;
        /** Key code constant: Home key.
         * This key is handled by the framework and is never delivered to applications. */
        public static readonly int KEYCODE_HOME = 3;
        /** Key code constant: Back key. */
        public static readonly int KEYCODE_BACK = 4;
        /** Key code constant: Call key. */
        public static readonly int KEYCODE_CALL = 5;
        /** Key code constant: End Call key. */
        public static readonly int KEYCODE_ENDCALL = 6;
        /** Key code constant: '0' key. */
        public static readonly int KEYCODE_0 = 7;
        /** Key code constant: '1' key. */
        public static readonly int KEYCODE_1 = 8;
        /** Key code constant: '2' key. */
        public static readonly int KEYCODE_2 = 9;
        /** Key code constant: '3' key. */
        public static readonly int KEYCODE_3 = 10;
        /** Key code constant: '4' key. */
        public static readonly int KEYCODE_4 = 11;
        /** Key code constant: '5' key. */
        public static readonly int KEYCODE_5 = 12;
        /** Key code constant: '6' key. */
        public static readonly int KEYCODE_6 = 13;
        /** Key code constant: '7' key. */
        public static readonly int KEYCODE_7 = 14;
        /** Key code constant: '8' key. */
        public static readonly int KEYCODE_8 = 15;
        /** Key code constant: '9' key. */
        public static readonly int KEYCODE_9 = 16;
        /** Key code constant: '*' key. */
        public static readonly int KEYCODE_STAR = 17;
        /** Key code constant: '#' key. */
        public static readonly int KEYCODE_POUND = 18;
        /** Key code constant: Directional Pad Up key.
         * May also be synthesized from trackball motions. */
        public static readonly int KEYCODE_DPAD_UP = 19;
        /** Key code constant: Directional Pad Down key.
         * May also be synthesized from trackball motions. */
        public static readonly int KEYCODE_DPAD_DOWN = 20;
        /** Key code constant: Directional Pad Left key.
         * May also be synthesized from trackball motions. */
        public static readonly int KEYCODE_DPAD_LEFT = 21;
        /** Key code constant: Directional Pad Right key.
         * May also be synthesized from trackball motions. */
        public static readonly int KEYCODE_DPAD_RIGHT = 22;
        /** Key code constant: Directional Pad Center key.
         * May also be synthesized from trackball motions. */
        public static readonly int KEYCODE_DPAD_CENTER = 23;
        /** Key code constant: Volume Up key.
         * Adjusts the speaker volume up. */
        public static readonly int KEYCODE_VOLUME_UP = 24;
        /** Key code constant: Volume Down key.
         * Adjusts the speaker volume down. */
        public static readonly int KEYCODE_VOLUME_DOWN = 25;
        /** Key code constant: Power key. */
        public static readonly int KEYCODE_POWER = 26;
        /** Key code constant: Camera key.
         * Used to launch a camera application or take pictures. */
        public static readonly int KEYCODE_CAMERA = 27;
        /** Key code constant: Clear key. */
        public static readonly int KEYCODE_CLEAR = 28;
        /** Key code constant: 'A' key. */
        public static readonly int KEYCODE_A = 29;
        /** Key code constant: 'B' key. */
        public static readonly int KEYCODE_B = 30;
        /** Key code constant: 'C' key. */
        public static readonly int KEYCODE_C = 31;
        /** Key code constant: 'D' key. */
        public static readonly int KEYCODE_D = 32;
        /** Key code constant: 'E' key. */
        public static readonly int KEYCODE_E = 33;
        /** Key code constant: 'F' key. */
        public static readonly int KEYCODE_F = 34;
        /** Key code constant: 'G' key. */
        public static readonly int KEYCODE_G = 35;
        /** Key code constant: 'H' key. */
        public static readonly int KEYCODE_H = 36;
        /** Key code constant: 'I' key. */
        public static readonly int KEYCODE_I = 37;
        /** Key code constant: 'J' key. */
        public static readonly int KEYCODE_J = 38;
        /** Key code constant: 'K' key. */
        public static readonly int KEYCODE_K = 39;
        /** Key code constant: 'L' key. */
        public static readonly int KEYCODE_L = 40;
        /** Key code constant: 'M' key. */
        public static readonly int KEYCODE_M = 41;
        /** Key code constant: 'N' key. */
        public static readonly int KEYCODE_N = 42;
        /** Key code constant: 'O' key. */
        public static readonly int KEYCODE_O = 43;
        /** Key code constant: 'P' key. */
        public static readonly int KEYCODE_P = 44;
        /** Key code constant: 'Q' key. */
        public static readonly int KEYCODE_Q = 45;
        /** Key code constant: 'R' key. */
        public static readonly int KEYCODE_R = 46;
        /** Key code constant: 'S' key. */
        public static readonly int KEYCODE_S = 47;
        /** Key code constant: 'T' key. */
        public static readonly int KEYCODE_T = 48;
        /** Key code constant: 'U' key. */
        public static readonly int KEYCODE_U = 49;
        /** Key code constant: 'V' key. */
        public static readonly int KEYCODE_V = 50;
        /** Key code constant: 'W' key. */
        public static readonly int KEYCODE_W = 51;
        /** Key code constant: 'X' key. */
        public static readonly int KEYCODE_X = 52;
        /** Key code constant: 'Y' key. */
        public static readonly int KEYCODE_Y = 53;
        /** Key code constant: 'Z' key. */
        public static readonly int KEYCODE_Z = 54;
        /** Key code constant: ',' key. */
        public static readonly int KEYCODE_COMMA = 55;
        /** Key code constant: '.' key. */
        public static readonly int KEYCODE_PERIOD = 56;
        /** Key code constant: Left Alt modifier key. */
        public static readonly int KEYCODE_ALT_LEFT = 57;
        /** Key code constant: Right Alt modifier key. */
        public static readonly int KEYCODE_ALT_RIGHT = 58;
        /** Key code constant: Left Shift modifier key. */
        public static readonly int KEYCODE_SHIFT_LEFT = 59;
        /** Key code constant: Right Shift modifier key. */
        public static readonly int KEYCODE_SHIFT_RIGHT = 60;
        /** Key code constant: Tab key. */
        public static readonly int KEYCODE_TAB = 61;
        /** Key code constant: Space key. */
        public static readonly int KEYCODE_SPACE = 62;
        /** Key code constant: Symbol modifier key.
         * Used to enter alternate symbols. */
        public static readonly int KEYCODE_SYM = 63;
        /** Key code constant: Explorer special function key.
         * Used to launch a browser application. */
        public static readonly int KEYCODE_EXPLORER = 64;
        /** Key code constant: Envelope special function key.
         * Used to launch a mail application. */
        public static readonly int KEYCODE_ENVELOPE = 65;
        /** Key code constant: Enter key. */
        public static readonly int KEYCODE_ENTER = 66;
        /** Key code constant: Backspace key.
         * Deletes characters before the insertion point, unlike {@link #KEYCODE_FORWARD_DEL}. */
        public static readonly int KEYCODE_DEL = 67;
        /** Key code constant: '`' (backtick) key. */
        public static readonly int KEYCODE_GRAVE = 68;
        /** Key code constant: '-'. */
        public static readonly int KEYCODE_MINUS = 69;
        /** Key code constant: '=' key. */
        public static readonly int KEYCODE_EQUALS = 70;
        /** Key code constant: '[' key. */
        public static readonly int KEYCODE_LEFT_BRACKET = 71;
        /** Key code constant: ']' key. */
        public static readonly int KEYCODE_RIGHT_BRACKET = 72;
        /** Key code constant: '\' key. */
        public static readonly int KEYCODE_BACKSLASH = 73;
        /** Key code constant: ';' key. */
        public static readonly int KEYCODE_SEMICOLON = 74;
        /** Key code constant: ''' (apostrophe) key. */
        public static readonly int KEYCODE_APOSTROPHE = 75;
        /** Key code constant: '/' key. */
        public static readonly int KEYCODE_SLASH = 76;
        /** Key code constant: '@' key. */
        public static readonly int KEYCODE_AT = 77;
        /** Key code constant: Number modifier key.
         * Used to enter numeric symbols.
         * This key is not Num Lock; it is more like {@link #KEYCODE_ALT_LEFT} and is
         * interpreted as an ALT key by {@link android.text.method.MetaKeyKeyListener}. */
        public static readonly int KEYCODE_NUM = 78;
        /** Key code constant: Headset Hook key.
         * Used to hang up calls and stop media. */
        public static readonly int KEYCODE_HEADSETHOOK = 79;
        /** Key code constant: Camera Focus key.
         * Used to focus the camera. */
        public static readonly int KEYCODE_FOCUS = 80;   // *Camera* focus
        /** Key code constant: '+' key. */
        public static readonly int KEYCODE_PLUS = 81;
        /** Key code constant: Menu key. */
        public static readonly int KEYCODE_MENU = 82;
        /** Key code constant: Notification key. */
        public static readonly int KEYCODE_NOTIFICATION = 83;
        /** Key code constant: Search key. */
        public static readonly int KEYCODE_SEARCH = 84;
        /** Key code constant: Play/Pause media key. */
        public static readonly int KEYCODE_MEDIA_PLAY_PAUSE = 85;
        /** Key code constant: Stop media key. */
        public static readonly int KEYCODE_MEDIA_STOP = 86;
        /** Key code constant: Play Next media key. */
        public static readonly int KEYCODE_MEDIA_NEXT = 87;
        /** Key code constant: Play Previous media key. */
        public static readonly int KEYCODE_MEDIA_PREVIOUS = 88;
        /** Key code constant: Rewind media key. */
        public static readonly int KEYCODE_MEDIA_REWIND = 89;
        /** Key code constant: Fast Forward media key. */
        public static readonly int KEYCODE_MEDIA_FAST_FORWARD = 90;
        /** Key code constant: Mute key.
         * Mutes the microphone, unlike {@link #KEYCODE_VOLUME_MUTE}. */
        public static readonly int KEYCODE_MUTE = 91;
        /** Key code constant: Page Up key. */
        public static readonly int KEYCODE_PAGE_UP = 92;
        /** Key code constant: Page Down key. */
        public static readonly int KEYCODE_PAGE_DOWN = 93;
        /** Key code constant: Picture Symbols modifier key.
         * Used to switch symbol sets (Emoji, Kao-moji). */
        public static readonly int KEYCODE_PICTSYMBOLS = 94;   // switch symbol-sets (Emoji,Kao-moji)
        /** Key code constant: Switch Charset modifier key.
         * Used to switch character sets (Kanji, Katakana). */
        public static readonly int KEYCODE_SWITCH_CHARSET = 95;   // switch char-sets (Kanji,Katakana)
        /** Key code constant: A Button key.
         * On a game controller, the A button should be either the button labeled A
         * or the first button on the bottom row of controller buttons. */
        public static readonly int KEYCODE_BUTTON_A = 96;
        /** Key code constant: B Button key.
         * On a game controller, the B button should be either the button labeled B
         * or the second button on the bottom row of controller buttons. */
        public static readonly int KEYCODE_BUTTON_B = 97;
        /** Key code constant: C Button key.
         * On a game controller, the C button should be either the button labeled C
         * or the third button on the bottom row of controller buttons. */
        public static readonly int KEYCODE_BUTTON_C = 98;
        /** Key code constant: X Button key.
         * On a game controller, the X button should be either the button labeled X
         * or the first button on the upper row of controller buttons. */
        public static readonly int KEYCODE_BUTTON_X = 99;
        /** Key code constant: Y Button key.
         * On a game controller, the Y button should be either the button labeled Y
         * or the second button on the upper row of controller buttons. */
        public static readonly int KEYCODE_BUTTON_Y = 100;
        /** Key code constant: Z Button key.
         * On a game controller, the Z button should be either the button labeled Z
         * or the third button on the upper row of controller buttons. */
        public static readonly int KEYCODE_BUTTON_Z = 101;
        /** Key code constant: L1 Button key.
         * On a game controller, the L1 button should be either the button labeled L1 (or L)
         * or the top left trigger button. */
        public static readonly int KEYCODE_BUTTON_L1 = 102;
        /** Key code constant: R1 Button key.
         * On a game controller, the R1 button should be either the button labeled R1 (or R)
         * or the top right trigger button. */
        public static readonly int KEYCODE_BUTTON_R1 = 103;
        /** Key code constant: L2 Button key.
         * On a game controller, the L2 button should be either the button labeled L2
         * or the bottom left trigger button. */
        public static readonly int KEYCODE_BUTTON_L2 = 104;
        /** Key code constant: R2 Button key.
         * On a game controller, the R2 button should be either the button labeled R2
         * or the bottom right trigger button. */
        public static readonly int KEYCODE_BUTTON_R2 = 105;
        /** Key code constant: Left Thumb Button key.
         * On a game controller, the left thumb button indicates that the left (or only)
         * joystick is pressed. */
        public static readonly int KEYCODE_BUTTON_THUMBL = 106;
        /** Key code constant: Right Thumb Button key.
         * On a game controller, the right thumb button indicates that the right
         * joystick is pressed. */
        public static readonly int KEYCODE_BUTTON_THUMBR = 107;
        /** Key code constant: Start Button key.
         * On a game controller, the button labeled Start. */
        public static readonly int KEYCODE_BUTTON_START = 108;
        /** Key code constant: Select Button key.
         * On a game controller, the button labeled Select. */
        public static readonly int KEYCODE_BUTTON_SELECT = 109;
        /** Key code constant: Mode Button key.
         * On a game controller, the button labeled Mode. */
        public static readonly int KEYCODE_BUTTON_MODE = 110;
        /** Key code constant: Escape key. */
        public static readonly int KEYCODE_ESCAPE = 111;
        /** Key code constant: Forward Delete key.
         * Deletes characters ahead of the insertion point, unlike {@link #KEYCODE_DEL}. */
        public static readonly int KEYCODE_FORWARD_DEL = 112;
        /** Key code constant: Left Control modifier key. */
        public static readonly int KEYCODE_CTRL_LEFT = 113;
        /** Key code constant: Right Control modifier key. */
        public static readonly int KEYCODE_CTRL_RIGHT = 114;
        /** Key code constant: Caps Lock key. */
        public static readonly int KEYCODE_CAPS_LOCK = 115;
        /** Key code constant: Scroll Lock key. */
        public static readonly int KEYCODE_SCROLL_LOCK = 116;
        /** Key code constant: Left Meta modifier key. */
        public static readonly int KEYCODE_META_LEFT = 117;
        /** Key code constant: Right Meta modifier key. */
        public static readonly int KEYCODE_META_RIGHT = 118;
        /** Key code constant: Function modifier key. */
        public static readonly int KEYCODE_FUNCTION = 119;
        /** Key code constant: System Request / Print Screen key. */
        public static readonly int KEYCODE_SYSRQ = 120;
        /** Key code constant: Break / Pause key. */
        public static readonly int KEYCODE_BREAK = 121;
        /** Key code constant: Home Movement key.
         * Used for scrolling or moving the cursor around to the start of a line
         * or to the top of a list. */
        public static readonly int KEYCODE_MOVE_HOME = 122;
        /** Key code constant: End Movement key.
         * Used for scrolling or moving the cursor around to the end of a line
         * or to the bottom of a list. */
        public static readonly int KEYCODE_MOVE_END = 123;
        /** Key code constant: Insert key.
         * Toggles insert / overwrite edit mode. */
        public static readonly int KEYCODE_INSERT = 124;
        /** Key code constant: Forward key.
         * Navigates forward in the history stack.  Complement of {@link #KEYCODE_BACK}. */
        public static readonly int KEYCODE_FORWARD = 125;
        /** Key code constant: Play media key. */
        public static readonly int KEYCODE_MEDIA_PLAY = 126;
        /** Key code constant: Pause media key. */
        public static readonly int KEYCODE_MEDIA_PAUSE = 127;
        /** Key code constant: Close media key.
         * May be used to close a CD tray, for example. */
        public static readonly int KEYCODE_MEDIA_CLOSE = 128;
        /** Key code constant: Eject media key.
         * May be used to eject a CD tray, for example. */
        public static readonly int KEYCODE_MEDIA_EJECT = 129;
        /** Key code constant: Record media key. */
        public static readonly int KEYCODE_MEDIA_RECORD = 130;
        /** Key code constant: F1 key. */
        public static readonly int KEYCODE_F1 = 131;
        /** Key code constant: F2 key. */
        public static readonly int KEYCODE_F2 = 132;
        /** Key code constant: F3 key. */
        public static readonly int KEYCODE_F3 = 133;
        /** Key code constant: F4 key. */
        public static readonly int KEYCODE_F4 = 134;
        /** Key code constant: F5 key. */
        public static readonly int KEYCODE_F5 = 135;
        /** Key code constant: F6 key. */
        public static readonly int KEYCODE_F6 = 136;
        /** Key code constant: F7 key. */
        public static readonly int KEYCODE_F7 = 137;
        /** Key code constant: F8 key. */
        public static readonly int KEYCODE_F8 = 138;
        /** Key code constant: F9 key. */
        public static readonly int KEYCODE_F9 = 139;
        /** Key code constant: F10 key. */
        public static readonly int KEYCODE_F10 = 140;
        /** Key code constant: F11 key. */
        public static readonly int KEYCODE_F11 = 141;
        /** Key code constant: F12 key. */
        public static readonly int KEYCODE_F12 = 142;
        /** Key code constant: Num Lock key.
         * This is the Num Lock key; it is different from {@link #KEYCODE_NUM}.
         * This key alters the behavior of other keys on the numeric keypad. */
        public static readonly int KEYCODE_NUM_LOCK = 143;
        /** Key code constant: Numeric keypad '0' key. */
        public static readonly int KEYCODE_NUMPAD_0 = 144;
        /** Key code constant: Numeric keypad '1' key. */
        public static readonly int KEYCODE_NUMPAD_1 = 145;
        /** Key code constant: Numeric keypad '2' key. */
        public static readonly int KEYCODE_NUMPAD_2 = 146;
        /** Key code constant: Numeric keypad '3' key. */
        public static readonly int KEYCODE_NUMPAD_3 = 147;
        /** Key code constant: Numeric keypad '4' key. */
        public static readonly int KEYCODE_NUMPAD_4 = 148;
        /** Key code constant: Numeric keypad '5' key. */
        public static readonly int KEYCODE_NUMPAD_5 = 149;
        /** Key code constant: Numeric keypad '6' key. */
        public static readonly int KEYCODE_NUMPAD_6 = 150;
        /** Key code constant: Numeric keypad '7' key. */
        public static readonly int KEYCODE_NUMPAD_7 = 151;
        /** Key code constant: Numeric keypad '8' key. */
        public static readonly int KEYCODE_NUMPAD_8 = 152;
        /** Key code constant: Numeric keypad '9' key. */
        public static readonly int KEYCODE_NUMPAD_9 = 153;
        /** Key code constant: Numeric keypad '/' key (for division). */
        public static readonly int KEYCODE_NUMPAD_DIVIDE = 154;
        /** Key code constant: Numeric keypad '*' key (for multiplication). */
        public static readonly int KEYCODE_NUMPAD_MULTIPLY = 155;
        /** Key code constant: Numeric keypad '-' key (for subtraction). */
        public static readonly int KEYCODE_NUMPAD_SUBTRACT = 156;
        /** Key code constant: Numeric keypad '+' key (for addition). */
        public static readonly int KEYCODE_NUMPAD_ADD = 157;
        /** Key code constant: Numeric keypad '.' key (for decimals or digit grouping). */
        public static readonly int KEYCODE_NUMPAD_DOT = 158;
        /** Key code constant: Numeric keypad ',' key (for decimals or digit grouping). */
        public static readonly int KEYCODE_NUMPAD_COMMA = 159;
        /** Key code constant: Numeric keypad Enter key. */
        public static readonly int KEYCODE_NUMPAD_ENTER = 160;
        /** Key code constant: Numeric keypad '=' key. */
        public static readonly int KEYCODE_NUMPAD_EQUALS = 161;
        /** Key code constant: Numeric keypad '(' key. */
        public static readonly int KEYCODE_NUMPAD_LEFT_PAREN = 162;
        /** Key code constant: Numeric keypad ')' key. */
        public static readonly int KEYCODE_NUMPAD_RIGHT_PAREN = 163;
        /** Key code constant: Volume Mute key.
         * Mutes the speaker, unlike {@link #KEYCODE_MUTE}.
         * This key should normally be implemented as a toggle such that the first press
         * mutes the speaker and the second press restores the original volume. */
        public static readonly int KEYCODE_VOLUME_MUTE = 164;
        /** Key code constant: Info key.
         * Common on TV remotes to show additional information related to what is
         * currently being viewed. */
        public static readonly int KEYCODE_INFO = 165;
        /** Key code constant: Channel up key.
         * On TV remotes, increments the television channel. */
        public static readonly int KEYCODE_CHANNEL_UP = 166;
        /** Key code constant: Channel down key.
         * On TV remotes, decrements the television channel. */
        public static readonly int KEYCODE_CHANNEL_DOWN = 167;
        /** Key code constant: Zoom in key. */
        public static readonly int KEYCODE_ZOOM_IN = 168;
        /** Key code constant: Zoom out key. */
        public static readonly int KEYCODE_ZOOM_OUT = 169;
        /** Key code constant: TV key.
         * On TV remotes, switches to viewing live TV. */
        public static readonly int KEYCODE_TV = 170;
        /** Key code constant: Window key.
         * On TV remotes, toggles picture-in-picture mode or other windowing functions. */
        public static readonly int KEYCODE_WINDOW = 171;
        /** Key code constant: Guide key.
         * On TV remotes, shows a programming guide. */
        public static readonly int KEYCODE_GUIDE = 172;
        /** Key code constant: DVR key.
         * On some TV remotes, switches to a DVR mode for recorded shows. */
        public static readonly int KEYCODE_DVR = 173;
        /** Key code constant: Bookmark key.
         * On some TV remotes, bookmarks content or web pages. */
        public static readonly int KEYCODE_BOOKMARK = 174;
        /** Key code constant: Toggle captions key.
         * Switches the mode for closed-captioning text, for example during television shows. */
        public static readonly int KEYCODE_CAPTIONS = 175;
        /** Key code constant: Settings key.
         * Starts the system settings activity. */
        public static readonly int KEYCODE_SETTINGS = 176;
        /** Key code constant: TV power key.
         * On TV remotes, toggles the power on a television screen. */
        public static readonly int KEYCODE_TV_POWER = 177;
        /** Key code constant: TV input key.
         * On TV remotes, switches the input on a television screen. */
        public static readonly int KEYCODE_TV_INPUT = 178;
        /** Key code constant: Set-top-box power key.
         * On TV remotes, toggles the power on an external Set-top-box. */
        public static readonly int KEYCODE_STB_POWER = 179;
        /** Key code constant: Set-top-box input key.
         * On TV remotes, switches the input mode on an external Set-top-box. */
        public static readonly int KEYCODE_STB_INPUT = 180;
        /** Key code constant: A/V Receiver power key.
         * On TV remotes, toggles the power on an external A/V Receiver. */
        public static readonly int KEYCODE_AVR_POWER = 181;
        /** Key code constant: A/V Receiver input key.
         * On TV remotes, switches the input mode on an external A/V Receiver. */
        public static readonly int KEYCODE_AVR_INPUT = 182;
        /** Key code constant: Red "programmable" key.
         * On TV remotes, acts as a contextual/programmable key. */
        public static readonly int KEYCODE_PROG_RED = 183;
        /** Key code constant: Green "programmable" key.
         * On TV remotes, actsas a contextual/programmable key. */
        public static readonly int KEYCODE_PROG_GREEN = 184;
        /** Key code constant: Yellow "programmable" key.
         * On TV remotes, acts as a contextual/programmable key. */
        public static readonly int KEYCODE_PROG_YELLOW = 185;
        /** Key code constant: Blue "programmable" key.
         * On TV remotes, acts as a contextual/programmable key. */
        public static readonly int KEYCODE_PROG_BLUE = 186;
        /** Key code constant: App switch key.
         * Should bring up the application switcher dialog. */
        public static readonly int KEYCODE_APP_SWITCH = 187;
        /** Key code constant: Generic Game Pad Button #1.*/
        public static readonly int KEYCODE_BUTTON_1 = 188;
        /** Key code constant: Generic Game Pad Button #2.*/
        public static readonly int KEYCODE_BUTTON_2 = 189;
        /** Key code constant: Generic Game Pad Button #3.*/
        public static readonly int KEYCODE_BUTTON_3 = 190;
        /** Key code constant: Generic Game Pad Button #4.*/
        public static readonly int KEYCODE_BUTTON_4 = 191;
        /** Key code constant: Generic Game Pad Button #5.*/
        public static readonly int KEYCODE_BUTTON_5 = 192;
        /** Key code constant: Generic Game Pad Button #6.*/
        public static readonly int KEYCODE_BUTTON_6 = 193;
        /** Key code constant: Generic Game Pad Button #7.*/
        public static readonly int KEYCODE_BUTTON_7 = 194;
        /** Key code constant: Generic Game Pad Button #8.*/
        public static readonly int KEYCODE_BUTTON_8 = 195;
        /** Key code constant: Generic Game Pad Button #9.*/
        public static readonly int KEYCODE_BUTTON_9 = 196;
        /** Key code constant: Generic Game Pad Button #10.*/
        public static readonly int KEYCODE_BUTTON_10 = 197;
        /** Key code constant: Generic Game Pad Button #11.*/
        public static readonly int KEYCODE_BUTTON_11 = 198;
        /** Key code constant: Generic Game Pad Button #12.*/
        public static readonly int KEYCODE_BUTTON_12 = 199;
        /** Key code constant: Generic Game Pad Button #13.*/
        public static readonly int KEYCODE_BUTTON_13 = 200;
        /** Key code constant: Generic Game Pad Button #14.*/
        public static readonly int KEYCODE_BUTTON_14 = 201;
        /** Key code constant: Generic Game Pad Button #15.*/
        public static readonly int KEYCODE_BUTTON_15 = 202;
        /** Key code constant: Generic Game Pad Button #16.*/
        public static readonly int KEYCODE_BUTTON_16 = 203;
        /** Key code constant: Language Switch key.
         * Toggles the current input language such as switching between English and Japanese on
         * a QWERTY keyboard.  On some devices, the same function may be performed by
         * pressing Shift+Spacebar. */
        public static readonly int KEYCODE_LANGUAGE_SWITCH = 204;
        /** Key code constant: Manner Mode key.
         * Toggles silent or vibrate mode on and off to make the device behave more politely
         * in certain settings such as on a crowded train.  On some devices, the key may only
         * operate when long-pressed. */
        public static readonly int KEYCODE_MANNER_MODE = 205;
        /** Key code constant: 3D Mode key.
         * Toggles the display between 2D and 3D mode. */
        public static readonly int KEYCODE_3D_MODE = 206;
        /** Key code constant: Contacts special function key.
         * Used to launch an address book application. */
        public static readonly int KEYCODE_CONTACTS = 207;
        /** Key code constant: Calendar special function key.
         * Used to launch a calendar application. */
        public static readonly int KEYCODE_CALENDAR = 208;
        /** Key code constant: Music special function key.
         * Used to launch a music player application. */
        public static readonly int KEYCODE_MUSIC = 209;
        /** Key code constant: Calculator special function key.
         * Used to launch a calculator application. */
        public static readonly int KEYCODE_CALCULATOR = 210;
        /** Key code constant: Japanese full-width / half-width key. */
        public static readonly int KEYCODE_ZENKAKU_HANKAKU = 211;
        /** Key code constant: Japanese alphanumeric key. */
        public static readonly int KEYCODE_EISU = 212;
        /** Key code constant: Japanese non-conversion key. */
        public static readonly int KEYCODE_MUHENKAN = 213;
        /** Key code constant: Japanese conversion key. */
        public static readonly int KEYCODE_HENKAN = 214;
        /** Key code constant: Japanese katakana / hiragana key. */
        public static readonly int KEYCODE_KATAKANA_HIRAGANA = 215;
        /** Key code constant: Japanese Yen key. */
        public static readonly int KEYCODE_YEN = 216;
        /** Key code constant: Japanese Ro key. */
        public static readonly int KEYCODE_RO = 217;
        /** Key code constant: Japanese kana key. */
        public static readonly int KEYCODE_KANA = 218;
        /** Key code constant: Assist key.
         * Launches the global assist activity.  Not delivered to applications. */
        public static readonly int KEYCODE_ASSIST = 219;
        /** Key code constant: Brightness Down key.
         * Adjusts the screen brightness down. */
        public static readonly int KEYCODE_BRIGHTNESS_DOWN = 220;
        /** Key code constant: Brightness Up key.
         * Adjusts the screen brightness up. */
        public static readonly int KEYCODE_BRIGHTNESS_UP = 221;
        /** Key code constant: Audio Track key
         * Switches the audio tracks. */
        public static readonly int KEYCODE_MEDIA_AUDIO_TRACK = 222;
    }
}
