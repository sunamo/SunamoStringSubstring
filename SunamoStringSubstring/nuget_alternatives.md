# NuGet Alternatives to SunamoStringSubstring

This document lists popular NuGet packages that provide similar functionality to SunamoStringSubstring.

## Overview

Substring utilities

## Alternative Packages

### System.String.Substring
- **NuGet**: System.Runtime
- **Purpose**: Built-in substring
- **Key Features**: Extract substrings by index

### System.ReadOnlySpan
- **NuGet**: System.Memory
- **Purpose**: Zero-allocation slicing
- **Key Features**: Span slicing without allocations

### Humanizer
- **NuGet**: Humanizer
- **Purpose**: Smart truncation
- **Key Features**: Truncate, left, right, middle

## Comparison Notes

Substring() for standard use. ReadOnlySpan<char> for performance. Humanizer.Truncate for display.

## Choosing an Alternative

Consider these alternatives based on your specific needs:
- **System.String.Substring**: Built-in substring
- **System.ReadOnlySpan**: Zero-allocation slicing
- **Humanizer**: Smart truncation
