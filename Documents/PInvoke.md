# General
Global Key Hooks can only be used for LowLevel ones (Suffixed with _LL).

# Links
https://stackoverflow.com/questions/34281223/c-sharp-hook-global-keyboard-events-net-4-0 
https://msdn.microsoft.com/en-us/library/windows/desktop/ms644990%28v=vs.85%29.aspx

# Gotchas
Starting a Console App and then wait for Readkey blocks the Windows queue, resulting in not working at all