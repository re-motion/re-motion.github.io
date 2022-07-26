using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Yaml;

namespace Statiq.Test.Pipelines
{
  class CreateMainArticlesPipeline : Pipeline
  {
    public CreateMainArticlesPipeline()
    {
      InputModules = new ModuleList
      {
          new ReadFiles("./*.md"),
      };

      ProcessModules = new ModuleList
      {
          new ExtractFrontMatter(new ParseYaml()),
          new SetDestination(".html"),
          new RenderMarkdown(),
      };
    }
  }
}
