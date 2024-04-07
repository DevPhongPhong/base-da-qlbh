namespace Services.StaticData
{
    public interface IStaticDataService
    {
        /// <summary>
        /// Lấy số điện thoại và email liên hệ
        /// </summary>
        /// <returns></returns>
        Entities.Models.StaticData[] GetEmailAndPhoneNum();
    }
}
