
namespace Scripting.Items
{
    public class Tools
    {

        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================


        // ========================================
        // Public properties
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Remove spaces/tabs from a string
        public static string RemoveSpaces(string s)
        {
            if (s != null)
                return s.Trim();
            else
                return null;
        }
    }
}

