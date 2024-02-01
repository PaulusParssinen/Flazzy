﻿namespace Flazzy.Tags;

public enum ImageFormat : long
{
    PNG = 0, // 0x89 0x50 0x4E 0x47 0x0D 0x0A 0x1A 0x0A
    JPEG = 1, // 0xFF, 0xD8 | OR | 0xFF, 0xD9, 0xFF, 0xD8
    GIF98a = 2 // 0x47 0x49 0x46 0x38 0x39 0x61
}