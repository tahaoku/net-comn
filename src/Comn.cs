class Comn
{
  /// <summary>
        /// 字符串转为Unicode（包含10进制及16进制表示）
        /// &# 后接10进制数字；
        /// &#x 后接16进制数字；
        /// </summary>
        /// <param name="s">待转换字符串</param>
        /// <returns>返回字符串的各种Unicode码集合</returns>
        public static string[] StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;

            StringBuilder sb = new StringBuilder();
            StringBuilder sb10 = new StringBuilder();
            StringBuilder sb16 = new StringBuilder();

            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());

                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));

                string ch16_1 = Convert.ToString(buffer[1], 16);
                string ch16_0 = Convert.ToString(buffer[0], 16);
                if (ch16_1.Length < 2)
                {
                    ch16_1 = "0" + ch16_1;
                }
                if (ch16_0.Length < 2)
                {
                    ch16_0 = "0" + ch16_0;
                }
                sb16.Append(String.Format("&#x{0:X2}{1:X2};", ch16_1, ch16_0));

                int ch10int = int.Parse(ch16_1 + "" + ch16_0, System.Globalization.NumberStyles.HexNumber);
                sb10.Append("&#" + ch10int + ";");
            }

            string[] val = { sb.ToString(), sb10.ToString(), sb16.ToString() };
            return val;
        }
}
