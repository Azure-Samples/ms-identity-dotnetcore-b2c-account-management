namespace b2c_ms_graph.Helpers
{
    internal class B2cCustomAttributeHelper
    {
        internal readonly string _b2cExtensionAppClientId;

        internal B2cCustomAttributeHelper(string b2cExtensionAppClientId)
        {
            _b2cExtensionAppClientId = b2cExtensionAppClientId.Replace("-", "");
        }

        internal string GetCompleteAttributeName(string attributeName)
        {
            if (string.IsNullOrWhiteSpace(attributeName))
            {
                throw new System.ArgumentException("Is mandatory", nameof(attributeName));
            }

            return $"extension_{_b2cExtensionAppClientId}_{attributeName}";
        }
    }
}
