using SimpleClassicTheme.Common.Native.Methods;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

using Windows.Win32;
using Windows.Win32.Foundation;

namespace SimpleClassicTheme.Common.Native
{
    /// <summary>
    /// Helper functions that use native calls.
    /// </summary>
    public static class NativeHelpers
    {
        /// <summary>
        /// Reads a block of memory from the specified <paramref name="process"/> starting at <paramref name="baseAddress"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="process"></param>
        /// <param name="baseAddress"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T ReadProcessMemoryStructure<T>(IntPtr process, IntPtr baseAddress, int? length = null) where T : struct
        {
            length ??= Marshal.SizeOf<T>();

            var bytes = ReadProcessMemory(process, baseAddress, length.Value);

            GCHandle gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T structure = Marshal.PtrToStructure<T>(gcHandle.AddrOfPinnedObject());
            gcHandle.Free();

            return structure;
        }

        public static string ReadNullTerminatedString(IntPtr process, IntPtr index, int max = 1024)
        {
            const int characterLength = 2;

            StringBuilder sb = new(max);
            Span<byte> span;

            while (true)
            {
                span = ReadProcessMemory(process, index, characterLength);
                string character = Encoding.Unicode.GetString(span);
                
                if (character == "\0")
                    break;

                sb.Append(character);

                index += characterLength;
            }

            return sb.ToString();
        }

        public static byte[] ReadProcessMemory(IntPtr process, IntPtr index, int length)
        {
            byte[] bytes = new byte[length];

            unsafe
            {
                fixed (void* ptr = &bytes[0])
                {
                    PInvoke.ReadProcessMemory((HANDLE)process, (void*)index, ptr, (nuint)length);
                }
            }

            return bytes;
        }
    }
}
