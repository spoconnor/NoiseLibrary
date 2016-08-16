using NoiseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace NoiseTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox1.Text = code;
            Compile ();
        }
        private int xOffset, zOffset;
        private Assembly assembly;
        private Type program;
        private MethodInfo calc2dFunc;
        private MethodInfo calc3dFunc;
        private string code = @"
using NoiseLibrary;
namespace NoiseTestApp
{
  public static class Settings
  {
        public const int waterLevel = 20;
        public const int CHUNK_SIZE = 32;
        public const int CHUNK_HEIGHT = 128;
        public const int FRACTAL_SIZE = CHUNK_SIZE;// * 20;
        public const int globalMapSize = 256*CHUNK_SIZE;
        public const int minNoiseHeight = 0;
        public const int maxNoiseHeight = 127;
        public const int globalChunkSize = globalMapSize / CHUNK_SIZE;
  }
  public static class Program
  {
    private static CImplicitModuleBase output;
    static Program()
    {
        var ground_gradient = new CImplicitGradient(x1:0, x2:0, y1:0, y2:1);

        var lowland_shape_fractal = new CImplicitFractal(type: EFractalTypes.BILLOW, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 2, freq: 1.25);
        var lowland_autocorrect = new CImplicitAutoCorrect(source: lowland_shape_fractal, low: 0, high: 1);
        var lowland_scale = new CImplicitScaleOffset(source: lowland_autocorrect, scale: 0.30, offset: 0.25);
        var lowland_cache = new CImplicitCache(lowland_scale);
        var lowland_y_scale = new CImplicitScaleDomain(source: lowland_cache, y: 0);
        var lowland_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0.0, ty: lowland_y_scale, tz: 0.0);
        //var lowland_terrain = new CImplicitGradient(x1:0, x2:0, y1:0, y2:1);

        var highland_shape_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 4, freq: 1);
        var highland_autocorrect = new CImplicitAutoCorrect(source: highland_shape_fractal, low: -1, high: 1);
        var highland_scale = new CImplicitScaleOffset(source: highland_autocorrect, scale: 0.25, offset: 0);
        var highland_cache = new CImplicitCache(highland_scale);
        var highland_y_scale = new CImplicitScaleDomain(source: highland_cache, y: 0);
        var highland_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0.0, ty: highland_y_scale, tz: 0.0);

        var mountain_shape_fractal = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:4, freq: 3);
        var mountain_autocorrect = new CImplicitAutoCorrect(source:mountain_shape_fractal, low:-1, high:1);
        var mountain_scale = new CImplicitScaleOffset(source:mountain_autocorrect, scale:0.45, offset:0.15);
        var mountain_cache = new CImplicitCache(mountain_scale);
        var mountain_y_scale = new CImplicitScaleDomain(source:mountain_cache, y:0.25);
        var mountain_terrain = new CImplicitTranslateDomain(source:ground_gradient, tx:0.0, ty:mountain_y_scale, tz:0.0);
        //var mountain_terrain = new CImplicitGradient(x1:0, x2:0, y1:0, y2:1);

        var terrain_type_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype:CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:3, freq:0.5);
        var terrain_autocorrect = new CImplicitAutoCorrect(source:terrain_type_fractal, low:0, high:1);
        var terrain_type_y_scale = new CImplicitScaleDomain(source:terrain_autocorrect, y:0);
        var terrain_type_cache = new CImplicitCache(terrain_type_y_scale);
        var highland_mountain_select = new CImplicitSelect(low:highland_terrain, high:mountain_terrain, control:terrain_type_cache, threshold:0.55, falloff:0.2);
        var mountain_lowland_select = new CImplicitSelect(low:lowland_terrain, high:highland_mountain_select, control:terrain_type_cache, threshold:0.5, falloff:0.2);
        var mountain_lowland_select_cache = new CImplicitCache(mountain_lowland_select);

        var coastline_shape_fractal = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 2, freq: 1);
        var coastline_autocorrect = new CImplicitAutoCorrect(source: coastline_shape_fractal, low: 0, high: 1);
        var coastline_seamless = new CImplicitSeamlessMapping(source: coastline_autocorrect, seamlessmode: CImplicitSeamlessMapping.EMappingModes.SEAMLESS_X);
        var coastline_cache = new CImplicitCache(coastline_seamless );
        var coastline_y_scale = new CImplicitScaleDomain(source: coastline_cache, y: 0);
        var coastline_scale = new CImplicitScaleOffset(source:coastline_y_scale , scale: 0.5, offset: -1.2);
        var coastline_terrain = new CImplicitTranslateDomain(source: ground_gradient, tx: 0.0, ty: coastline_scale, tz: 0.0);
        var coastline_radial_mapping = new CImplicitTranslateRadial(source: coastline_terrain, xCentre: Settings.globalMapSize/Settings.FRACTAL_SIZE/2, zCentre: Settings.globalMapSize/Settings.FRACTAL_SIZE/2);
        //var coastline_radial_mapping = new CImplicitGradient(x1:0, x2:0, y1:0, y2:1);

        var coastline_highland_lowland_select = new CImplicitTranslateDomain(source: mountain_lowland_select_cache, tx: 0.0, ty: coastline_radial_mapping, tz: 0.0);

        //var ground_select = new CImplicitSelect(low: 0, high: 1, threshold: 0.5, control: coastline_highland_lowland_select);

        //    var cave_attenuate_bias = new CImplicitMath(op: EMathOperation.BIAS, source: highland_lowland_select_cache, p: 0.45);
        //    var cave_shape1 = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 1, freq: 4);
        //    var cave_shape2 = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 1, freq: 4);
        //    var cave_shape_attenuate = new CImplicitCombiner(type: ECombinerTypes.MULT, source0: cave_shape1, source1: cave_attenuate_bias, source2: cave_shape2);
        //    var cave_perturb_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves: 6, freq: 3);
        //    var cave_perturb_scale = new CImplicitScaleOffset(source: cave_perturb_fractal, scale: 0.5, offset: 0);
        //    var cave_perturb = new CImplicitTranslateDomain(source: cave_shape_attenuate, tx: cave_perturb_scale, ty: 0, tz: 0);
        //    var cave_select = new CImplicitSelect(low: 1, high: 0, control: cave_perturb, threshold: 0.48, falloff: 0);

        //    var ground_cave_multiply = new CImplicitCombiner(type: ECombinerTypes.MULT, source0: cave_select, source1: ground_select);

        output = new CImplicitSelect(low: 0, high: 1, threshold: 0.5, control: coastline_highland_lowland_select);
    }
    public static double Calc2d(double x, double y)
    {
      return output.get(x,y);
    }
    public static double Calc3d(double x, double y, double z)
    {
      return output.get(x,y,z);
    }
  }
}
";


        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            var currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.pictureBox1.Image = this.DrawImage(this.pictureBox1.Width, this.pictureBox1.Height);
            this.Cursor = currentCursor;
        }

        private bool Compile ()
        {
            calc2dFunc = null;
            calc3dFunc = null;
            using (var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } }))
            {
                program = null;
                assembly = null;
                
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", false);
                parameters.ReferencedAssemblies.Add("NoiseLibrary.dll");
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = false;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, code);
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
                if (results.Errors.HasErrors)
                {
                    var warn = results.Errors[0].IsWarning ? "W" : "E";
                    errorsTextBox.Text = $"[{warn}]{results.Errors[0].Line}: {results.Errors[0].ErrorText}";
                    return false;
                }

                assembly = results.CompiledAssembly;
                program = assembly.GetType("NoiseTestApp.Program");
                calc2dFunc = program.GetMethod("Calc2d");
                calc3dFunc = program.GetMethod("Calc3d");
                return true;
            }
        }

        private Bitmap DrawImage(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (this.radioButton2d.Checked)
            {
			    if (calc2dFunc == null) return bitmap;
                for (int x = 1; x < width; x++)
                {
                    for (int y = 1; y < height; y++)
                    {
                        var p = (int)(255 * (double)calc2dFunc.Invoke(null, new object[] { (double)(x+xOffset) / width, (double)y / height }));
                        if (p < 0) p = 0;
                        if (p > 255) p = 255;
                        var color = Color.FromArgb(255, 0, p, 0);
                        graphics.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                    }
                }
            }
            else
            {
			    if (calc3dFunc == null) return bitmap;
                var boxImage = imageList1.Images["box_blue"];
                double blocks = 50;
                for (double x = 0; x < blocks; x++)
                {
                    for (double z = 0; z < blocks; z++)
                    {
                        for (double y = 32; y >0; y--)
                        {
                            var p = (double)calc3dFunc.Invoke(null, new object[] { (x+xOffset)/blocks, y/32, (z+zOffset)/blocks });
                            if (p >= 0.5)
                            {
                                graphics.DrawImage(boxImage, new Point((int)((width / 2) + ((x - z) * 8)), (int)((height / 2) + ((x + z) * 5) - (32-y)*6 - 150)));
                            }
                        }
                    }
                }
            }

            return bitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //code = this.textBox1.Text;
            //if (Compile())
            //    Draw();
        }

        private void nButton_Click(object sender, EventArgs e)
        {
            zOffset -= 10;
            Draw();
        }

        private void wButton_Click(object sender, EventArgs e)
        {
            xOffset -= 10;
            Draw();
        }

        private void sButton_Click(object sender, EventArgs e)
        {
            zOffset += 10;
            Draw();
        }

        private void eButton_Click(object sender, EventArgs e)
        {
            xOffset += 10;
            Draw();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            code = this.textBox1.Text;
            if (Compile())
                Draw();
        }
    }
}
