# R5T.L0066
Strict platform library for .NET Standard 2.1.

!!! This library *strictly* depends on only the .NET Standard 2.1 target framework, and NO other dependencies. !!!
=> Well, except for the instance marker attribute type libraries.

See R5T.L0053 for a less strict platform library for the .NET Standard 2.1 target framework. (That allows depending on values libraries, as long as those values are strictly platform-typed, for example.)

Custom types, while allowed, are discouraged. If custom types were disallowed, it would create the need for a further intermediate library to contain those types. Instead we allow functionality to "flow down" to it's most basic library, depending on dependencies (trust in tree shaking to remove extraneous functions from final artifacts). However there should be a home for strictly platform level functionality, and this library is it.

For example, WasFound<T> is a great type, dramatically simplifying many basic operations (even platform-level operations). However, it is useful to have strictly platform-typed methods, even with all their complications. So this library contains the messier, strictly platform-level functions, and a higher-level library contains the WasFound<T>-level functions.
