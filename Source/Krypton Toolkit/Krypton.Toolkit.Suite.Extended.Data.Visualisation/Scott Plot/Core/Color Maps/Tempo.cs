﻿//This is a cmocean colormap
//All credit to Kristen Thyng
//This colormap is under the MIT License
//All cmocean colormaps are available at https://github.com/matplotlib/cmocean/tree/master/cmocean/rgb

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Tempo : ByteColormapBase
    {
        public override string Name => "Tempo";

        public override (byte r, byte g, byte b)[] Rgbs => _rgbs;
        private static readonly (byte, byte, byte)[] _rgbs = {
            ( 255, 246, 244 ),
            ( 253, 245, 243 ),
            ( 252, 244, 241 ),
            ( 251, 243, 240 ),
            ( 249, 242, 238 ),
            ( 248, 241, 237 ),
            ( 247, 240, 235 ),
            ( 245, 239, 234 ),
            ( 244, 238, 232 ),
            ( 242, 237, 231 ),
            ( 241, 236, 229 ),
            ( 240, 235, 228 ),
            ( 238, 234, 226 ),
            ( 237, 234, 225 ),
            ( 235, 233, 223 ),
            ( 234, 232, 222 ),
            ( 233, 231, 221 ),
            ( 231, 230, 219 ),
            ( 230, 229, 218 ),
            ( 228, 228, 216 ),
            ( 227, 227, 215 ),
            ( 226, 226, 214 ),
            ( 224, 226, 212 ),
            ( 223, 225, 211 ),
            ( 221, 224, 209 ),
            ( 220, 223, 208 ),
            ( 219, 222, 207 ),
            ( 217, 221, 205 ),
            ( 216, 221, 204 ),
            ( 214, 220, 203 ),
            ( 213, 219, 201 ),
            ( 211, 218, 200 ),
            ( 210, 217, 199 ),
            ( 209, 216, 197 ),
            ( 207, 216, 196 ),
            ( 206, 215, 195 ),
            ( 204, 214, 193 ),
            ( 203, 213, 192 ),
            ( 201, 212, 191 ),
            ( 200, 212, 190 ),
            ( 198, 211, 188 ),
            ( 197, 210, 187 ),
            ( 195, 209, 186 ),
            ( 194, 209, 185 ),
            ( 192, 208, 183 ),
            ( 191, 207, 182 ),
            ( 189, 206, 181 ),
            ( 188, 206, 180 ),
            ( 186, 205, 179 ),
            ( 185, 204, 178 ),
            ( 183, 203, 176 ),
            ( 182, 203, 175 ),
            ( 180, 202, 174 ),
            ( 179, 201, 173 ),
            ( 177, 200, 172 ),
            ( 176, 200, 171 ),
            ( 174, 199, 170 ),
            ( 172, 198, 169 ),
            ( 171, 197, 168 ),
            ( 169, 197, 166 ),
            ( 168, 196, 165 ),
            ( 166, 195, 164 ),
            ( 164, 195, 163 ),
            ( 163, 194, 162 ),
            ( 161, 193, 161 ),
            ( 160, 192, 160 ),
            ( 158, 192, 159 ),
            ( 156, 191, 159 ),
            ( 155, 190, 158 ),
            ( 153, 190, 157 ),
            ( 151, 189, 156 ),
            ( 150, 188, 155 ),
            ( 148, 188, 154 ),
            ( 146, 187, 153 ),
            ( 145, 186, 152 ),
            ( 143, 186, 151 ),
            ( 141, 185, 151 ),
            ( 139, 184, 150 ),
            ( 138, 183, 149 ),
            ( 136, 183, 148 ),
            ( 134, 182, 147 ),
            ( 133, 181, 147 ),
            ( 131, 181, 146 ),
            ( 129, 180, 145 ),
            ( 127, 179, 144 ),
            ( 125, 179, 144 ),
            ( 124, 178, 143 ),
            ( 122, 177, 142 ),
            ( 120, 177, 142 ),
            ( 118, 176, 141 ),
            ( 116, 175, 141 ),
            ( 114, 175, 140 ),
            ( 113, 174, 139 ),
            ( 111, 173, 139 ),
            ( 109, 173, 138 ),
            ( 107, 172, 138 ),
            ( 105, 171, 137 ),
            ( 103, 171, 137 ),
            ( 101, 170, 136 ),
            ( 99, 169, 136 ),
            ( 97, 169, 135 ),
            ( 95, 168, 135 ),
            ( 93, 167, 134 ),
            ( 91, 166, 134 ),
            ( 89, 166, 133 ),
            ( 87, 165, 133 ),
            ( 86, 164, 133 ),
            ( 84, 164, 132 ),
            ( 82, 163, 132 ),
            ( 80, 162, 132 ),
            ( 78, 161, 131 ),
            ( 75, 161, 131 ),
            ( 73, 160, 131 ),
            ( 71, 159, 130 ),
            ( 69, 159, 130 ),
            ( 67, 158, 130 ),
            ( 65, 157, 130 ),
            ( 63, 156, 129 ),
            ( 61, 156, 129 ),
            ( 59, 155, 129 ),
            ( 58, 154, 129 ),
            ( 56, 153, 129 ),
            ( 54, 152, 128 ),
            ( 52, 152, 128 ),
            ( 50, 151, 128 ),
            ( 48, 150, 128 ),
            ( 46, 149, 128 ),
            ( 44, 148, 127 ),
            ( 42, 147, 127 ),
            ( 41, 147, 127 ),
            ( 39, 146, 127 ),
            ( 37, 145, 127 ),
            ( 36, 144, 127 ),
            ( 34, 143, 126 ),
            ( 33, 142, 126 ),
            ( 31, 141, 126 ),
            ( 30, 141, 126 ),
            ( 28, 140, 126 ),
            ( 27, 139, 125 ),
            ( 26, 138, 125 ),
            ( 25, 137, 125 ),
            ( 23, 136, 125 ),
            ( 22, 135, 124 ),
            ( 22, 134, 124 ),
            ( 21, 133, 124 ),
            ( 20, 132, 124 ),
            ( 19, 132, 123 ),
            ( 19, 131, 123 ),
            ( 18, 130, 123 ),
            ( 18, 129, 123 ),
            ( 17, 128, 122 ),
            ( 17, 127, 122 ),
            ( 17, 126, 122 ),
            ( 17, 125, 121 ),
            ( 17, 124, 121 ),
            ( 17, 123, 121 ),
            ( 17, 122, 120 ),
            ( 17, 121, 120 ),
            ( 17, 120, 120 ),
            ( 17, 119, 119 ),
            ( 17, 118, 119 ),
            ( 18, 118, 118 ),
            ( 18, 117, 118 ),
            ( 18, 116, 118 ),
            ( 19, 115, 117 ),
            ( 19, 114, 117 ),
            ( 19, 113, 116 ),
            ( 20, 112, 116 ),
            ( 20, 111, 115 ),
            ( 20, 110, 115 ),
            ( 21, 109, 115 ),
            ( 21, 108, 114 ),
            ( 22, 107, 114 ),
            ( 22, 106, 113 ),
            ( 22, 105, 113 ),
            ( 23, 104, 112 ),
            ( 23, 103, 112 ),
            ( 23, 102, 111 ),
            ( 24, 101, 111 ),
            ( 24, 101, 110 ),
            ( 24, 100, 110 ),
            ( 25, 99, 109 ),
            ( 25, 98, 109 ),
            ( 25, 97, 108 ),
            ( 25, 96, 108 ),
            ( 26, 95, 107 ),
            ( 26, 94, 107 ),
            ( 26, 93, 106 ),
            ( 26, 92, 106 ),
            ( 26, 91, 105 ),
            ( 27, 90, 104 ),
            ( 27, 89, 104 ),
            ( 27, 88, 103 ),
            ( 27, 88, 103 ),
            ( 27, 87, 102 ),
            ( 27, 86, 102 ),
            ( 28, 85, 101 ),
            ( 28, 84, 101 ),
            ( 28, 83, 100 ),
            ( 28, 82, 99 ),
            ( 28, 81, 99 ),
            ( 28, 80, 98 ),
            ( 28, 79, 98 ),
            ( 28, 78, 97 ),
            ( 28, 77, 97 ),
            ( 28, 76, 96 ),
            ( 28, 76, 95 ),
            ( 28, 75, 95 ),
            ( 28, 74, 94 ),
            ( 28, 73, 94 ),
            ( 28, 72, 93 ),
            ( 28, 71, 93 ),
            ( 28, 70, 92 ),
            ( 28, 69, 91 ),
            ( 28, 68, 91 ),
            ( 28, 67, 90 ),
            ( 28, 66, 90 ),
            ( 28, 66, 89 ),
            ( 28, 65, 88 ),
            ( 28, 64, 88 ),
            ( 27, 63, 87 ),
            ( 27, 62, 87 ),
            ( 27, 61, 86 ),
            ( 27, 60, 86 ),
            ( 27, 59, 85 ),
            ( 27, 58, 84 ),
            ( 27, 57, 84 ),
            ( 27, 56, 83 ),
            ( 26, 55, 83 ),
            ( 26, 54, 82 ),
            ( 26, 54, 81 ),
            ( 26, 53, 81 ),
            ( 26, 52, 80 ),
            ( 26, 51, 80 ),
            ( 25, 50, 79 ),
            ( 25, 49, 79 ),
            ( 25, 48, 78 ),
            ( 25, 47, 77 ),
            ( 25, 46, 77 ),
            ( 24, 45, 76 ),
            ( 24, 44, 76 ),
            ( 24, 43, 75 ),
            ( 24, 42, 75 ),
            ( 24, 41, 74 ),
            ( 23, 40, 74 ),
            ( 23, 39, 73 ),
            ( 23, 38, 72 ),
            ( 23, 37, 72 ),
            ( 23, 36, 71 ),
            ( 22, 35, 71 ),
            ( 22, 34, 70 ),
            ( 22, 33, 70 ),
            ( 22, 32, 69 ),
            ( 21, 31, 69 ),
            ( 21, 30, 68 ),
            ( 21, 29, 68 )

        };
    }
}

