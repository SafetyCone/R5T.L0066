# R5T.L0066
Strictly-framework library for general .NET Standard 2.1 functionality. (netstandard2.1 target framework)


## Allowed Dependencies

* netstandard2.1: target framework
* Marker attribute types libraries:
	* R5T.T0131 - Values
	* R5T.T0132 - Functions
	* R5T.T0142 - Types
	* R5T.T0143 - Markers
	* R5T.T0156 - Documentations
	X R5T.T0241 - Context operations (REMOVE!)
	* R5T.Y0006 - .NET documentations

!!! This library *strictly* depends on only the .NET Standard 2.1 target framework, and NO other dependencies. !!!
=> Well, except for the instance marker attribute type libraries (R5T.{T0131, T0132, T0142)}, and the strictly-platform documentation library for .NET Standard 2.1 (R5T.Y0006).


* No strong types.
* Only .NET Standard 2.1 library types (not type library dependencies, except for instance marker type libraries).
* Custom types are discouraged.
* No Rivet-specific, or personal functionality.
* Only common functionality.

See R5T.L0053 for a less strict platform library for the .NET Standard 2.1 target framework. (That allows depending on values libraries, as long as those values are strictly platform-typed, for example.)

Custom types, while allowed, are discouraged. If custom types were disallowed, it would create the need for a further intermediate library to contain those types. Instead we allow functionality to "flow down" to it's most basic library, depending on dependencies (trust in tree shaking to remove extraneous functions from final artifacts). However there should be a home for strictly platform level functionality, and this library is it.

For example, WasFound<T> is a great type, dramatically simplifying many basic operations (even platform-level operations). However, it is useful to have strictly platform-typed methods, even with all their complications. So this library contains the messier, strictly platform-level functions, and a higher-level library contains the WasFound<T>-level functions.


## Checked

The operator methods assume all input values are checked, unless the method name explicitly indicates otherwise by being suffixed with "_CheckX".
This is done to keep method implementations simple, and their failure modes easy to reason about.
Checked methods are in turn put into a "Checked" namespace.
This means that you have to explicitly go looking for a checked version of a method, if you want it.