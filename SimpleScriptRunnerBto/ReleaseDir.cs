using System;
using SimpleScriptRunnerBto.Util;

namespace SimpleScriptRunnerBto;

public class ReleaseDir
{
    public const string RELEASE = "Release";

    public string Path { get; set; }
    public decimal ReleaseVersion { get; set; }

    public static ReleaseDir fromPath(string path)
    {
            string fileName = System.IO.Path.GetFileName(path);
            Tuple<string, string> parts = fileName.splitAt(RELEASE, StringComparison.OrdinalIgnoreCase);
            if (parts == null || parts.Item2 == "")
                return null;

            decimal version = decimal.Parse(parts.Item2.Trim());

            return new ReleaseDir
            {
                Path = path,
                ReleaseVersion = version
            };
        }

    public override string ToString()
    {
            return $"{nameof(Path)}: {Path}, {nameof(ReleaseVersion)}: {ReleaseVersion}";
        }
}