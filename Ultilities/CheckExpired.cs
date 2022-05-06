using System;
using System.Collections.Generic;
using System.Text;

namespace Ultilities
{
    public static class CheckExpired
    {
        public static bool IsExpired()
        {
            DateTime expiredDate = new DateTime(2022, 05, 01);
            if (expiredDate < DateTime.Now)
            {
                throw new Exception("Hết hạn sử dụng. Vui lòng liên hệ bản quyền: nguyennamhai9x99@gmail.com");
            }
            else
            {
                return false;
            }
        }
    }
}
