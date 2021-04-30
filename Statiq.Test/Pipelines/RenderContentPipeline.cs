using Statiq.Common;
using Statiq.Core;
using Statiq.Handlebars;
using Statiq.Html;

namespace Statiq.Test.Pipelines
{
  class RenderContentPipeline : PipelineBase
  {
    public RenderContentPipeline()
    {
      Dependencies.AddRange(nameof(SidebarLayoutPipeline), nameof(CreateMainArticlesPipeline), nameof(RenderBlogPostsLayoutPipeline), nameof(RenderBlogPostsIndexLayoutPipeline));

      ProcessModules = new ModuleList
      {
          new ConcatDocuments(nameof(CreateMainArticlesPipeline), nameof(RenderBlogPostsLayoutPipeline), nameof(RenderBlogPostsIndexLayoutPipeline)),
          new MergeMetadata
          {
              new ReplaceDocuments(nameof(SidebarLayoutPipeline)),
          },
          new RenderHandlebars("layout", "rendered")
              .WithModel(Config.FromDocument(async (document, context) => new
              {
                  menuitems = document.Get("menuitem"),
                  blogs = document.Get("blogs"),
                  content = await document.GetContentStringAsync(),
              })),
          new SetContent(Config.FromDocument(x => x.GetString("rendered"))),
      };

      OutputModules = new ModuleList
      {
          new WriteFiles(),
      };
    }
  }
}
