﻿namespace Flazzy.ABC.AVM2.Instructions;

public sealed class PopScopeIns : ASInstruction
{
    public PopScopeIns()
        : base(OPCode.PopScope)
    { }

    public override void Execute(ASMachine machine)
    {
        machine.Scopes.Pop();
    }
}