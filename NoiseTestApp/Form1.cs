using NoiseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private MethodInfo calcFunc;
        private string code = @"
using NoiseLibrary;
namespace NoiseTestApp
{
  public static class Program
  {
    private static CImplicitModuleBase output;
    static Program()
    {
        var ground_gradient = new CImplicitGradient(x1:0, x2:0, y1:0, y2:1);

        var lowland_shape_fractal = new CImplicitFractal(type: EFractalTypes.BILLOW, basistype:CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype:CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:2, freq: 0.25);
        var lowland_autocorrect = new CImplicitAutoCorrect(source:lowland_shape_fractal, low:0, high:1);
        var lowland_scale = new CImplicitScaleOffset(source:lowland_autocorrect, scale:0.125, offset:-0.45);
        var lowland_y_scale = new CImplicitScaleDomain(source:lowland_scale, y:0);
        var lowland_terrain = new CImplicitTranslateDomain(source:ground_gradient, tx:0.0, ty:lowland_y_scale, tz:0.0);

        var highland_shape_fractal = new CImplicitFractal(type:EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:4, freq: 2);
        var highland_autocorrect = new CImplicitAutoCorrect(source:highland_shape_fractal, low:-1, high:1);
        var highland_scale = new CImplicitScaleOffset(source:highland_autocorrect, scale:0.25, offset:0);
        var highland_y_scale = new CImplicitScaleDomain(source:highland_scale, y:0);
        var highland_terrain = new CImplicitTranslateDomain(source:ground_gradient, tx:0.0, ty:highland_y_scale, tz:0.0);

        var mountain_shape_fractal = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:8, freq: 1);
        var mountain_autocorrect = new CImplicitAutoCorrect(source:mountain_shape_fractal, low:-1, high:1);
        var mountain_scale = new CImplicitScaleOffset(source:mountain_autocorrect, scale:0.45, offset:0.15);
        var mountain_y_scale = new CImplicitScaleDomain(source:mountain_scale, y:0.25);
        var mountain_terrain = new CImplicitTranslateDomain(source:ground_gradient, tx:0.0, ty:mountain_y_scale, tz:0.0);

        var terrain_type_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype:CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:3, freq:0.125);
        var terrain_autocorrect = new CImplicitAutoCorrect(source:terrain_type_fractal, low:0, high:1);
        var terrain_type_y_scale = new CImplicitScaleDomain(source:terrain_autocorrect, y:0);
        var terrain_type_cache = new CImplicitCache(terrain_type_y_scale);
        var highland_mountain_select = new CImplicitSelect(low:highland_terrain, high:mountain_terrain, control:terrain_type_cache, threshold:0.55, falloff:0.2);
        var highland_lowland_select = new CImplicitSelect(low:lowland_terrain, high:highland_mountain_select, control:terrain_type_cache, threshold:0.25, falloff:0.15);
        var highland_lowland_select_cache = new CImplicitCache(highland_lowland_select);
        var ground_select = new CImplicitSelect(low:0, high:1, threshold:0.5, control:highland_lowland_select_cache);

        var cave_shape = new CImplicitFractal(type: EFractalTypes.RIDGEDMULTI, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:1, freq: 4);
        var cave_attenuate_bias = new CImplicitMath(op:EMathOperation.BIAS, source:highland_lowland_select_cache, p:0.45);
        var cave_shape_attenuate = new CImplicitCombiner(type:ECombinerTypes.MULT, source0:cave_shape, source1:cave_attenuate_bias);
        var cave_perturb_fractal = new CImplicitFractal(type: EFractalTypes.FBM, basistype: CImplicitBasisFunction.EBasisTypes.GRADIENT, interptype: CImplicitBasisFunction.EInterpTypes.QUINTIC, octaves:6, freq: 3);
        var cave_perturb_scale = new CImplicitScaleOffset(source:cave_perturb_fractal, scale:0.5, offset:0);
        var cave_perturb = new CImplicitTranslateDomain(source:cave_shape_attenuate, tx:cave_perturb_scale, ty:0.0, tz:0.0);
        var cave_select = new CImplicitSelect(low:1, high:0, control:cave_perturb, threshold:0.48, falloff:0);

        var ground_cave_multiply = new CImplicitCombiner(type: ECombinerTypes.MULT, source0:cave_select, source1:ground_select);


        output = ground_cave_multiply;
    }
    public static double Calc(double x, double y)
    {
      return output.get(x,y);
    }
    //public static double Calc(double x, double y, double z)
    //{
    //  return output.get(x,y,z);
    //}
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
            calcFunc = null;
            using (var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } }))
            {
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", false);
                parameters.ReferencedAssemblies.Add("NoiseLibrary.dll");
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = false;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, code);
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
                if (results.Errors.Count > 0)
                {
                    var warn = results.Errors[0].IsWarning ? "W" : "E";
                    errorsTextBox.Text = $"[{warn}]{results.Errors[0].Line}: {results.Errors[0].ErrorText}";
                    return false;
                }

                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("NoiseTestApp.Program");
                calcFunc = program.GetMethod("Calc");
                return true;
            }
        }

        private Bitmap DrawImage(int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;


            for (int x = 1; x < width; x++)
            {
                for (int y = 1; y < height; y++)
                {
                    var p = (int)(255 * (double)calcFunc.Invoke (null, new object [] { (double)x / width, (double)y / height}));
                    if (p < 0) p = 0;
                    if (p > 255) p = 255;
                    var color = Color.FromArgb(255, 0, p, 0);
                    graphics.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                }
            }

            return bitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            code = this.textBox1.Text;
            if (Compile())
                Draw();
        }
    }
}
