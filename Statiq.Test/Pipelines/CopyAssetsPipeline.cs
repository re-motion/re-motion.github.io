using Statiq.Common;
using Statiq.Core;

namespace Statiq.Test.Pipelines
{
  public class CopyAssetsPipeline : Pipeline
  {
    public CopyAssetsPipeline()
    {
      Isolated = true;

      ProcessModules = new ModuleList
      {
          new CopyFiles("./**/*.png"),
      };
    }
  }
}
