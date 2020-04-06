AppleWirelessKeyboard for Wired Keyboards
=========================================

This is a simple modification of the modified AppleWirelessKeyboard helper 
utility by [gered](https://github.com/gered/AppleWirelessKeyboard) that was based on [uxsoft](http://uxsoft.cz/projects/applewirelesskeyboard/) which
also includes some basic support for the wired variant of the Apple Keyboard.

This version removes some of the custom animations and replaces them with the built in Windows animation for volume and music control. The functions for f3, and f4 originally where screenshot and opening the task manager and have been replaced by task view and action center. The f1, and f2 functions now also have functioning brightness control.

I have also changed the behaviour of the fn key in F mode such that pressing the fn key + a function key will reverse the F setting. If you have the function keys on and press the fn + f1 keys for example, the keyevent processed will be f1 whereas it would lower the brightness if the fn key wasn't pressed. If the function keys are off this behaviour is reversed.

Finally, toggling the F mode is now the fn + eject key combination. The eject key without the fn key triggers the eject operation.
