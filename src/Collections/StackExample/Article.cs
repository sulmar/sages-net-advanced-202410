namespace StackExample;

// Abstract Caretaker
internal interface IArticleCaretaker
{
    void SetState(ArticleMemento memento);
    ArticleMemento GetState();
}

internal class StackArticleCaretaker : IArticleCaretaker
{
    private Stack<ArticleMemento> mementos = new Stack<ArticleMemento>();
    public ArticleMemento GetState()
    {
        return mementos.Pop();
    }

    public void SetState(ArticleMemento memento)
    {
        mementos.Push(memento);
    }
}

internal class VersionArticleCaretaker 
{
    private IDictionary<string, ArticleMemento> mementos = new Dictionary<string, ArticleMemento>();
    public ArticleMemento GetState(string version)
    {
        return mementos[version];
    }

    public void SetState(string version, ArticleMemento memento)
    {
        mementos.Add(version, memento);
    }
}

internal class Article
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Notes { get; set; }
    public override string ToString() => $"{Title} {Content} {Notes}";

    // Backup
    public ArticleMemento CreateMemento()
    {
        return new ArticleMemento(Title, Content);
    }

    // Restore
    public void SetMemento(ArticleMemento memento)
    {
        this.Title = memento.Title;
        this.Content = memento.Content;
    }
}

// Migawka (Snapshot)
internal class ArticleMemento
{
    public string Title { get; }
    public string Content { get; }

    public ArticleMemento(string title, string content)
    {
        Title = title;
        Content = content;
    }
}


