using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text;
using PhoneNumbers;

namespace Utilities
{
    [Serializable()]
    public class ModelDataException : Exception, ISerializable
    {
        public object CustomException { get; set; }
        public ModelDataException() : base() { }
        public ModelDataException(string message) : base(message) { }
        public ModelDataException(string message, Exception inner) : base(message, inner) { }
        public ModelDataException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public ModelDataException(string message, object customEx)
            : base(message)
        {
            this.CustomException = customEx;
        }
    }

    [Serializable()]
    public class NotFoundException : Exception, ISerializable
    {
        public object NotFoundDescription { get; set; }
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }
        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public NotFoundException(string message, object notFoundDescription)
            : base(message)
        {
            NotFoundDescription = notFoundDescription;
        }
    }

    [Serializable()]
    public class ParamRequiredException : Exception, ISerializable
    {
        public object ParamRequiredDescription { get; set; }
        public ParamRequiredException() : base() { }
        public ParamRequiredException(string message) : base(message) { }
        public ParamRequiredException(string message, Exception inner) : base(message, inner) { }
        public ParamRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public ParamRequiredException(string message, object requiredDescription)
            : base(message)
        {
            ParamRequiredDescription = requiredDescription;
        }
    }

    [Serializable()]
    public class OnlyMessageException : Exception, ISerializable
    {
        public OnlyMessageException() : base() { }
        public OnlyMessageException(string message, Exception inner) : base(message, inner) { }
        public OnlyMessageException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public OnlyMessageException(string message)
            : base(message)
        {
        }
    }

    [Serializable()]
    public class FailedMessageException : Exception, ISerializable
    {
        public FailedMessageException(string message = "Đã xảy ra lỗi khi xử lý yêu cầu")
            : base(message)
        {
        }
    }

    public class OptionalRange : RangeAttribute
    {
        public OptionalRange(double minimum, double maximum) : base(minimum, maximum)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return base.IsValid(value);
        }
    }

    public class MinLengthElement : MinLengthAttribute
    {
        public MinLengthElement(int minimum) : base(minimum)
        {
            ErrorMessage = $"The minimum length of each element in the array is '{minimum}'.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            if (value is List<string> || value is string[])
            {
                List<string> arr = new List<string>();
                if (value is string[])
                {
                    arr = (value as string[]).ToList();
                }
                else
                {
                    arr = value as List<string>;
                }

                return arr.Where(x => x.Length < Length).Any() == false;
            }
            else
            {
                return base.IsValid(value);
            }
        }
    }

    public static class HttpResponseExtensions
    {
        public static string GetStationCode(this HttpContext httpContext)
        {
            try
            {
                if (!httpContext.Request.Headers.ContainsKey("station-code"))
                {
                    return null;
                }
                return httpContext.Request.Headers.FirstOrDefault(z => z.Key.ToLower() == "station-code").Value;
            }
            catch
            {

                return null;
            }
        }
    }

    public static class StringFnExtensions
    {
        /// <summary>
        /// Remove signals for Vietnamese
        /// </summary>
        /// <param name="s">String input</param>
        /// <param name="upperCase">UpperCase</param>
        /// <returns>String without signals</returns>
        public static String RemoveSign4VietnameseString(this String s, bool upperCase = true)
        {
            return RemoveSign4VietnameseStringFn(s, upperCase);
        }

        private static string RemoveSign4VietnameseStringFn(string str, bool upperCase = false)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return upperCase ? str.ToUpper() : str;
        }

        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string ReplaceMiddle(this string _str, int Start = 3, int End = 3, int? FixedMiddle = null)
        {
            if (!string.IsNullOrEmpty(_str))
            {
                int minLen = Start + End;

                if (_str.Length <= minLen)
                {
                    return _str;
                }

                string start = _str.Substring(0, Start);
                string end = _str.SubStringRight(End);
                string middle = string.Empty.PadLeft(FixedMiddle ?? _str.Length - minLen, '*');

                _str = start + middle + end;
            }
            return _str;
        }

        public static string SubStringRight(this string _str, int _length)
        {
            if (!string.IsNullOrEmpty(_str))
            {
                return _str[^_length..];
            }

            return _str;
        }
    }

    public static class Common
    {
        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static List<FieldInfo> GetConstants(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.FlattenHierarchy);

            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
        }

        public static void InitPagination(object param, string Size = "Size", string Offset = "Offset", int RecordsPerPageDefault = 25)
        {

            Type type = param.GetType();

            PropertyInfo propSize = type.GetProperty(Size);

            if (propSize != null)
            {
                int? valueSize = (int?)propSize.GetValue(param);

                if (!valueSize.HasValue)
                {
                    propSize.SetValue(param, RecordsPerPageDefault, null);
                }
            }

            PropertyInfo propOffset = type.GetProperty(Offset);

            if (propOffset != null)
            {
                int? valueOffset = (int?)propOffset.GetValue(param);

                if (!valueOffset.HasValue)
                {
                    propOffset.SetValue(param, 0, null);
                }

                if (valueOffset > 0)
                {
                    propOffset.SetValue(param, valueOffset - 1, null);
                }
            }
        }

        public static List<EnumValue> GetEnumDescription(System.Type _enum)
        {
            List<EnumValue> result = new List<EnumValue>();
            try
            {
                var listMember = _enum.GetMembers().Where(x => x.MemberType == MemberTypes.Field && x.CustomAttributes.Any()).ToList();
                if (listMember.Any())
                {
                    for (var i = 0; i < listMember.Count; i++)
                    {
                        var mem = listMember[i];
                        var displayNames = mem.CustomAttributes.Select(x => x.NamedArguments.Where(z => z.MemberName == "Name").Select(y => y.TypedValue.Value)).First();
                        string displayName = string.Empty;
                        if (displayNames.Any() && displayNames.First() != null)
                        {
                            displayName = displayNames.First().ToString();
                        }
                        int key = (int)Enum.Parse(_enum, mem.Name);
                        result.Add(new EnumValue()
                        {
                            Value = key,
                            DisplayName = displayName,
                            Name = mem.Name
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            string _str = JsonSerializer.Serialize(obj);

            byte[] bytes = Encoding.UTF8.GetBytes(_str);

            return bytes;
        }

        // Convert a byte array to an Object
        public static T ByteArrayToObject<T>(byte[] arrBytes)
        {
            if (arrBytes != null)
            {

                T obj = JsonSerializer.Deserialize<T>(arrBytes);

                return obj;
            }
            else
            {
                T res = (T)Activator.CreateInstance(typeof(T));

                //T instance = Activator.CreateInstance<T>();

                return res;
            }
        }

        public static FilterValidation ValidateFilter(Dictionary<string, List<string>> Filter, Type sysType)
        {
            bool filterValid = false;
            string type = null;

            List<string> filterBy = new List<string>();

            if (Filter != null && Filter.Any())
            {
                foreach (var key in Filter.Keys)
                {
                    foreach (PropertyInfo p in sysType.GetProperties())
                    {
                        type = p.PropertyType.Name.ToLower();
                        string propertyName = p.Name;
                        if (!filterBy.Contains(propertyName) && propertyName.ToLower() == key.ToLower())
                        {
                            filterBy.Add(propertyName);
                            break;
                        }
                    }
                }
                if (filterBy.Count == Filter.Count)
                {
                    filterValid = true;
                    Filter = Filter.Where(x => filterBy.Select(z => z.ToLower()).Contains(x.Key.ToLower())).ToDictionary(z => z.Key, z => z.Value);
                }
            }

            return new FilterValidation
            {
                Filter = Filter,
                FilterBy = filterBy,
                IsValid = filterValid
            };
        }

        public static void FilterObject<Tobject>(Dictionary<string, List<string>> Filter, List<string> FilterBy, ref IEnumerable<Tobject> temp)
        {
            try
            {
                Type TypeOfEntity = typeof(Tobject);

                foreach (var key in FilterBy)
                {
                    string _filterBy = key;
                    List<string> _filterValues = Filter[key].Where(x => !string.IsNullOrEmpty(x)).ToList();
                    if (!_filterValues.Any())
                    {
                        continue;
                    }
                    if ((TypeOfEntity.GetProperties().Select(x => x.Name).Contains(_filterBy)))
                    {
                        string valueType; ;

                        if (TypeOfEntity.GetProperties().First(x => x.Name == _filterBy).PropertyType.IsConstructedGenericType && TypeOfEntity.GetProperties().First(x => x.Name == _filterBy).PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            valueType = Nullable.GetUnderlyingType((TypeOfEntity.GetProperties().First(x => x.Name == _filterBy)).PropertyType).Name.ToLower();
                        }
                        else
                        {
                            valueType = (TypeOfEntity.GetProperties().First(x => x.Name == _filterBy)).PropertyType.Name.ToLower();
                        }

                        switch (valueType)
                        {
                            case "string":
                                {
                                    temp = temp.Where(x => (string)typeof(Tobject).GetProperty(_filterBy).GetValue(x, null) != null
                                                            && (
                                                                _filterValues.Where(z => ((string)typeof(Tobject).GetProperty(_filterBy).GetValue(x, null)).Trim().ToLower().Contains(z.Trim().ToLower())).Any() ||
                                                                _filterValues.Select(z => z.Trim().ToLower()).Contains(((string)typeof(Tobject).GetProperty(_filterBy).GetValue(x, null)).Trim().ToLower())
                                                                )
                                                           );
                                    break;
                                }

                            case "int32":
                                {
                                    temp = temp.Where(x => ((int?)typeof(Tobject).GetProperty(_filterBy).GetValue(x, null)) != null && (
                                        _filterValues.Select(z => int.Parse(z)).Contains((int)typeof(Tobject).GetProperty(_filterBy).GetValue(x, null))
                                    ));
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void CalcPaginationParam<Tobject>(ref Tobject paramsModel, bool initDefaultValue = true)
        {
            bool isInheritsPagination = typeof(Tobject).IsSubclassOf(typeof(PagintionalBasic));
            if (isInheritsPagination)
            {
                foreach (PropertyInfo p in typeof(Tobject).GetProperties())
                {
                    string propertyName = p.Name;

                    switch (propertyName.ToLower())
                    {
                        case "offset":
                        case "size":
                            {
                                int? OriginValue = (int?)paramsModel.GetType().GetProperty(propertyName).GetValue(paramsModel);

                                if (OriginValue.HasValue)
                                {
                                    if (propertyName.ToLower() == "offset" && OriginValue > 0)
                                    {
                                        OriginValue -= 1;
                                    }
                                }
                                else
                                {
                                    if (initDefaultValue)
                                    {
                                        if (propertyName.ToLower() == "offset")
                                        {
                                            OriginValue = 0;
                                        }
                                        else
                                        {
                                            OriginValue = 25;
                                        }
                                    }
                                }

                                p.SetValue(paramsModel, OriginValue);

                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }


        public static string SizeSuffix(long value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException(nameof(decimalPlaces)); }

            if (value < 0) { return "-" + SizeSuffix(-value); }

            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public static TDestination ConvertDbDataReaderToObject<TDestination>(DbDataReader x)
        {
            try
            {
                TDestination res = (TDestination)Activator.CreateInstance(typeof(TDestination));

                for (int i = 0; i < x.FieldCount; i++)
                {
                    string fieldName = x.GetName(i);

                    var value = x[fieldName];

                    PropertyInfo propertyInfoDesination = res.GetType().GetProperty(fieldName);

                    if (propertyInfoDesination == null)
                    {
                        propertyInfoDesination = res.GetType().GetProperties().FirstOrDefault(x => x.GetCustomAttribute<ColumnAttribute>() != null && x.GetCustomAttribute<ColumnAttribute>().Name == fieldName);
                    }

                    if (value != DBNull.Value && propertyInfoDesination != null)
                    {
                        var _type = propertyInfoDesination.PropertyType;

                        if (_type.IsGenericType && _type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            _type = Nullable.GetUnderlyingType(_type);
                        }

                        if (value != DBNull.Value && propertyInfoDesination != null)
                        {
                            if (_type.IsEnum)
                            {
                                var val = Enum.Parse(_type, value.ToString());

                                propertyInfoDesination.SetValue(res, val, null);
                            }
                            else
                            {
                                var c = Convert.ChangeType(value, _type);

                                propertyInfoDesination.SetValue(res, c, null);
                            }
                        }
                    }
                }

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool IsInnerCityAndOutSide(LocationTypeRequest From, LocationTypeRequest To)
        {
            bool res = (To.ProvinceId == From.ProvinceId) && ((From.IsInnerCity != To.IsInnerCity) || (To.IsIndustrialArea != From.IsIndustrialArea));
            return res;
        }

        /// <summary>
        /// Điểm phát hàng là nội thành (bỏ qua điều kiện điểm gửi hàng)
        /// </summary>
        /// <param name="To"></param>
        /// <returns></returns>
        public static bool IsDeliveryPointIsInnerCity(LocationTypeRequest To, LocationTypeRequest From)
        {
            return (To.IsInnerCity || To.IsIndustrialArea) && To.ProvinceId == From.ProvinceId;
        }

        /// <summary>
        /// Nội thành: 
        // - Trong 1 thành phố
        // - Điểm phát hàng là NỘI THÀNH(hoặc KCN) (ko phải xã, huyện)
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public static bool IsInnerCity(LocationTypeRequest From, LocationTypeRequest To)
        {
            bool IsInnerCity = (To.ProvinceId == From.ProvinceId) && (To.IsInnerCity || To.IsIndustrialArea);

            return IsInnerCity;
        }

        /// <summary>
        /// Nội tuyến?
        ///- Khác thành phố
        ///- Điểm phát hàng là Nội Thành(hoặc KCN)
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public static bool IsInside(LocationTypeRequest From, LocationTypeRequest To)
        {
            bool IsInside = (To.ProvinceId != From.ProvinceId) && (To.IsInnerCity || To.IsIndustrialArea);

            return IsInside;
        }

        /// <summary>
        /// Ngoại tuyến: Các trường hợp khác ngoài 2 cái trên
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public static bool IsOutSide(LocationTypeRequest From, LocationTypeRequest To)
        {
            bool isInside = IsInside(From, To);

            bool isInnerCity = IsInnerCity(From, To);

            return !isInside && !isInnerCity;
        }

        public static bool IsIndustrialAreaButNotPriority(LocationTypeRequest To, bool? IsIndustrialPriority)
        {
            return To.IsIndustrialArea == true && IsIndustrialPriority != true && To.IsInnerCity != true;
        }

        public static bool IsIndustrialAreaAndInnerCicy(LocationTypeRequest to)
        {
            return to.IsIndustrialArea == true && to.IsInnerCity == true;
        }

        public static int ValidateMultipleModelData<T>(ref IList<T> model, out Dictionary<string, List<string>> errors, ValidateModelDataOption options = null)
        {
            if (options == null)
            {
                options = new ValidateModelDataOption();
            }

            errors = new Dictionary<string, List<string>>();

            int nr = 0;

            foreach (var c in model)
            {
                var x = c;

                if (ValidateModelData(ref x, out Dictionary<string, List<string>> errs, options) > 0)
                {
                    foreach (var er in errs)
                    {
                        errors.Add($"{er.Key}.[{nr}]", er.Value);
                    }
                }

                nr++;
            }

            return errors.Count;
        }

        public static int ValidateModelData<T>(ref T model, out Dictionary<string, List<string>> errors, ValidateModelDataOption options = null)
        {
            if (options == null)
            {
                options = new ValidateModelDataOption();
            }

            IEnumerable<PropertyInfo> properties = typeof(T).GetProperties().Where(x => !(x.GetCustomAttributes<NotMappedAttribute>().Any() || x.GetCustomAttributes<DatabaseGeneratedAttribute>().Any()));

            errors = new Dictionary<string, List<string>>();

            foreach (PropertyInfo p in properties)
            {
                List<string> ers = new List<string>();

                var v = p.GetValue(model);

                if (p.GetCustomAttributes<RequiredAttribute>().Any())
                {
                    if (v == null)
                    {
                        ers.Add("Không được phép NULL");
                    }
                };

                if (p.GetCustomAttributes<MaxLengthAttribute>().Any() && v != null)
                {
                    int maxLen = p.GetCustomAttributes<MaxLengthAttribute>().First().Length;

                    if (v is string && ((string)v).Length > maxLen)
                    {
                        if (!options.AutoCorrectTheLength)
                        {
                            ers.Add($"Không được phép nhiều hơn {maxLen} ký tự");
                        }
                        else
                        {
                            p.SetValue(model, ((string)v).Substring(0, maxLen));
                        }
                    }

                    if ((v is string[] || v is IList<string> || v is IEnumerable<string>) && ((IList<string>)v).Count > maxLen)
                    {
                        if (!options.AutoCorrectTheLength)
                        {
                            ers.Add($"Không được chứa nhiều hơn {maxLen} phần tử");
                        }
                        else
                        {
                            p.SetValue(model, ((IList<string>)v).Skip(0).Take(maxLen));
                        }
                    }
                }

                if (p.GetCustomAttributes<MinLengthAttribute>().Any() && v != null)
                {
                    int minLen = p.GetCustomAttributes<MinLengthAttribute>().First().Length;

                    if (v is string && ((string)v).Length < minLen)
                    {
                        if (!options.AutoCorrectTheLength)
                        {
                            ers.Add($"Không được phép ít hơn {minLen} ký tự");
                        }
                        else
                        {
                            p.SetValue(model, ((string)v).PadRight(minLen));
                        }
                    }

                    if ((v is string[] || v is IList<string> || v is IEnumerable<string>) && ((IList<string>)v).Count < minLen)
                    {
                        if (!options.AutoCorrectTheLength)
                        {
                            ers.Add($"Không được chứa ít hơn {minLen} phần tử");
                        }
                        else
                        {
                            int currentLen = ((IList<string>)v).Count;

                            int missingCount = minLen - currentLen;

                            for (int i = 0; i < missingCount; i++)
                            {
                                ((IList<string>)v).Add(string.Empty);
                            }

                            p.SetValue(model, v);
                        }
                    }
                }

                if (ers.Any())
                {
                    errors.Add(p.Name, ers);
                }
            }

            return errors.Count;
        }

        public static ValidatePhoneResult IsPhoneNr(string _phoneNr)
        {
            try
            {

                var res = new ValidatePhoneResult
                {
                    IsValid = false
                };

                if (!string.IsNullOrEmpty(_phoneNr))
                {
                    var phoneNumberUtil = PhoneNumberUtil.GetInstance();

                    _phoneNr = _phoneNr.Trim();

                    PhoneNumber phoneNumber = phoneNumberUtil.Parse(_phoneNr, "VN");

                    bool isPhoneNr = phoneNumberUtil.IsValidNumber(phoneNumber);

                    if (isPhoneNr)
                    {
                        res.IsValid = true;
                        res.PhoneNr = "0" + phoneNumber.NationalNumber;
                    }
                }

                return res;
            }
            catch
            {

                return new ValidatePhoneResult
                {
                    IsValid = false
                };
            }
        }
    }

    public static class DateTimeHelpers
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static double GetEpochTicks(this DateTimeOffset dateTime)
        {
            return dateTime.Subtract(Epoch).TotalMilliseconds;
        }
    }


    public class EnumValue
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class FilterValidation
    {
        public bool IsValid { get; set; }

        public Dictionary<string, List<string>> Filter { get; set; }

        public List<string> FilterBy { get; set; }
    }
    public class ShipmentRateRequest
    {
        [Required]
        public int IDRate { get; set; }
        public int? ShipmentID { get; set; }
        [Required]
        public string ConsigneeNo { get; set; }
        public string Comment { get; set; }
    }
    public class FilterModel
    {
        public Dictionary<string, List<string>> Filter { get; set; }
    }

    public class ValidateModelDataOption
    {
        public bool AutoCorrectTheLength { get; set; } = true;
    }

    public class DimensionModel
    {
        /// <summary>
        /// Chiều dài
        /// </summary>
        public decimal? Length { get; set; }

        /// <summary>
        /// Chiều rộng
        /// </summary>
        public decimal? Width { get; set; }

        /// <summary>
        /// Chiều cao
        /// </summary>
        public decimal? Height { get; set; }
    }

    public class ValidatePhoneResult
    {
        public bool IsValid { get; set; }
        public string PhoneNr { get; set; }
    }

    public class LocationTypeRequest
    {
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public string WardId { get; set; }
        public bool IsInnerCity { get; set; }
        public bool IsOutlyingArea { get; set; }
        public bool IsIndustrialArea { get; set; }
    }

}
