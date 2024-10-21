using StackExample;

Console.WriteLine("Hello, Stack!");

DepotTest();

ArticleTest();

static void DepotTest()
{
    Depot depot = new Depot();

    depot.AddItem("Item1", "Place1");
    depot.AddItem("Item2", "Place2");
    depot.AddItem("Item3", "Place1");
    depot.AddItem("Item4", "Place1"); 
    depot.AddItem("Item5", "Place2");
    
    depot.DisplayDepotContents();

    depot.SendItem("Place1");
    depot.SendItem("Place2");

    depot.DisplayDepotContents();
}


static void ArticleTest()
{
    IArticleCaretaker articleCaretaker = new StackArticleCaretaker();

    var article = new Article { Title = "Lorem ipsum" };

    article.Content = "a";
    articleCaretaker.SetState(article.CreateMemento());

    article.Content = "b";
    articleCaretaker.SetState(article.CreateMemento());

    article.Content = "c";
    articleCaretaker.SetState(article.CreateMemento());

    // TODO: Undo
    article.SetMemento(articleCaretaker.GetState());
    Console.WriteLine(article);

    article.SetMemento(articleCaretaker.GetState());
    Console.WriteLine(article);

    article.SetMemento(articleCaretaker.GetState());
    Console.WriteLine(article);

}