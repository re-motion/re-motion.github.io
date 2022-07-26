// SPDX-License-Identifier: LGPL-2.1-or-later
// SPDX-FileCopyrightText: 2022 RUBICON IT GmbH, www.rubicon.eu

using System;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Test.Pipelines;

namespace SiteGenerator;

public class Program
{
  public static async Task<int> Main (string[] args)
  {
    var bootstrapperFactory = Bootstrapper
        .Factory;
    var bootstrapper = bootstrapperFactory.CreateWeb (args);
    //bootstrapper = bootstrapper.SetThemePath (@"D:\Development\Remotion\Website\src\SiteGenerator\theme");
    return await bootstrapper.RunAsync();
   // return await bootstrapperFactory
        //.CreateDefault (args)
        
        
        /*
          .BuildPipeline (
              "Render Markdown",
              builder => builder
                  .WithInputReadFiles ("*.md")
                  .WithProcessModules (
                      new RenderMarkdown(),
                      new SetDestination (".html"))
                  .WithOutputWriteFiles())
                  */
        /*   .AddPipeline<CopyAssetsPipeline>()
          .AddPipeline<LayoutPipeline>()
          //.AddPipeline<SidebarLayoutPipeline>()
          .AddPipeline<CreateMainArticlesPipeline>()
          .AddPipeline<RenderContentPipeline>()*/
      //  .RunAsync();
  }
}