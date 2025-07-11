using System.Runtime.InteropServices;

namespace Fydar.Deterministic.Numerics.Internal;

internal static class MathEngine
{
    internal static readonly ushort[] sin;
    internal static readonly Fixed[] tan;
    internal static readonly int[] asin;
    internal static readonly ushort[] sqrt;

    static MathEngine()
    {
        sin = LoadUShorts("Fydar.Deterministic.Numerics.LUT.Sin.bin");
        asin = LoadIntegers("Fydar.Deterministic.Numerics.LUT.Asin.bin");
        tan = Load("Fydar.Deterministic.Numerics.LUT.Tan.bin");
        sqrt = LoadUShorts("Fydar.Deterministic.Numerics.LUT.Sqrt.bin");
    }

    private static ushort[] LoadUShorts(string resourceName)
    {
        var assembly = typeof(MathEngine).Assembly;
        var stream = assembly.GetManifestResourceStream(resourceName);

        var data = new ushort[stream.Length / 2];
        stream.Read(MemoryMarshal.Cast<ushort, byte>(data));
        return data;
    }

    private static int[] LoadIntegers(string resourceName)
    {
        var assembly = typeof(MathEngine).Assembly;
        var stream = assembly.GetManifestResourceStream(resourceName);

        var data = new int[stream.Length / 4];
        stream.Read(MemoryMarshal.Cast<int, byte>(data));
        return data;
    }

    private static Fixed[] Load(string resourceName)
    {
        var assembly = typeof(MathEngine).Assembly;
        var stream = assembly.GetManifestResourceStream(resourceName);

        var data = new Fixed[stream.Length / 8];
        stream.Read(MemoryMarshal.Cast<Fixed, byte>(data));
        return data;
    }
}
