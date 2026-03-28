# SunamoStringSubstring

Provides helper methods for safe substring operations in .NET.

## Features

- **SHSubstring** - Static methods for extracting substrings with bounds checking and configurable edge-case behavior.
- **SubstringArgs** - Configuration class for controlling substring operation behavior (e.g., returning input instead of throwing on invalid indices).

## Key Methods

| Method | Description |
|--------|-------------|
| `SubstringStart` | Returns a substring from the specified start index to the end. |
| `SubstringIfAvailableStart` | Returns a substring from the start index if the string is long enough; otherwise returns the original. |
| `Substring` | Returns a substring between two indices with configurable error handling. |
| `SubstringIfAvailable` | Returns a substring of the specified length from the beginning if available. |

## Installation

```bash
dotnet add package SunamoStringSubstring
```

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

## License

MIT
