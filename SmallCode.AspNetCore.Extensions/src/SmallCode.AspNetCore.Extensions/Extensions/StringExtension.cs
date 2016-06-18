using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符串转Enum
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string inputValue)
        {
            return (T)Enum.Parse(typeof(T), inputValue);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToMD5(this string inputValue)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(inputValue));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }

        /// <summary>
        /// 根据传入长度将字符串截取显示，超出的部分显示.....
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetCutString(this string strInput, int length)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return "";
            }
            else
            {
                if (strInput.Length <= length)
                {
                    return strInput;
                }
                else
                {
                    return strInput.Substring(0, length) + "......";
                }
            }
        }

        /// <summary>
        /// 计算字串的长度
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static int GetLength(this string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
            {
                return 0;
            }
            else
            {
                return strInput.Trim().Length;
            }
        }

        /// <summary>
        /// 字符串转为int32
        /// </summary>
        /// <param name="inputValue">需要被转换的字串</param>
        /// <param name="defaultValue">无法转换时默认返回值，default:0</param>
        /// <returns></returns>
        public static int ToInt32(this string inputValue, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return defaultValue;
            }

            // 去掉千分位
            var value = inputValue.Trim().Replace(",", "");

            if (!new System.Text.RegularExpressions.Regex(@"[^0-9]").IsMatch(value))
            {
                return Convert.ToInt32(value);
            }

            return defaultValue;
        }

        /// <summary>
        /// 字符串转换decimal
        /// </summary>
        /// <param name="inputValue">需要被转换的字串</param>
        /// <param name="defaultValue">无法转换时默认返回值，default:0</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string inputValue, decimal defaultValue = 0)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return defaultValue;
            }

            // 去掉千分位
            var value = inputValue.Trim().Replace(",", "");

            if (!new System.Text.RegularExpressions.Regex(@"[^\-0-9\.]").IsMatch(value))
            {
                return Convert.ToDecimal(value);
            }

            return defaultValue;
        }


        /// <summary>
        /// 字符串转换DateTime
        /// </summary>
        /// <param name="inputValue">需要被转换的字串</param>
        public static DateTime ToDateTime(this string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                throw new ArgumentNullException("inputValue is null or empty string now.");
            }

            DateTime result;

            if (DateTime.TryParse(inputValue.Trim(), out result))
            {
                return result;
            }

            throw new InvalidCastException(string.Format("The input value : {0} was converted to the Data Type of DateTime.", inputValue));
        }

        /// <summary>
        ///  字符串转换DateTime
        /// </summary>
        /// <param name="inputValue">需要被转换的字串</param>
        public static DateTime? ToNullableDateTime(this string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return null;
            }

            DateTime result;

            if (DateTime.TryParse(inputValue.Trim(), out result))
            {
                return result;
            }

            throw new InvalidCastException(string.Format("The input value : {0} was converted to the Data Type of DateTime.", inputValue));
        }


        /// <summary>
        /// 判断日期格式是否正确
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static bool IsDate(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return false;
            }
            else
            {
                if (dateString.Trim().Length != 10)
                {
                    return false;
                }
                else
                {
                    return new System.Text.RegularExpressions.Regex(@"^\d{4}[/]\d{2}[/]\d{2}$").IsMatch(dateString.Trim());
                }
            }
        }

        /// <summary>
        /// 判断字符串是否为金额
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsAmmount(this string strString)
        {
            if (string.IsNullOrEmpty(strString))
            {
                return false;
            }
            else
            {
                return new System.Text.RegularExpressions.Regex(@"^([0-9]([\d]{0,19}))(\.[\d]{0,2})?$").IsMatch(strString.Trim());
            }
        }

        /// <summary>
        /// 判断字符串是否为百分比
        /// </summary>
        /// <param name="strString"></param>
        /// <returns></returns>
        public static bool IsPercentage(this string strString)
        {
            if (string.IsNullOrEmpty(strString))
            {
                return false;
            }
            else
            {
                if (new System.Text.RegularExpressions.Regex(@"^([0-9]([\d]{0,2}))(\.[\d]{0,2})?$").IsMatch(strString.Trim()))
                {
                    decimal percentage = strString.ToDecimal();
                    if (percentage <= 0 || percentage > 100)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 判断字符串是否为正整数
        /// </summary>
        /// <param name="strString"></param>
        /// <returns></returns>
        public static bool IsNumeral(this string strString)
        {
            if (string.IsNullOrEmpty(strString))
            {
                return false;
            }
            else
            {
                return new System.Text.RegularExpressions.Regex(@"^[\d]{1,100}$").IsMatch(strString.Trim());
            }
        }

        /// <summary>
        /// 字符串转为DateTime类型
        /// </summary>
        /// <param name="inputValue">需要被转换的的字串</param>
        /// <returns>added by H at 2013/07/09</returns>
        public static DateTime? StringToDateTime(this string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return null;
            }

            DateTime result;

            if (DateTime.TryParse(inputValue.Trim(), out result))
            {
                return result;
            }

            throw new InvalidCastException(string.Format("The input value : {0} was converted to the Data Type of DateTime.", inputValue));
        }


        /// <summary>
        ///  字符串转Double
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static double ToDouble(this string inputValue)
        {
            return Convert.ToDouble(inputValue);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] ToSpilt(this string inputValue, char separator)
        {
            return inputValue.Split(separator);
        }


    }
}
