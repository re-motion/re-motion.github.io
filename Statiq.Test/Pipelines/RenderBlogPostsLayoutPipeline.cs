using System.IO;
using Statiq.Common;
using Statiq.Core;
using Statiq.Handlebars;
using Statiq.Markdown;
using Statiq.Yaml;

namespace Statiq.Test.Pipelines
{
  class RenderBlogPostsLayoutPipeline : Pipeline
  {
    public RenderBlogPostsLayoutPipeline()
    {
      Dependencies.Add(nameof(CreateBlogPostsPipeline));

      InputModules = new ModuleList
      {
          new ReadFiles("./blogs/_bloglayout.hbs"),
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
              .WithModel(Config.FromDocument(async (d, c) => new
              {
                  published = d.Get("published"),
                  author = d.Get("author"),
                  categoryname = d.Get("category"),
                  categoryurl = c.GetLink($"blogs/{d.Get("category")}/index.html", true),
                  content = await d.GetContentStringAsync(),
              })),
          new SetDestination(Config.FromDocument(d => new NormalizedPath($"./blogs/{d.GetString("category")}/{Path.GetFileName(d.GetString("Destination"))}"))),
          new SetContent(Config.FromDocument(d => d.GetString("bloglayout"))),
      };
    }
  }
}
