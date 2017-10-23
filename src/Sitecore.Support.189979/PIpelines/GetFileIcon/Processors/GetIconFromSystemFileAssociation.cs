namespace Sitecore.Support.Pipelines.GetFIleIcon.Processors
{
    using Sitecore.Diagnostics;
    using Sitecore.IO;
    using Sitecore.Pipelines.GetFileIcon;
    using System;

    public class GetIconFromSystemFileAssociation : Sitecore.Pipelines.GetFileIcon.Processors.GetIconFromSystemFileAssociation
    {
        public override void Process(GetFileIconPipelineArgs args)
        {
            if (!this.IsArgumentsObjectHandled(args))
            {
                string shellFileIcon = null;
                try
                {
                    shellFileIcon = this.GetShellFileIcon(args);
                }
                catch (Exception)
                {
                    Log.SingleWarn("Icon could not be obtained through WinAPI.", typeof(GetIconFromSystemFileAssociation));
                }
                if (!string.IsNullOrEmpty(shellFileIcon))
                {
                    args.RelativeIconPath = FileUtil.UnmapPath(shellFileIcon);
                    args.AbortPipeline();
                }
            }
        }
    }
}