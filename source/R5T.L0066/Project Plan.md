# R5T.L0066
Strict platform library for .NET Standard 2.1.

!!! This library *strictly* depends on only the .NET Standard 2.1 target framework, and NO other dependencies. !!!
=> Well, except for the instance marker attribute type libraries.

Custom types should not even be allowed. But, this restriction creates a need for a further intermediate library, and instead we allow functionality to "flow down" to it's most basic library, depending on dependencies (trust tree shaking).

See R5T.L0053 for a less strict platform library for the .NET Standard 2.1 target framework. (That allows depending on values libraries, as long as those values are strictly platform-typed, for example.)
