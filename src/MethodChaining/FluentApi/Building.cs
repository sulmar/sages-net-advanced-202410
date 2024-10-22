namespace FluentApi;

public class Building
{
    public string Name { get; set; }
}

public class Roof
{
    public string Name { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}

public class Column
{
    public string Name { get; set; }
    public double Height { get; }
}

public class Floor
{
    public string Name { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}