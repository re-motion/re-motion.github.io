using Statiq.Common;
using Statiq.Core;
using Statiq.Handlebars;
using Statiq.Markdown;
using Statiq.Yaml;

namespace Statiq.Test.Pipelines
{
  class RenderBlogPostsIndexLayoutPipeline : Pipeline
  {
    public RenderBlogPostsIndexLayoutPipeline()
    {
      Dependencies.Add(nameof(CreateBlogIndexPipeline));

      InputModules = new ModuleList
      {
          new ReadFiles("./blogs/_blogindexlayout.hbs"),
          new SetMetadata("bloglayout", Config.FromDocument(async d => await d.GetContentStringAsync())),
      };

      ProcessModules = new ModuleList
      {
          new MergeMetadata(nameof(CreateBlogPostsPipeline)).Reverse(),
          new ExtractFrontMatter(new ParseYaml()),
          new OptimizeFileName(),
          new SetDestination(".html"),
          new RenderMarkdown(),
          new RenderHandlebars("bloglayout")
              .WithModel(Config.FromDocument(async d => new
              {
                  categoryname = d.Get("category"),
                  content = await d.GetContentStringAsync(),
              })),
          new SetDestination(Config.FromDocument(d => new NormalizedPath($"./blogs/{d.GetString("category")}/index.html"))),
          new SetContent(Config.FromDocument(d => d.GetString("bloglayout"))),
      };
    }
  }
}
