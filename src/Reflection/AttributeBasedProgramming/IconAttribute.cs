namespace AttributeBasedProgramming;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor)]
public class IconAttribute : Attribute
{
    public string Filename { get; }

    public IconAttribute(string filename)
    {
        this.Filename = filename;
    }
}


[AttributeUsage(AttributeTargets.Property)]
public class IsReadOnlyAttribute : Attribute
{

}