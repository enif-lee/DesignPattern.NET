namespace DesignPattern.NET.Visitor.Solution
{
    public class File : Entry
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}