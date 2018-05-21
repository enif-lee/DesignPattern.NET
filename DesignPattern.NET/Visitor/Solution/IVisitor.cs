namespace DesignPattern.NET.Visitor.Solution
{
    public interface IVisitor
    {
        void Visit(File file);
        void Visit(Directory file);
    }
}