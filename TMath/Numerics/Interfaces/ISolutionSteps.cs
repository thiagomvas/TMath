namespace TMath.Numerics.Interfaces
{
    internal interface ISolutionStep<T>
    {
        T CurrentState { get; }
        string NextOperation { get; }
    }
}
