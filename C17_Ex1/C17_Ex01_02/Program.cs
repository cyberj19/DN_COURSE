namespace C17_Ex01_02
{
    public class Program
    {
        private const char k_HourGlassChar = '*';
        private const char k_SpaceChar = ' ';
        private const uint k_HourGlassSize = 5;
        private const uint k_HourGlassSecondPartStartingSize = 3;
        private const int k_NumSidesToAsterisksOnScreen = 2;

        static void Main(string[] args)
        {
            printLengthFiveHourGlass();
        }

        private static void printLengthFiveHourGlass()
        {
            string hourGlassStr = GenerateHourGlassStr(k_HourGlassSize, k_HourGlassChar);

            System.Console.WriteLine(hourGlassStr);
        }

        // todo:..... Generate vs generate. decide if public or private
        public static string GenerateHourGlassStr(uint i_Size, char i_HourGlassChar)
        {
            uint usedSizeForHourglass = i_Size;
            System.Text.StringBuilder hourGlassStrBuilder = new System.Text.StringBuilder();

            if (i_Size != 0)
            {
                if ((i_Size % 2) == 0)
                {
                    usedSizeForHourglass = i_Size - 1;
                }

                // cannot use condition i >= 1 as if i = 1, i - 2 will generate MAX_UINT.
                for (uint i = usedSizeForHourglass; i > 1; i = i - 2)
                {
                    hourGlassStrBuilder.Append(generateHourGlassLine(i, usedSizeForHourglass, i_HourGlassChar));
                }

                hourGlassStrBuilder.Append(generateHourGlassLine(1, usedSizeForHourglass, i_HourGlassChar));
                for (uint i = k_HourGlassSecondPartStartingSize; i <= usedSizeForHourglass; i = i + 2)
                {
                    hourGlassStrBuilder.Append(generateHourGlassLine(i, usedSizeForHourglass, i_HourGlassChar));
                }
            }

            return hourGlassStrBuilder.ToString();
        }

        private static System.Text.StringBuilder generateHourGlassLine(uint i_NumAsterisks, uint i_LineSize, char i_HourGlassChar)
        {
            System.Text.StringBuilder lineStrBuilder = new System.Text.StringBuilder();

            if (i_LineSize != i_NumAsterisks)
            {
                lineStrBuilder.Append(k_SpaceChar, (int)(i_LineSize - i_NumAsterisks) / k_NumSidesToAsterisksOnScreen);
            }

            lineStrBuilder.Append(i_HourGlassChar, (int)i_NumAsterisks);
            lineStrBuilder.Append(System.Environment.NewLine);

            return lineStrBuilder;
        }
    }
}
