using System.Linq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Handlebars;

namespace Statiq.Test.Pipelines
{
  class PipelineBase : Pipeline
  {
    protected PipelineBase()
    {
      PostProcessModules = new ModuleList
      {
          new SetMetadata("template", Config.FromContext(async context => await context.Outputs
              .FromPipeline(nameof(LayoutPipeline))
              .First(d => d.Source.FileName == "_mainlayout.hbs")
              .GetContentStringAsync())),
          new RenderHandlebars("template")
              .Configure(async (context, document, handlebars) =>
              {
                foreach (var partial in context.Outputs.FromPipeline(nameof(LayoutPipeline)).WhereContainsKey("partial"))
                {
                  handlebars.RegisterTemplate(partial.GetString("partial"), await partial.GetContentStringAsync());
                }
              }).WithModel(Config.FromDocument(async (document, context) => new
              {
                  title = document.GetString(Keys.Title),
                  body = await document.GetContentStringAsync(),
              })),
          new SetContent(Config.FromDocument(x => x.GetString("template"))),
      };
    }
  }
}
