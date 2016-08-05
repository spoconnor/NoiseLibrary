using NoiseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"Original Hash: {TestNoiseLibHash()}");
            Console.WriteLine($"Landscape:     {TestLandscape()}");

            Console.ReadKey();
        }

        public static long TestLandscape()
        {
            var compileTestLandscape = CompileTestLandscape();
            var pre = System.DateTime.Now.Ticks;
            double blocks = 32;
            for (var x = 40*blocks; x < 41*blocks; x++)
            {
                for (var z = 40*blocks; z < 41*blocks; z++)
                {
                    for (var y = 0; y <= 32; y++)
                    {
                        var p = compileTestLandscape.get(x, y, z);
                    }
                }
            }
            var post = System.DateTime.Now.Ticks;
            return post - pre;
        }

        public static long TestNoiseLibHash()
        {
            var pre = System.DateTime.Now.Ticks;
            for (int x = 1; x < 255; x = x + 50)
                for (int y = 1; y < 255; y = y + 50)
                    for (int z = 1; z < 255; z = z + 50)
                        for (uint s = 1; s < 255; s = s + 50)
                        {
                            uint hash = NoiseLibrary.Hashing.hash_coords_3(x, y, z, s);
                        }
            var post = System.DateTime.Now.Ticks;
            return post - pre;
        }


        public static void Run2()
        {
            int x = 1;
            int y = 2;
            int z = 3;
            uint seed = 4;
            uint hash = Hashing.hash_coords_3(x, y, z, seed);

        }


        public static CImplicitModuleBase CompileTestLandscape()
        {
            var ground_gradient = new CImplicitGradient(x1: 0, x2: 0, y1: 0, y2: 1);

            var lowland_shape_fractal = new CImplicitFractal(type: EFractalTypes.BILLOW, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 2, freq: 0.25);
            var lowland_autocorrect = new CImplicitAutoCorrect(source: lowland_shape_fractal, low: 0, high: 1);
            var lowland_scale = new CImplicitScaleOffset(source: lowland_autocorrect, scale: 0.125, offset: -0.45);
            var lowland_y_scale = new CImplicitScaleDomain(source: lowland_scale, y: 0);
            var lowland_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0.0, ty: lowland_y_scale, tz: 0.0);

            var highland_shape_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 4, freq: 2);
            var highland_autocorrect = new CImplicitAutoCorrect(source: highland_shape_fractal, low: -1, high: 1);
            var highland_scale = new CImplicitScaleOffset(source: highland_autocorrect, scale: 0.25, offset: 0);
            var highland_y_scale = new CImplicitScaleDomain(source: highland_scale, y: 0);
            var highland_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0.0, ty: highland_y_scale, tz: 0.0);

            var mountain_shape_fractal = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 8, freq: 1);
            var mountain_autocorrect = new CImplicitAutoCorrect(source: mountain_shape_fractal, low: -1, high: 1);
            var mountain_scale = new CImplicitScaleOffset(source: mountain_autocorrect, scale: 0.45, offset: 0.15);
            var mountain_y_scale = new CImplicitScaleDomain(source: mountain_scale, y: 0.25);
            var mountain_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0.0, ty: mountain_y_scale, tz: 0.0);

            var terrain_type_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 3, freq: 0.125);
            var terrain_autocorrect = new CImplicitAutoCorrect(source: terrain_type_fractal, low: 0, high: 1);
            var terrain_type_y_scale = new CImplicitScaleDomain(source: terrain_autocorrect, y: 0);
            var terrain_type_cache = new CImplicitCache(terrain_type_y_scale);
            var highland_mountain_select = new CImplicitSelect(low: highland_terrain, high: mountain_terrain, control: terrain_type_cache, threshold: 0.55, falloff: 0.2);
            var highland_lowland_select = new CImplicitSelect(low: lowland_terrain, high: highland_mountain_select, control: terrain_type_cache, threshold: 0.25, falloff: 0.15);
            var highland_lowland_select_cache = new CImplicitCache(highland_lowland_select);

            var ground_select = new CImplicitSelect(low: 0, high: 1, threshold: 0.5, control: highland_lowland_select_cache);

            var cave_attenuate_bias = new CImplicitMath(op: EMathOperation.BIAS, source: highland_lowland_select_cache, p: 0.45);
            var cave_shape1 = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 1, freq: 4);
            var cave_shape2 = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 1, freq: 4);
            var cave_shape_attenuate = new CImplicitCombiner(type: ECombinerTypes.MULT, source0: cave_shape1, source1: cave_attenuate_bias, source2: cave_shape2);
            var cave_perturb_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 6, freq: 3);
            var cave_perturb_scale = new CImplicitScaleOffset(source: cave_perturb_fractal, scale: 0.5, offset: 0);
            var cave_perturb = new CImplicitTranslateDomain(source: cave_shape_attenuate, tx: cave_perturb_scale, ty: 0, tz: 0);
            var cave_select = new CImplicitSelect(low: 1, high: 0, control: cave_perturb, threshold: 0.48, falloff: 0);

            var ground_cave_multiply = new CImplicitCombiner(type: ECombinerTypes.MULT, source0: cave_select, source1: ground_select);

            return ground_cave_multiply;
        }
    }
}
