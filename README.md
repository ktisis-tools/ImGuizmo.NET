# ImGuizmo.NET

ImGuizmo is a collection of ImGui widgets and controls such as manipulation gizmos.

ImGuizmo.NET provides access to ImGuizmo's functionality from the .NET environment.

## Building

The project consists of two primary parts: The .NET Library, and the native components required to link against ImGuizmo.

The .NET Library may be built directly from the `ImGuizmo.NET/ImGuizmo.NET.csproj` file.

The native components require ImGui and ImGuizmo, which are hosted in separate repositories.
Run `git submodule update --init` to download them. (Note that the default configuration uses SSH as the transport protocol; you may need to adjust the URL for different configurations.[^1])

Afterwards, use `make`[^2] in the `NativeComponents` folder to build the native assembly for your current platform.
If you wish to build for a different platform, set up your compiling environment as appropriate and specify the name of the assembly. (`ImGuizmo-Bridge.dll` for Windows, `libImGuizmo-Bridge.so` for other platforms)

## Including

When including this library in your project, you will need to provide both the .NET Assembly as well as the appropriate native assembly for your platform.

In addition, you will need to provide your own Dear ImGui implementation with a compatible version.
Link this library to your implementation at runtime by calling `Ktisis.ImGuizmo.Gizmo.Initialize` with your ImGui context and allocation functions. 

## Acknowledgements

Thank you to:
- [Omar Cornut](https://github.com/ocornut) and the Dear ImGui contributors for developing Dear ImGui.
- [Cedric Guillemet](https://github.com/CedricGuillemet) and the ImGuizmo contributors for developing ImGuizmo.


## Footnotes

[^1]: On Windows systems, if your SSH Key requires a passphrase, you may need to run `git submodule update --init` from Git Bash instead of the built-in command prompt due to a problem with the passphrase prompt.
[^2]: Please ensure you are using a GNU Make-compatible `make` binary. NMake is currently not supported.
