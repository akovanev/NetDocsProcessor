using System.Text;

namespace Akov.Chillout.Demo.Markdown;

public class Table
{
    public static string CreateHeaders(params string[] headers)
    {
        var sb = new StringBuilder();

        sb.Append("|");
        foreach (string header in headers)
        {
            sb.Append($" {header} |");
        }
        sb.AppendLine();

        sb.Append("|");
        foreach (string header in headers)
        {
            sb.Append(" --- |");
        }
        sb.AppendLine();

        return sb.ToString();
    }
    
    public static string GenerateHeadersWithAlignment(string[] headers, Alignment[] alignment)
    {
        if (headers.Length != alignment.Length)
        {
            throw new ArgumentException("The number of headers must match the number of alignments.");
        }

        var sb = new StringBuilder();

        sb.Append("|");
        for (int i = 0; i < headers.Length; i++)
        {
            sb.Append($" {headers[i]} ");
            sb.Append(alignment[i] switch
            {
                Alignment.Left => ":---",
                Alignment.Right => "---:",
                Alignment.Center => ":---:",
                _ => "---"
            });
            sb.Append(" |");
        }
        sb.AppendLine();

        return sb.ToString();
    }
    
    public static string AddRow(params string[] newRow)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("|");
        for (int i = 0; i < newRow.Length; i++)
        {
            sb.Append($" {newRow[i].ToMarkdownText()} |");
        }
        sb.Append(Environment.NewLine);

        return sb.ToString();
    }

    
}