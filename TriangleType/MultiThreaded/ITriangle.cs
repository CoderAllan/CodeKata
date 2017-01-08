namespace MultiThreaded
{
    using Model;

    public interface ITriangle
    {
        bool DoMatch(TriangleSideLengths triangleSideLengths);
        string Description { get; }
    }
}
