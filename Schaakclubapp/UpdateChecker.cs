using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

public static class UpdateChecker
{
    private const string VersionUrl = "https://raw.githubusercontent.com/MatsDevOfficial/Schaakclubapp/main/version.txt";
    private const string DownloadUrl = "https://github.com/MatsDevOfficial/Schaakclubapp/releases/download/1.0.0/ChessClubApp.zip";

    public static async Task<bool> IsUpdateAvailable(string currentVersion)
    {
        using var client = new WebClient();
        string latestVersion = await client.DownloadStringTaskAsync(VersionUrl);
        return string.Compare(latestVersion.Trim(), currentVersion, StringComparison.Ordinal) > 0;
    }

    public static async Task DownloadAndInstallUpdate()
    {
        string tempPath = Path.Combine(Path.GetTempPath(), "ChessClubApp_Update.zip");

        using var client = new WebClient();
        await client.DownloadFileTaskAsync(new Uri(DownloadUrl), tempPath);

        string appPath = AppDomain.CurrentDomain.BaseDirectory;
        System.IO.Compression.ZipFile.ExtractToDirectory(tempPath, appPath, true);

        Process.Start(Path.Combine(appPath, "ChessClubApp.exe"));
        Environment.Exit(0);
    }
}
