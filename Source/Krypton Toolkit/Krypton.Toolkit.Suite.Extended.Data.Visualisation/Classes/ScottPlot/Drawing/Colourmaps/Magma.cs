﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Magma : IColourmap
    {
        public (byte r, byte g, byte b) GetRGB(byte value)
        {
            byte[] bytes = BitConverter.GetBytes(rgb[value]);
            return (bytes[2], bytes[1], bytes[0]);
        }

        private readonly int[] rgb =
        {
            00000003, 00000004, 00000006, 00065543, 00065801, 00065803, 00131597, 00131599,
            00197393, 00262931, 00263189, 00328727, 00394521, 00460059, 00525853, 00591647,
            00657186, 00722980, 00788774, 00854568, 00920106, 00985900, 01051695, 01117233,
            01183027, 01314101, 01379896, 01445434, 01511228, 01576767, 01708097, 01773636,
            01839174, 01970249, 02036043, 02101581, 02232656, 02298194, 02429269, 02494807,
            02625881, 02756956, 02822494, 02953312, 03084386, 03149925, 03280999, 03412072,
            03477354, 03608428, 03739502, 03870575, 03936113, 04067186, 04198259, 04329332,
            04394869, 04525942, 04657015, 04722808, 04853881, 04919417, 05050746, 05181819,
            05247611, 05378684, 05444476, 05575549, 05706877, 05772670, 05903742, 05969534,
            06100862, 06166399, 06297727, 06363263, 06494591, 06625920, 06691456, 06822784,
            06888576, 07019648, 07085440, 07216769, 07282305, 07413633, 07544705, 07610497,
            07741825, 07807361, 07938689, 08004225, 08135553, 08266881, 08332417, 08463745,
            08529281, 08660609, 08726145, 08857473, 08988801, 09054337, 09185664, 09251200,
            09382528, 09513600, 09579392, 09710464, 09776256, 09907327, 10038655, 10104191,
            10235519, 10366590, 10432382, 10563454, 10694782, 10760317, 10891645, 10957181,
            11088508, 11219836, 11285371, 11416699, 11547771, 11613562, 11744634, 11875961,
            11941497, 12072824, 12138360, 12269687, 12401015, 12466550, 12597877, 12728949,
            12794740, 12926068, 12991603, 13122930, 13254258, 13319793, 13451120, 13516912,
            13648239, 13714030, 13845101, 13910893, 14042220, 14108011, 14239338, 14305129,
            14436457, 14502248, 14568039, 14699366, 14765158, 14830949, 14962276, 15028323,
            15094114, 15159906, 15225953, 15357280, 15423072, 15489119, 15554911, 15620958,
            15621469, 15687261, 15753309, 15819100, 15885148, 15951196, 15951707, 16017499,
            16083547, 16084059, 16150107, 16150619, 16216411, 16216924, 16282972, 16283484,
            16349532, 16350045, 16350557, 16416606, 16416862, 16417375, 16483424, 16483936,
            16484449, 16484962, 16551011, 16551523, 16552036, 16552549, 16552806, 16618855,
            16619368, 16619881, 16620394, 16620907, 16621420, 16621934, 16622191, 16622704,
            16688753, 16689267, 16689780, 16690293, 16690806, 16691064, 16691577, 16692091,
            16692604, 16693117, 16693631, 16694144, 16694402, 16694915, 16695429, 16695942,
            16696456, 16696969, 16697227, 16697741, 16698254, 16633232, 16633746, 16634259,
            16634517, 16635031, 16635544, 16636058, 16636572, 16637085, 16637343, 16637857,
            16638371, 16573349, 16573862, 16574120, 16574634, 16575148, 16575662, 16576176,
            16576689, 16576947, 16577461, 16577975, 16512953, 16513467, 16513725, 16514239,
        };
    }
}