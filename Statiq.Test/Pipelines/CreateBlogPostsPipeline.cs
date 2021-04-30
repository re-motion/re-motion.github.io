using System.IO;
using Statiq.Common;
using Statiq.Core;
using Statiq.Html;
using Statiq.Markdown;
using Statiq.Yaml;

namespace Statiq.Test.Pipelines
{
  class CreateBlogPostsPipeline : Pipeline
  {
    public CreateBlogPostsPipeline()
    {
      InputModules = new ModuleList
      {
          new ReadFiles("./blogs/*.md"),
      };

      ProcessModules = new ModuleList
      {
          new ExtractFrontMatter(new ParseYaml()),
          new OptimizeFileName(),
          new SetDestination(".html"),
          new RenderMarkdown(),
          new MakeLinksAbsolute(),
          new GenerateExcerpt(),
          new SetDestination(Config.FromDocument(d => new NormalizedPath($"./blogs/{d.GetString("category")}/{Path.GetFileName(d.GetString("Destination"))}"))),
      };
    }
  }
}
