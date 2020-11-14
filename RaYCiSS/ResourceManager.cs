using System;
using System.IO;
using System.Reflection;
namespace RaYCiSS
{
    public static class ResourceManager
    {
        public static byte[] GetBytes(string ResourcePath)
        {
            using (Stream AssemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourcePath))
            {
                byte[] bytes = new byte[AssemblyStream.Length];
                AssemblyStream.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }

        public static Stream GetStream(string ResourcePath)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourcePath);
        }

        public static string[] GetResources()
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }
}
