namespace core.Base;

/// <summary>
/// Guid Generator
/// </summary>
public static class GuidGenerator
{
    /// <summary>
    /// Generate Random Guid
    /// </summary>
    /// <returns>Returns a randomly generated guid</returns>
    public static Guid Generate()
    {
        byte[] bytes = new byte[16];

        // Generate random byte values for the complex GUID
        Random random = new Random();
        random.NextBytes(bytes);

        // Modify specific bytes with random values
        bytes[0] = (byte)(bytes[0] ^ random.Next(256));
        bytes[1] = (byte)(bytes[1] ^ random.Next(256));
        bytes[2] = (byte)(bytes[2] ^ random.Next(256));
        bytes[3] = (byte)(bytes[3] ^ random.Next(256));

        Guid complexGuid = new Guid(bytes);
        return complexGuid;
    }
}