using Statiq.Common;
using Statiq.Core;

namespace Statiq.Test.Pipelines
{
  class CreateBlogIndexPipeline : Pipeline
  {
    public CreateBlogIndexPipeline()
    {
      Dependencies.Add(nameof(CreateBlogPostsPipeline));

      ProcessModules = new ModuleList
      {
          new ReplaceDocuments(nameof(CreateBlogPostsPipeline)),
          new GroupDocuments("category"),
          new ForEachDocument
          {
              new OrderDocuments(Config.FromDocument(d => d.GetDateTime("published"))).Descending(),
              new TakeDocuments(1),
          },
          new FlattenTree(),
          new FilterDocuments(Config.FromDocument(d => d.Get("category") is string { Length: >0 })),
          new SetDestination(Config.FromDocument(d => new NormalizedPath($"./blogs/{d.GetString("category")}/index.html"))),
      };
    }
  }
}
