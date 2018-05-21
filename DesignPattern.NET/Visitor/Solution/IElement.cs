namespace DesignPattern.NET.Visitor.Solution
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}