﻿using Flazzy.IO;

namespace Flazzy.Records;

public class FrameRecord : FlashItem
{
    public ushort Rate { get; set; }
    public ushort Count { get; set; }
    public RectangleRecord Area { get; set; }

    public FrameRecord()
    {
        Area = new RectangleRecord();
    }
    public FrameRecord(FlashReader input)
    {
        Area = new RectangleRecord(input);
        Rate = (ushort)(input.ReadUInt16() >> 8);
        Count = input.ReadUInt16();
    }

    public override void WriteTo(FlashWriter output)
    {
        Area.WriteTo(output);
        output.Write((ushort)(Rate << 8));
        output.Write(Count);
    }
}