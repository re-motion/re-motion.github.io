using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Test.Pipelines;

namespace Statiq.Test
{
  class Program
  {
    static async Task<int> Main(string[] args)
    {
      return await Bootstrapper.Factory
          .CreateDefault(args)
          .AddSetting("LinkHideIndexPages", false)
          .AddSetting("LinkHideExtensions", false)
          .AddPipeline<CopyAssetsPipeline>()
          .AddPipeline<LayoutPipeline>()
          .AddPipeline<SidebarLayoutPipeline>()
          .AddPipeline<CreateMainArticlesPipeline>()
          .AddPipeline<CreateBlogPostsPipeline>()
          .AddPipeline<RenderBlogPostsLayoutPipeline>()
          .AddPipeline<CreateBlogIndexPipeline>()
          .AddPipeline<RenderBlogPostsIndexLayoutPipeline>()
          .AddPipeline<RenderContentPipeline>()
          .RunAsync();
    }
  }

  class MyModule : IModule
  {
    public async Task<IEnumerable<IDocument>> ExecuteAsync(IExecutionContext context)
    {
      return await Task.FromResult(context.Outputs);
    }
  }
}
