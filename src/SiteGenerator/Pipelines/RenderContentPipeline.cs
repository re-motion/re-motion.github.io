// SPDX-License-Identifier: LGPL-2.1-or-later
// SPDX-FileCopyrightText: 2022 RUBICON IT GmbH, www.rubicon.eu

using Statiq.Razor;

namespace Statiq.Test.Pipelines
{
  class RenderContentPipeline : Pipeline
  {
    public RenderContentPipeline ()
    {
      Dependencies.AddRange ( /*nameof(SidebarLayoutPipeline),*/ nameof(CreateMainArticlesPipeline));
      //IDocument d;

      ProcessModules =
          new ModuleList
          {
              new ConcatDocuments (nameof(CreateMainArticlesPipeline)),
              /*new MergeMetadata
              {
                  new ReplaceDocuments(nameof(SidebarLayoutPipeline)),
              },
              */
              //new MergeContent(new ReadFiles(patterns: "_Layout.cshtml")),
              new RenderRazor()
                  .WithModel(Config.FromDocument(async (document, context) => new
                                                                              {
                                                                                  menuitems = document.Get("menuitem"),
                                                                                  content = await document.GetContentStringAsync(),
                                                                              })),
              new SetContent(Config.FromDocument(x => x.GetString("rendered"))),
          };

      PostProcessModules =
          new ModuleList
          {
              // new SetMetadata (
              //     "template",
              //     Config.FromContext (
              //         async context => await context.Outputs
              //             .FromPipeline (nameof(LayoutPipeline))
              //             .First (d => d.Source.FileName == "_Layout.cshtml")
              //             .GetContentStringAsync())),
              new RenderRazor()
                  .WithLayout ("_Layout.cshtml")
                  // .Configure(async (context, document, handlebars) =>
                  // {
                  //   foreach (var partial in context.Outputs.FromPipeline(nameof(LayoutPipeline)).WhereContainsKey("partial"))
                  //   {
                  //     handlebars.RegisterTemplate(partial.GetString("partial"), await partial.GetContentStringAsync());
                  //   }
                  // })
                  .WithModel (
                      Config.FromDocument (
                          async (document, context) => new
                                                       {
                                                           title = document.GetString (Keys.Title),
                                                           body = await document.GetContentStringAsync(),
                                                       })),
             // new SetContent (Config.FromDocument (x => x.GetString ("template"))),
             //new SetContent (Config.FromDocument (x => x.GetContentStringAsync())),
          };

      OutputModules = new ModuleList
                      {
                          new WriteFiles(),
                      };
    }
  }
}