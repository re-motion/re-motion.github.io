using Statiq.Common;
using Statiq.Core;
using Statiq.Yaml;

namespace Statiq.Test.Pipelines
{
  class LayoutPipeline : Pipeline
  {
    public LayoutPipeline()
    {
      InputModules = new ModuleList
      {
          new ReadFiles("*.hbs")
      };

      ProcessModules = new ModuleList
      {
          new ExtractFrontMatter(new ParseYaml())
      };
    }
  }
}
