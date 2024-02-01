﻿using Flazzy.IO;

namespace Flazzy.ABC.AVM2.Instructions;

public class GetSuperIns : ASInstruction
{
    public int PropertyNameIndex { get; set; }
    public ASMultiname PropertyName => ABC.Pool.Multinames[PropertyNameIndex];

    public GetSuperIns(ABCFile abc)
        : base(OPCode.GetSuper, abc)
    { }
    public GetSuperIns(ABCFile abc, FlashReader input)
        : this(abc)
    {
        PropertyNameIndex = input.ReadInt30();
    }
    public GetSuperIns(ABCFile abc, int propertyNameIndex)
        : this(abc)
    {
        PropertyNameIndex = propertyNameIndex;
    }

    public override int GetPopCount()
    {
        return (ResolveMultinamePops(PropertyName) + 1);
    }
    public override int GetPushCount()
    {
        return 1;
    }
    public override void Execute(ASMachine machine)
    {
        ResolveMultiname(machine, PropertyName);
        object obj = machine.Values.Pop();
        machine.Values.Push(null);
    }

    protected override void WriteValuesTo(FlashWriter output)
    {
        output.WriteInt30(PropertyNameIndex);
    }
}