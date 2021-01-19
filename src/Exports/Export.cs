using System;
using System.Runtime.InteropServices;

namespace Wasmtime.Exports
{
    /// <summary>
    /// Represents an export of a WebAssembly module or instance.
    /// </summary>
    public abstract class Export
    {
        internal Export(IntPtr exportType)
        {
            unsafe
            {
                var name = Interop.wasm_exporttype_name(exportType);
                if (name->size == UIntPtr.Zero)
                {
                    Name = String.Empty;
                }
                else
                {
                    Name = Marshal.PtrToStringUTF8((IntPtr)name->data, (int)name->size);
                }
            }
        }

        /// <summary>
        /// The name of the export.
        /// </summary>
        public string Name { get; private set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name;
        }
    }
}
