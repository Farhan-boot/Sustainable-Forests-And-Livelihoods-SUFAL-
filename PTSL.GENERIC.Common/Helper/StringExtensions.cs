using System.Text;

namespace PTSL.GENERIC.Common.Helper;

public static class StringExtensions
{
    public static string TrimAndClean(this string? input)
    {
        if (input is null)
            return string.Empty;

        // Create a StringBuilder to build the output string
        var output = new StringBuilder(input.Length);

        foreach (char c in input)
        {
            switch (c)
            {
                // Replace with ASCII space
                case '\u0020': // Space
                case '\u00A0': // Non-Breaking Space
                case '\u2000': // En Quad
                case '\u2001': // Em Quad
                case '\u2002': // En Space
                case '\u2003': // Em Space
                case '\u2004': // Three-Per-Em Space
                case '\u2005': // Four-Per-Em Space
                case '\u2006': // Six-Per-Em Space
                case '\u2007': // Figure Space
                case '\u2008': // Punctuation Space
                case '\u2009': // Thin Space
                case '\u200A': // Hair Space
                case '\u202F': // Narrow No-Break Space
                case '\u205F': // Medium Mathematical Space
                case '\u3000': // Ideographic Space
                    output.Append(' ');
                    break;

                // Replace with ASCII tab
                case '\u0009': // Horizontal Tab
                case '\u000B': // Vertical Tab
                    output.Append('\t');
                    break;

                // Other invisible characters replaced with empty string (removed)
                case '\u200B': // Zero Width Space
                case '\u200C': // Zero Width Non-Joiner
                case '\u200D': // Zero Width Joiner
                case '\uFEFF': // Zero Width No-Break Space (BOM)
                case '\u2060': // Word Joiner
                case '\u2069': // Inhibitor
                case '\u200E': // Left-To-Right Mark
                case '\u200F': // Right-To-Left Mark
                case '\u202A': // Left-To-Right Embedding
                case '\u202B': // Right-To-Left Embedding
                case '\u202C': // Pop Directional Formatting
                case '\u202D': // Left-To-Right Override
                case '\u202E': // Right-To-Left Override
                    // These characters are removed
                    break;

                default:
                    // Append the character if it doesn't match any of the above
                    output.Append(c);
                    break;
            }
        }

        return output.ToString().Trim();
    }
}
