using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class PagintionalBasic
    {
        [OptionalRange(1, int.MaxValue)]
        public int? Offset { get; set; }

        [OptionalRange(1, int.MaxValue)]
        public int? Size { get; set; }
    }

    public class PagintionalBasicByOffsetRecord
    {
        [OptionalRange(0, int.MaxValue)]
        public int? DisplayStart { get; set; }

        [OptionalRange(1, int.MaxValue)]
        public int? DisplayLength { get; set; }
    }
}

